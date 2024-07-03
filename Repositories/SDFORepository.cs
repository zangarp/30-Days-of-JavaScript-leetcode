using System.Data;
using Dapper.Oracle;
using System.Data.Common;
using FinOpsAPI.Helpers;
using FinOpsAPI.Interfaces;
using FinOpsAPI.Models;
using FinOpsAPI.Models.Employee;
using Oracle.ManagedDataAccess.Client;
using Dapper;

namespace FinOpsAPI.Repositories
{
    public class SDFORepository : ISDFORepository
    {
        public async Task<double> GetUserGroupRole(string sdfoConnectionString)
        {
            using (var connection = new OracleConnection(sdfoConnectionString))
            {
                var cmd = new OracleCommand();
                cmd.Connection = connection;
                cmd.CommandText = $@"begin
                                      :result := kfm.pkg_users.getusersrolesgroup(prolesgroup => :prolesgroup);
                                    end;
                                    ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("result", OracleDbType.Double).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("prolesgroup", OracleDbType.Double).Direction = ParameterDirection.Output;
                try
                {
                    await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    var result = cmd.Parameters["result"].Value.ToString();
                    if (Convert.ToDouble(result) == 0)
                    {
                        var prolesgroup = cmd.Parameters["prolesgroup"].Value.ToString();
                        return Convert.ToDouble(prolesgroup);
                    }
                        
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return -1;
        }

        public async Task<IEnumerable<Handbook>> GetHandbook(string sdfoConnectionString, int handbookCode)
        {
            var handbook = new List<Handbook>();
            using (var connection = new OracleConnection(sdfoConnectionString))
            {
                var cmd = new OracleCommand();
                cmd.Connection = connection;
                cmd.CommandText = $@"begin
                                        kfm.c_pkgconnect.popen();
                                      :result := kfm.pkg_analytic.getanalyticcodesinfo(panalytictype => :panalytictype,
                                                                                       pcodeslisttype => :pcodeslisttype,
                                                                                       prescursor => :prescursor);
                                    end;
                                    ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("result", OracleDbType.Double).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("panalytictype", OracleDbType.Double).Value = handbookCode;
                cmd.Parameters.Add("pcodeslisttype", OracleDbType.Double).Value = 1;
                cmd.Parameters.Add("prescursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    await connection.OpenAsync();
                    var reader = await cmd.ExecuteReaderAsync();

                    while (reader.Read())
                    {
                        handbook.Add(new Handbook()
                        {
                            Code = reader["analyticcode"].ToString()!,
                            ShortName = reader["shortname"].ToString(),
                            Name = reader["name"].ToString(),
                            IsEnabled = Convert.ToBoolean(reader["isenabled"])
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return handbook;
        }

        public async Task<IEnumerable<Handbook>> GetHandbookWithVersion(string sdfoConnectionString, int dataCode, Guid messageVersion)
        {
            var handbook = new List<Handbook>();
            using (var connection = new OracleConnection(sdfoConnectionString))
            {
                var cmd = new OracleCommand();
                cmd.Connection = connection;
                cmd.CommandText = $@"begin
                                      kfm.c_pkgconnect.popen();
                                      :result := kfm.pkg_analytic.fgetshnamedirct(pversion => :pversion,
                                                                                  pdatacode => :pdatacode,
                                                                                  prescursor => :prescursor);
                                    end;";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("result", OracleDbType.Double).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("pversion", OracleDbType.Varchar2, 1000).Value = messageVersion.ToString().ToUpper();
                cmd.Parameters.Add("pdatacode", OracleDbType.Double).Value = dataCode;
                cmd.Parameters.Add("prescursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    await connection.OpenAsync();
                    var reader = await cmd.ExecuteReaderAsync();

                    while (reader.Read())
                    {
                        handbook.Add(new Handbook()
                        {
                            Code = reader["analyticcode"].ToString()!,
                            ShortName = reader["shortname"].ToString(),
                            Name = reader["name"].ToString(),
                            IsEnabled = Convert.ToBoolean(reader["isenabled"])
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return handbook;
        }

        public async Task<IEnumerable<Field>> GetFields(string sdfoConnectionString, Guid messageVersion)
        {
            var fields = new List<Field>();
            using (var connection = new OracleConnection(sdfoConnectionString))
            {
                var cmd = new OracleCommand();
                cmd.Connection = connection;
                cmd.CommandText = $@"select t.ID, nvl(t.Datacode, 0) Datacode from DOCUMENT_FIELD t where t.versioncode = '{messageVersion.ToString().ToUpper()}'";

                try
                {
                    await connection.OpenAsync();
                    var reader = await cmd.ExecuteReaderAsync();

                    while (reader.Read())
                    {
                        fields.Add(new Field()
                        {
                            Id = Convert.ToString(reader["id"]),
                            Datacode = Convert.ToInt32(reader["datacode"]),
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }

            return fields;
        }
        
        public async Task<Employee> GetEmployeeeAsync(string sdfoConnectionString, string userLogin)
        {
            var result = new Employee();

            using (var connection = new OracleConnection(sdfoConnectionString))
            {
                try
                {
                    var cmd = new OracleCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = $@"begin
                                      kfm.c_pkgconnect.popen();
                                      :result := kfm.pkg_users.getuserbylogin(puserlogin => :puserlogin,
                                                puserdatafull => :puserdatafull);

                                    end;";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("result", OracleDbType.Double).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("puserlogin", OracleDbType.Varchar2, 1000).Value = userLogin;
                    cmd.Parameters.Add("puserdatafull", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    if(connection.State != ConnectionState.Open) await connection.OpenAsync();

                    var reader = await cmd.ExecuteReaderAsync();

                    if (await reader.ReadAsync())
                    {
                        result = new Employee()
                        {
                            UserId = Convert.ToInt32(reader.GetValue("userid")),
                            FullName = reader.GetValue("lastname").ToString() + " " + reader.GetValue("firstname").ToString() +
                                        (!string.IsNullOrEmpty(reader.GetValue("middlename").ToString()) ? (" " + reader.GetValue("middlename").ToString()) : ""),
                        };
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

            return result;

        }
    }
}
