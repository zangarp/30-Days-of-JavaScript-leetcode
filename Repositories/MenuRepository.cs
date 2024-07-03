using System.Data;
using FinOpsAPI.Interfaces;
using FinOpsAPI.Models;
using Oracle.ManagedDataAccess.Client;

namespace FinOpsAPI.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        public async Task<IEnumerable<Menu>> GetMenu(string connectionString, double usersRolesGroup)
        {
            var menuList = new List<Menu>();
            using (var connection = new OracleConnection(connectionString))
            {
                var cmd = new OracleCommand();
                cmd.Connection = connection;
                cmd.CommandText = $@"begin
                                      kfm.c_pkgconnect.popen();
                                      :result := kfm.pkg_messages_cfm.get_messagestypeslist(prolesgroup => :prolesgroup,
                                                                                            prescursor => :prescursor);
                                    end;
                                    ";
                cmd.Parameters.Add("result", OracleDbType.Double).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("prolesgroup", OracleDbType.Double).Value = usersRolesGroup; //Change
                cmd.Parameters.Add("prescursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    await connection.OpenAsync();
                    var reader = await cmd.ExecuteReaderAsync();
                    
                    while (reader.Read())
                    {
                        menuList.Add(
                            new Menu()
                            {
                                ListName = reader["listname"].ToString(), 
                                ListNum = Convert.ToInt32(reader["listnum"])
                            });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return menuList;
        }
    }
}
