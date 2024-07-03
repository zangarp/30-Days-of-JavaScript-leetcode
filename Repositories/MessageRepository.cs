using FinOpsAPI.Interfaces;
using FinOpsAPI.Models;
using Microsoft.OpenApi.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using FinOpsAPI.Utilities;
using Oracle.ManagedDataAccess.Types;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Dapper.Oracle;
using System.Data.Common;
using Dapper;
using FinOpsAPI.Converters;
using SignXML.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinOpsAPI.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ISignXMLRepository signXMLRepository;
        private readonly IConfiguration configuration;
        public MessageRepository(ISignXMLRepository signXMLRepository, IConfiguration configuration)
        {
            this.signXMLRepository = signXMLRepository;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<Message>> GetMessagesAsync(string connString, MessageFilter filter)
        {
            var messages = new List<Message>();

            using (var connection = new OracleConnection(connString))
            {
                var cmd = new OracleCommand();
                cmd.Connection = connection;
                cmd.CommandText = $@"begin
                                        kfm.c_pkgconnect.popen();
                                      :result := kfm.pkg_messages_cfm.get_filteredmessageslist(plistid => :plistid,
                                                           preceivedatebegin => :preceivedatebegin,
                                                           preceivedateend => :preceivedateend,
                                                           psenddatebegin => :psenddatebegin,
                                                           psenddateend => :psenddateend,
                                                           pmessnumberbegin => :pmessnumberbegin,
                                                           pmessnumberend => :pmessnumberend,
                                                           pmessreason => :pmessreason,
                                                           pmessoperationstatus => :pmessoperationstatus,
                                                           poperationnumber => :poperationnumber,
                                                           pidtypeoperation => :pidtypeoperation,
                                                           pidviewoperation => :pidviewoperation,
                                                           pcurrencycode => :pcurrencycode,
                                                           pamountcurrencybegin => :pamountcurrencybegin,
                                                           pamountcurrencyend => :pamountcurrencyend,
                                                           pamountcurrencytengebegin => :pamountcurrencytengebegin,
                                                           pamountcurrencytengeend => :pamountcurrencytengeend,
                                                           prescursor => :prescursor);
                                    end;
                                    ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("result", OracleDbType.Double).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("plistid", OracleDbType.Double).Value = filter.ListId; //CHANGE
                cmd.Parameters.Add("preceivedatebegin", OracleDbType.Date).Value = filter.ReceiveDateBegin.AddHours(6);
                cmd.Parameters.Add("preceivedateend", OracleDbType.Date).Value = filter.ReceiveDateEnd.AddHours(6);
                cmd.Parameters.Add("psenddatebegin", OracleDbType.Date).Value = filter.SendDateBegin == DateTime.MinValue ? DBNull.Value : filter.SendDateBegin.AddHours(6);
                cmd.Parameters.Add("psenddateend", OracleDbType.Date).Value = filter.SendDateEnd == DateTime.MinValue ? DBNull.Value : filter.SendDateEnd.AddHours(6);
                cmd.Parameters.Add("pmessnumberbegin", OracleDbType.Double).Value = filter.MessNumberBegin == 0 ? DBNull.Value : filter.MessNumberBegin;
                cmd.Parameters.Add("pmessnumberend", OracleDbType.Double).Value = filter.MessNumberEnd == 0 ? DBNull.Value : filter.MessNumberEnd;
                cmd.Parameters.Add("pmessreason", OracleDbType.Double).Value = filter.Reason == null ? DBNull.Value : filter.Reason.Code;
                cmd.Parameters.Add("pmessoperationstatus", OracleDbType.Double).Value = filter.OperationStatus == null ? DBNull.Value : filter.OperationStatus.Code; ;
                cmd.Parameters.Add("poperationnumber", OracleDbType.Varchar2).Value = filter.OperationNumber == null ? DBNull.Value : filter.OperationNumber.Code.ToString();
                cmd.Parameters.Add("pidtypeoperation", OracleDbType.Double).Value = filter.OperationType == null ? DBNull.Value : filter.OperationType.Code;
                cmd.Parameters.Add("pidviewoperation", OracleDbType.Double).Value = filter.ViewOperation == null ? DBNull.Value : filter.ViewOperation.Code;
                cmd.Parameters.Add("pcurrencycode", OracleDbType.Double).Value = filter.Currency == null ? DBNull.Value : filter.Currency.Code;
                cmd.Parameters.Add("pamountcurrencybegin", OracleDbType.Double).Value = filter.AmountCurrencyBegin == 0 ? DBNull.Value : filter.AmountCurrencyBegin;
                cmd.Parameters.Add("pamountcurrencyend", OracleDbType.Double).Value = filter.AmountCurrencyEnd == 0 ? DBNull.Value : filter.AmountCurrencyEnd;
                cmd.Parameters.Add("pamountcurrencytengebegin", OracleDbType.Double).Value = filter.AmountCurrencyTengeBegin == 0 ? DBNull.Value : filter.AmountCurrencyTengeBegin;
                cmd.Parameters.Add("pamountcurrencytengeend", OracleDbType.Double).Value = filter.AmountCurrencyTengeEnd == 0 ? DBNull.Value : filter.AmountCurrencyTengeEnd;
                cmd.Parameters.Add("prescursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    await connection.OpenAsync();
                    var reader = await cmd.ExecuteReaderAsync();
                    int rowNumber = 1;

                    while (reader.Read())
                    {
                        messages.Add(new Message()
                        {
                            RowNumber = rowNumber++,
                            Id = Convert.ToString(reader["mess_cfm_id"]),
                            ReceiveDate = IsNullObject.IsNull(reader["receive_date"]) ? null : Convert.ToDateTime(reader["receive_date"]),
                            CFMCode = Convert.ToString(reader["cfmcode"]),
                            OperationTypeID = Convert.ToString(reader["idtypeoperation"]),
                            OperationViewID = Convert.ToString(reader["idviewoperation"]),
                            OperationNumber = Convert.ToString(reader["operationnumber"]),
                            CurrencyCode = Convert.ToString(reader["currencycode"]),
                            CurrencyName = Convert.ToString(reader["currencyname"]),
                            AmountCurrency = IsNullObject.IsNull(reader["amountcurrency"]) ? null : Convert.ToDecimal(reader["amountcurrency"]),
                            AmountCurrencyTenge = IsNullObject.IsNull(reader["amountcurrencytenge"]) ? null : Convert.ToDecimal(reader["amountcurrencytenge"]),
                            DocOperationName = Convert.ToString(reader["docoperationname"]),
                            DocOperationNumber = Convert.ToString(reader["docoperationnumber"]),
                            MessageDate = IsNullObject.IsNull(reader["messdate"]) ? null : Convert.ToDateTime(reader["messdate"]),
                            Status = Convert.ToString(reader["status"]),
                            MessageVersion = Convert.ToString(reader["version"]),
                            MessageDocumentID = Convert.ToString(reader["documentuniqueidentifier"]),
                            WorkStage = Convert.ToString(reader["workstage"]),
                            MessageType = Convert.ToString(reader["messtype"]),
                            MessageTypeName = Convert.ToString(reader["messtypename"]),
                            UpdateVersion = Convert.ToString(reader["updateversion"]),
                            DateRelease = IsNullObject.IsNull(reader["daterelease"]) ? null : Convert.ToDateTime(reader["daterelease"]),
                            Sender = Convert.ToString(reader["sender"]),
                            Receiver = Convert.ToString(reader["receiver"]),
                            MessageNumber = Convert.ToString(reader["messnumber"]),
                            MessageDocumentType = Convert.ToString(reader["messdoctype"]),
                            MessageDocumentName = Convert.ToString(reader["messdocstatname"]),
                            MessageReason = Convert.ToString(reader["messreason"]),
                            StatusName = Convert.ToString(reader["statusname"]),
                            OperationStatus = Convert.ToString(reader["operstatus"]),
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                return messages;
            }
        }

        public async Task<string> GetMessageById(string connString, double messageId)
        {
            var clobData = string.Empty;

            using (var connection = new OracleConnection(connString))
            {
                var cmd = new OracleCommand();
                cmd.Connection = connection;
                cmd.CommandText = $@"begin
                                        kfm.c_pkgconnect.popen();
                                        :result := kfm.pkg_messages_cfm.get_message(pmessid => :pmessid,
                                              pmessxml => :pmessxml,
                                              piseditable => :piseditable);
                                    end;
                                    ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("result", OracleDbType.Double).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("pmessid", OracleDbType.Double).Value = messageId;
                cmd.Parameters.Add("pmessxml", OracleDbType.Clob).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("piseditable", OracleDbType.Double).Direction = ParameterDirection.Output;

                try
                {
                    await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    clobData = (string)((OracleClob)(cmd.Parameters[2].Value)).Value;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return clobData;
        }

        public async Task<MessageModel.MessageModel> GetMessageV6ById(string connString, double messageId)
        {
            var result = new MessageModel.MessageModel();

            using (var connection = new OracleConnection(connString))
            {
                var cmd = new OracleCommand();
                cmd.Connection = connection;
                cmd.CommandText = $@"begin
                                        kfm.c_pkgconnect.popen();
                                        :result := kfm.pkg_messages_cfm.get_message(pmessid => :pmessid,
                                              pmessxml => :pmessxml,
                                              piseditable => :piseditable);
                                    end;
                                    ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("result", OracleDbType.Double).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("pmessid", OracleDbType.Double).Value = messageId;
                cmd.Parameters.Add("pmessxml", OracleDbType.Clob).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("piseditable", OracleDbType.Double).Direction = ParameterDirection.Output;

                try
                {
                    await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    var xmlData = (string)((OracleClob)(cmd.Parameters[2].Value)).Value;
                    using (TextReader sr = new StringReader(xmlData))
                    {
                        var serializer = new System.Xml.Serialization.XmlSerializer(typeof(MessageModel.MessageModel));
                        MessageModel.MessageModel response = (MessageModel.MessageModel)serializer.Deserialize(sr);
                        result = response;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return result;
        }

        public async Task<string> GetCodeDesc(string connString, Guid messageVersion, double dataCode, double codeDirct)
        {
            var result = string.Empty;

            using (var connection = new OracleConnection(connString))
            {
                var cmd = connection.CreateCommand();
                cmd.Connection = connection;
                cmd.CommandText = $@"
                                begin
                                  kfm.c_pkgconnect.popen();
                                  :result := kfm.pkg_analytic.fgetcodeshnamedirct(pversion => :pversion,
                                                                                  pdatacode => :pdatacode,
                                                                                  ncodedirct => :ncodedirct);
                                end;";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("result", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("pversion", OracleDbType.Varchar2,36).Value = messageVersion.ToString().ToUpper();
                cmd.Parameters.Add("pdatacode", OracleDbType.Int32).Value = dataCode;
                cmd.Parameters.Add("ncodedirct", OracleDbType.Int32).Value = codeDirct;

                try
                {
                    await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    result = cmd.Parameters["result"].Value.ToString();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return result;
        }
        public async Task<IEnumerable<Answer>> GetAnswer(string connString, double dataCode)
        {
            var answers = new List<Answer>();
            using (var connection = new OracleConnection(connString))
            {
                var cmd = new OracleCommand();
                cmd.Connection = connection;
                cmd.CommandText = $@"
                                begin
                                  kfm.c_pkgconnect.popen();
                                  :result := kfm.pkg_messages_cfm.get_relationmessageslist(pmessid => :pmessid,
                                                           prescursor => :prescursor,
                                                           plistid => :plistid);
                                end;";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("result", OracleDbType.Double).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("pmessid", OracleDbType.Double).Value = dataCode;
                cmd.Parameters.Add("prescursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("plistid", OracleDbType.Double).Value = 0;


                try
                {
                    await connection.OpenAsync();
                    var reader = await cmd.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        answers.Add(new Answer()
                        {
                            MessCfmId = reader["MESS_CFM_ID"].ToString(),
                            MessDate = reader["MESSDATE"].ToString(),
                            ReceiveDate = reader["RECEIVE_DATE"].ToString(),
                            Version = reader["VERSION"].ToString(),
                            DocumentUniqueIdentifier = reader["DOCUMENTUNIQUEIDENTIFIER"].ToString(),
                            Status = await GetStatus(connString, reader["STATUS"].ToString(), reader["WORKSTAGE"].ToString(), reader["MESSTYPE"].ToString())
                        });
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    cmd.Dispose();
                    await connection.CloseAsync();
                }
            }

            return answers;
        }

        public async Task<string> GetStatus(string connString, string status, string workstage, string messtype)
        {
            var result = string.Empty;

            using (var connection = new OracleConnection(connString))
            {
                var cmd = connection.CreateCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"
                                 begin
                                  kfm.c_pkgconnect.popen();
                                :result := kfm.pkg_messages_cfm.getstatusdescriptionrus(pstatus => :pstatus,
                                                          pstage => :pstage,
                                                          ptype => :ptype);
                                end;"; 
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("result", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("pstatus", OracleDbType.Double).Value = Convert.ToInt32(status);
                cmd.Parameters.Add("pstage", OracleDbType.Double).Value = Convert.ToInt32(workstage);
                cmd.Parameters.Add("ptype", OracleDbType.Double).Value = Convert.ToInt32(messtype);

                try
                {
                    await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    result = cmd.Parameters["result"].Value.ToString();
                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    cmd.Dispose();
                    await connection.CloseAsync();
                }
            }
            return result;
        }

        public async Task<string> ToNextStage(string connString, double dataCode)
        {
            var result = string.Empty;

            using (var connection = new OracleConnection(connString))
            {
                var cmd = connection.CreateCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"
                                 begin
                                  kfm.c_pkgconnect.popen();
                                :result := kfm.pkg_messages_cfm.tonextstage(pmessid => :pmessid);
                                end;"; 
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("result", OracleDbType.Double).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("pmessid", OracleDbType.Double).Value = dataCode;

                try
                {
                    await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    result = cmd.Parameters["result"].Value.ToString();
                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    cmd.Dispose();
                    await connection.CloseAsync();
                }
            }
            return result;
        }

        public async Task<string> ToPreviousStage(string connString, double messageId)
        {
            var result = string.Empty;

            using (var connection = new OracleConnection(connString))
            {
                var cmd = connection.CreateCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"
                                 begin
                                  kfm.c_pkgconnect.popen();
                                :result := kfm.pkg_messages_cfm.ToPreviousStage(pmessid => :pmessid);
                                end;";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("result", OracleDbType.Double).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("pmessid", OracleDbType.Double).Value = messageId;

                try
                {
                    await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    result = cmd.Parameters["result"].Value.ToString();
                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    cmd.Dispose();
                    await connection.CloseAsync();
                }
            }
            return result;
        }

        public async Task<string> Exclude(string connString, double messageId)
        {
            var result = string.Empty;

            using (var connection = new OracleConnection(connString))
            {
                var cmd = connection.CreateCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"
                                 begin
                                  kfm.c_pkgconnect.popen();
                                :result := kfm.pkg_messages_cfm.Exclude(pmessid => :pmessid);
                                end;";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("result", OracleDbType.Double).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("pmessid", OracleDbType.Double).Value = messageId;

                try
                {
                    await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    result = cmd.Parameters["result"].Value.ToString();
                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    cmd.Dispose();
                    await connection.CloseAsync();
                }
            }
            return result;
        }

        public async Task<string> AddAnswer(string connString, Root root)
        {
            string result = string.Empty;
            root.ResponseDateTime = DateTime.Now.ToString();
            //root.Version = "DC782CFD-A9C0-4BCA-98F9-96702270A90A";
            root.Version = await GetTypeVersion(connString, 5);
            
            root.DocumentUniqueIdentifier = await GetGuid(connString);
            string jsonString = JsonConvert.SerializeObject(root);
            XmlDocument doc = JsonConvert.DeserializeXmlNode(jsonString, "Root");
            using (var connection = new OracleConnection(connString))
            {
                var cmd = connection.CreateCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"
                        begin
                        kfm.c_pkgconnect.popen();
                        :result := kfm.pkg_messages_cfm.save_message(pmessxml => :pmessxml,
                                                        pmessid => :pmessid,
                                                        pcheckxml => :pcheckxml,
                                                        perror => :perror,
                                                        pvalidationcomplete => :pvalidationcomplete,
                                                        pvalidationresult => :pvalidationresult);
                        end;";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("result", OracleDbType.Int32).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("pmessxml", OracleDbType.Clob).Value = doc!.OuterXml;
                cmd.Parameters.Add("pmessid", OracleDbType.Int32).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("pcheckxml", OracleDbType.Clob).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("perror", OracleDbType.Int32).Value = -1;
                cmd.Parameters.Add("pvalidationcomplete", OracleDbType.Int32).Value = -1;
                cmd.Parameters.Add("pvalidationresult", OracleDbType.Clob).Value = DBNull.Value;

                try
                {
                    if (connection.State != ConnectionState.Open)
                        await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    result = cmd.Parameters["result"].Value.ToString();
                    return result;
                }
                catch (OracleException e)
                {
                    throw;
                }
                finally
                 {
                    cmd.Dispose();
                    await connection.CloseAsync();
                }
            }
        }

        public async Task<string> UpdateAnswer(string connString, double messageId, Root? root = null)
        {
            string result = string.Empty;
            string jsonString = JsonConvert.SerializeObject(root);
            XmlDocument doc = JsonConvert.DeserializeXmlNode(jsonString, "Root");
            using (var connection = new OracleConnection(connString))
            {
                //if (connection.State != ConnectionState.Open) connection.Open();
                //using var cmd = new OracleCommand("begin kfm.c_pkgconnect.popen(); end;", connection);
                //cmd.ExecuteNonQuery();

                //var @params = new OracleDynamicParameters(new
                //{
                //    pmessid = messageId,
                //    pmessxml = doc!.OuterXml
                //});

                //@params.Add("result", dbType: OracleMappingType.Int32, direction: ParameterDirection.ReturnValue);

                //await connection.QueryAsync("kfm.pkg_messages_cfm.update_message",
                //    @params, commandType: CommandType.StoredProcedure);

                var cmd = connection.CreateCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"begin
                                  kfm.c_pkgconnect.popen();
                                  :result := kfm.pkg_messages_cfm.update_message(pmessid => :pmessid,
                                                                                 pmessxml => :pmessxml);
                                end;";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("result", OracleDbType.Double).Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add("pmessid", OracleDbType.Double).Value = messageId;
                cmd.Parameters.Add("pmessxml", OracleDbType.Clob).Value = doc!.OuterXml;

                try
                {
                    if (connection.State != ConnectionState.Open)
                        await connection.OpenAsync();
                    var s = await cmd.ExecuteNonQueryAsync();
                    result = cmd.Parameters["result"].Value.ToString();
                }
                catch (OracleException e)
                {
                    throw;
                }
                finally
                {
                    cmd.Dispose();
                    await connection.CloseAsync();
                }
            }
            return result;
        }

        public async Task<string> UpdateMessage(string connString, double messageId, string xml)
        {
            var result = string.Empty;

            using (var connection = new OracleConnection(connString))
            {
                //if (connection.State != ConnectionState.Open) connection.Open();
                //using var cmd = new OracleCommand("begin kfm.c_pkgconnect.popen(); end;", connection);
                //cmd.ExecuteNonQuery();

                //var @params = new OracleDynamicParameters(new
                //{
                //    pmessid = dataCode,
                //    pmessxml = doc!.OuterXml
                //});

                //@params.Add("result", dbType: OracleMappingType.Int32, direction: ParameterDirection.ReturnValue);

                //await connection.QueryAsync("kfm.pkg_messages_cfm.update_message",
                //    @params, commandType: CommandType.StoredProcedure);

                var cmd = connection.CreateCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"begin
                                  kfm.c_pkgconnect.popen();
                                  :result := kfm.pkg_messages_cfm.update_message(pmessid => :pmessid,
                                                                                 pmessxml => :pmessxml);
                                end;";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("result", OracleDbType.Double).Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add("pmessid", OracleDbType.Double).Value = messageId;
                cmd.Parameters.Add("pmessxml", OracleDbType.Clob).Value = xml;

                try
                {
                    if (connection.State != ConnectionState.Open)
                        await connection.OpenAsync();
                    var s = await cmd.ExecuteNonQueryAsync();
                    result = cmd.Parameters["result"].Value.ToString();
                }
                catch (OracleException e)
                {
                    throw;
                }
                finally
                {
                    cmd.Dispose();
                    await connection.CloseAsync();
                }
            }

            return result;
        }
        public async Task<Root> GetMessageByIdJson(string connString, double messageId)
        {
            using (var connection = new OracleConnection(connString))
            {
                var cmd = new OracleCommand();
                cmd.Connection = connection;
                cmd.CommandText = $@"begin
                                        kfm.c_pkgconnect.popen();
                                        :result := kfm.pkg_messages_cfm.get_message(pmessid => :pmessid,
                                              pmessxml => :pmessxml,
                                              piseditable => :piseditable);
                                    end;
                                    ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("result", OracleDbType.Double).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("pmessid", OracleDbType.Double).Value = messageId;
                cmd.Parameters.Add("pmessxml", OracleDbType.Clob).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("piseditable", OracleDbType.Double).Direction = ParameterDirection.Output;

                try
                {
                    await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    string clobData = (string)((OracleClob)(cmd.Parameters[2].Value)).Value;


                    return JsonConvert.DeserializeObject<Root>(MessageConverter.GetXmlNodeValue(clobData));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public async Task<string> SendMessages(string connString, List<double> messagesId)
        {
            foreach (var messageId in messagesId)
            {
                string xmlStr = await GetMessageById(connString, messageId);

                var signXML = signXMLRepository.SignXMLKalKan(xmlStr, configuration.GetValue<string>("Cert:CertPass"), configuration.GetValue<string>("Cert:CertPath"));

                double documentType = await GetMessageTypeById(connString, messageId);

                string fileName = "";
                if (documentType.Equals(1)) fileName = "doc.";
                else if (documentType.Equals(5)) fileName = "UponDocInfo.";

                string filePath = configuration.GetValue<string>("FastiOutPath") + $"{fileName + Guid.NewGuid()}.xml";
                signXML.Save(filePath);
            }
            return string.Empty;
        }

        public async Task<string> GetError(string connString, double errorCode)
        {
            using (var connection = new OracleConnection(connString))
            {
                var cmd = new OracleCommand();
                cmd.Connection = connection;
                cmd.CommandText = $@"begin
                                        kfm.c_pkgconnect.popen();
                                            kfm.pkg_main.geterror(perrorcode => :perrorcode,
                                            perrorname => :perrorname,
                                            perrordescription => :perrordescription,
                                            pstatus => :pstatus);
                                    end;
                                    ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("perrorcode", OracleDbType.Double).Value = errorCode;
                cmd.Parameters.Add("perrorname", OracleDbType.NVarchar2, 2000).Direction = ParameterDirection.Output; 
                cmd.Parameters.Add("perrordescription", OracleDbType.NVarchar2, 2000).Direction = ParameterDirection.Output; 
                cmd.Parameters.Add("pstatus", OracleDbType.Double).Direction = ParameterDirection.Output; 
                try
                {
                    if (connection.State != ConnectionState.Open)
                        await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                     
                    return cmd.Parameters["perrordescription"].Value.ToString();
                }
                catch (OracleException e)
                {
                    throw;
                }
                finally
                {
                    cmd.Dispose();
                    await connection.CloseAsync();
                }

            }
        }

        public async Task<MessageFormInfo> GetMessageFormInfo(string connString, double pmessid)
        {
            using (var connection = new OracleConnection(connString))
            {
                var cmd = new OracleCommand();
                cmd.Connection = connection;
                cmd.CommandText = $@"begin
                                        kfm.c_pkgconnect.popen();
                                        :result := kfm.pkg_messages_cfm.get_messageforminfo(pmessid => :pmessid,
                                                      prescursor => :prescursor);
                                    end;
                                    ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("result", OracleDbType.Double).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("pmessid", OracleDbType.Double).Value = pmessid;
                cmd.Parameters.Add("prescursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    if (connection.State != ConnectionState.Open)
                        await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    var refCursor = (OracleRefCursor)cmd.Parameters["prescursor"].Value;
                    var messageFormInfos = new MessageFormInfo();

                    using (var reader = refCursor.GetDataReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            var messageFormInfo = new MessageFormInfo
                            {
                                MessCfmId = reader.IsDBNull(reader.GetOrdinal("MESS_CFM_ID")) ? null : reader["MESS_CFM_ID"].ToString(),
                                ReceiveDate = reader.IsDBNull(reader.GetOrdinal("RECEIVE_DATE")) ? null : reader["RECEIVE_DATE"].ToString(),
                                MessDate = reader.IsDBNull(reader.GetOrdinal("MESSDATE")) ? null : reader["MESSDATE"].ToString(),
                                MessType = reader.IsDBNull(reader.GetOrdinal("MESSTYPE")) ? null : reader["MESSTYPE"].ToString(),
                                ParentMessId = reader.IsDBNull(reader.GetOrdinal("PARENTMESSID")) ? null : reader["PARENTMESSID"].ToString(),
                                MessVersion = reader.IsDBNull(reader.GetOrdinal("MESS_VERSION")) ? null : reader["MESS_VERSION"].ToString(),
                                MessDocId = reader.IsDBNull(reader.GetOrdinal("MESS_DOCID")) ? null : reader["MESS_DOCID"].ToString(),
                                ParentMessDocId = reader.IsDBNull(reader.GetOrdinal("PRMESS_DOCID")) ? null : reader["PRMESS_DOCID"].ToString(),
                                NMessNumber = reader.IsDBNull(reader.GetOrdinal("NMESSNUMBER")) ? null : reader["NMESSNUMBER"].ToString(),
                                NLastModifyDate = reader.IsDBNull(reader.GetOrdinal("NLASTMODIFYDATE")) ? null : reader["NLASTMODIFYDATE"].ToString(),
                                Ncomment = reader.IsDBNull(reader.GetOrdinal("NCOMMENT")) ? null : reader["NCOMMENT"].ToString(),
                                NResponseDateTime = reader.IsDBNull(reader.GetOrdinal("NRESPONSEDATETIME")) ? null : reader["NRESPONSEDATETIME"].ToString(),
                                NRequestDateTime = reader.IsDBNull(reader.GetOrdinal("NREQUESTDATETIME")) ? null : reader["NREQUESTDATETIME"].ToString(),
                            };
                            messageFormInfos = messageFormInfo;
                        }
                    }

                    return messageFormInfos;
                }
                catch (OracleException e)
                {
                    throw;
                }
                finally
                {
                    cmd.Dispose();
                    await connection.CloseAsync();
                }
            }
        }

        private async Task<string> GetGuid(string connString)
        {
            using (var conn = new OracleConnection(connString))
            {
                await conn.OpenAsync();
                var query = @"select 
                to_char(substr(sys_guid(),1,8)||'-'||substr(sys_guid(),9,4)||'-'||substr(sys_guid(),13,4)||'-'||substr(sys_guid(),17,4)||'-'||substr(sys_guid(),21)) 
                from sys.dual";
                var result = await conn.ExecuteScalarAsync<string>(query);
                return result.ToString();
            }
        }

        private async Task<string> GetTypeVersion(string connString, double ptype)
        {
            using (var connection = new OracleConnection(connString))
            {
                var cmd = connection.CreateCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"begin
                                  kfm.c_pkgconnect.popen();
                                  :result := kfm.pkg_messages_cfm.get_typeversion(ptype => :ptype);
                                end;";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("result", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add("ptype", OracleDbType.Double).Value = ptype;


                try
                {
                    if (connection.State != ConnectionState.Open)
                        await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return cmd.Parameters["result"].Value.ToString();
                }
                catch (OracleException e)
                {
                    throw;
                }
                finally
                {
                    cmd.Dispose();
                    await connection.CloseAsync();
                }
            }

        }

        public async Task<double> GetMessageTypeById(string connString, double messageId)
        {
            double result;

            using (var connection = new OracleConnection(connString))
            {
                try
                {
                    if (connection.State != ConnectionState.Open) connection.Open();
                    using var cmd = new OracleCommand("begin kfm.c_pkgconnect.popen(); end;", connection);
                    cmd.ExecuteNonQuery();

                    var @params = new OracleDynamicParameters(new
                    {
                        pmessid = messageId,
                    });

                    @params.Add("result", dbType: OracleMappingType.Int32, direction: ParameterDirection.ReturnValue);

                    await connection.QueryAsync("kfm.pkg_messages_cfm.getmessagetype",
                        @params, commandType: CommandType.StoredProcedure);

                    result = @params.Get<double>("result");
                }
                catch (OracleException e)
                {
                    throw e;
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }

            return result;
        }

        public async Task<IEnumerable<MessageHistory>> GetRelationMessagesTree(string connString, double messageId)
        {
            using (var connection = new OracleConnection(connString))
            {
                var cmd = new OracleCommand();
                cmd.Connection = connection;
                cmd.CommandText = $@"begin
                                        kfm.c_pkgconnect.popen();
                                        :result := kfm.pkg_messages_cfm.get_relationmessagestree(pmessid => :pmessid,
                                                           prescursor => :prescursor,
                                                           plistid => :plistid);
                                    end;
                                    ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("result", OracleDbType.Double).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("pmessid", OracleDbType.Double).Value = messageId;
                cmd.Parameters.Add("prescursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("plistid", OracleDbType.Double).Direction = ParameterDirection.Output;
                try
                {
                    if (connection.State != ConnectionState.Open)
                        await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    var refCursor = (OracleRefCursor)cmd.Parameters["prescursor"].Value;
                    var messageHistories = new List<MessageHistory>();

                    using (var reader = refCursor.GetDataReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            var messageHistory = new MessageHistory
                            {
                                MessCfmId = reader.IsDBNull(reader.GetOrdinal("MESS_CFM_ID")) ? null : reader["MESS_CFM_ID"].ToString(),
                                ReceiveDate = reader.IsDBNull(reader.GetOrdinal("RECEIVE_DATE")) ? null : reader["RECEIVE_DATE"].ToString(),
                                MessDate = reader.IsDBNull(reader.GetOrdinal("MESSDATE")) ? null : reader["MESSDATE"].ToString(),
                                MessType = reader.IsDBNull(reader.GetOrdinal("MESSTYPE")) ? null : reader["MESSTYPE"].ToString(),
                                ParentMessId = reader.IsDBNull(reader.GetOrdinal("PARENTMESSID")) ? null : reader["PARENTMESSID"].ToString(),
                                Level = reader.IsDBNull(reader.GetOrdinal("LEVEL")) ? null : reader["LEVEL"].ToString(),
                            };
                            messageHistories.Add(messageHistory);
                        }
                    }

                    return messageHistories;
                }
                catch (OracleException e)
                {
                    throw;
                }
                finally
                {
                    cmd.Dispose();
                    await connection.CloseAsync();
                }

            }
        }

        public async Task<string> SaveMessage(string connString)
        {
            string result = "";
            string folderPath = configuration.GetValue<string>("FastiInPath") ?? "";

            try
            {
                string[] xmlFiles = Directory.GetFiles(folderPath, "*.xml");

                foreach (string filePath in xmlFiles)
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(filePath);

                    XmlNode desiredNode = xmlDoc.SelectSingleNode("/ExportData/SignedData/Data");

                    if (desiredNode != null)
                    {
                        using (var connection = new OracleConnection(connString))
                        {
                            var cmd = connection.CreateCommand();
                            cmd.Connection = connection;
                            cmd.CommandText = @"
                                    begin
                                    kfm.c_pkgconnect.popen();
                                    :result := kfm.pkg_messages_cfm.save_message(pmessxml => :pmessxml,
                                                                    pmessid => :pmessid,
                                                                    pcheckxml => :pcheckxml,
                                                                    perror => :perror,
                                                                    pvalidationcomplete => :pvalidationcomplete,
                                                                    pvalidationresult => :pvalidationresult);
                                    end;";
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add("result", OracleDbType.Int32).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add("pmessxml", OracleDbType.Clob).Value = desiredNode.InnerXml;
                            cmd.Parameters.Add("pmessid", OracleDbType.Int32).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add("pcheckxml", OracleDbType.Clob).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add("perror", OracleDbType.Int32).Value = -1;
                            cmd.Parameters.Add("pvalidationcomplete", OracleDbType.Int32).Value = -1;
                            cmd.Parameters.Add("pvalidationresult", OracleDbType.Clob).Value = DBNull.Value;

                            try
                            {
                                if (connection.State != ConnectionState.Open)
                                    await connection.OpenAsync();
                                await cmd.ExecuteNonQueryAsync();
                                result = cmd.Parameters["result"].Value.ToString();
                                if(result != "0")
                                {
                                    result = await GetError(connString, Convert.ToDouble(result));
                                }
                            }
                            catch (OracleException e)
                            {
                                throw e;
                            }
                            finally
                            {
                                cmd.Dispose();
                                await connection.CloseAsync();
                                File.Delete(filePath);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"The specified node was not found in file: {filePath}");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return "filePath";
        }
    }
}
