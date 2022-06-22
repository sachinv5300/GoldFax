using GoldFax.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace GoldFax.DAL
{
    /// <summary>
    /// Used singleton pattern for only one object throught the class
    /// </summary>
    public sealed class GoldDB
    {

        public static readonly string DBString = string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["DbConnectionString"]) ? "" : System.Configuration.ConfigurationManager.AppSettings["DbConnectionString"];

        private GoldDB() { }
        private static GoldDB obj = null;
        public static GoldDB GetobjGoldDB
        {
            get
            {
                if (obj == null)
                {
                    obj = new GoldDB();
                }
                return obj;
            }
        }


        public DataTable GetDataTable(string query)
        {

            DataTable DTable = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(DBString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(DTable);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                GoldLog.LoggingException("GetDataTable", "GoldDB", ex);
            }
            finally
            {

            }
            return DTable;

        }
    }
}
