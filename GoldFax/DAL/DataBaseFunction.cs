using GoldFax.Model;
using GoldFax.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldFax.DAL
{
    internal class DataBaseFunction
    {
        public IEnumerable<BookTransaction> GetBTCollection()
        {
            IEnumerable<BookTransaction> DataSource = null;
            try
            {
                GoldDB objGoldDB = GoldDB.GetobjGoldDB;
                DataTable dt = objGoldDB.GetDataTable("select ID,isnull(BookName,'') as BookName, BorrowedDate,DeliveredDate from BookTransaction with(nolock)");

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataSource = dt.AsEnumerable().Select(data => new BookTransaction()
                    {
                        ID = Convert.ToInt32(data["ID"]),
                        BookName = data["BookName"].ToString(),
                        BorrowedDate = Convert.ToDateTime(data["BorrowedDate"]).ToShortDateString(),
                        DeliveredDate = Convert.ToDateTime(data["DeliveredDate"]).ToShortDateString()
                    });

                }
            }
            catch (Exception ex)
            {
                GoldLog.LoggingException("GetBTCollection", "DataBaseFunction", ex);
            }
            return DataSource;
        }
    }
}
