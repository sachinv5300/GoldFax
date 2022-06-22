using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldFax.Model
{
    internal class BookTransaction
    {
        /// <summary>
        /// This properties are used to bind column in datagrid
        /// </summary>  
        public int ID { get; set; }
        public string BookName { get; set; }
        public string BorrowedDate { get; set; }
        public string DeliveredDate { get; set; }

    }
}
