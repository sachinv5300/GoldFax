using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldFax.DAL;
using GoldFax.Model;
using GoldFax.Repository;

namespace GoldFax.ViewModel
{
    internal class BookTransactionViewModel : ViewModelBase
    {
        #region Properties

        private int _id;
        /// <summary>
        /// Transaction ID
        /// </summary>    
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _bookname;
        /// <summary>
        /// Book Name 
        /// </summary>
        public string BookName
        {
            get { return _bookname; }
            set
            {
                _bookname = value;
                OnPropertyChanged(nameof(BookName));
            }
        }

        private string _borroweddate;
        /// <summary>
        /// Book Borrowed Date 
        /// </summary>       
        public string BorrowedDate
        {
            get { return _borroweddate; }
            set
            {
                _borroweddate = value;
                OnPropertyChanged(nameof(BorrowedDate));
            }
        }

        private string _delivereddate;
        /// <summary>
        /// Book Delivered Date 
        /// </summary>
        public string DeliveredDate
        {
            get { return _delivereddate; }
            set
            {
                _delivereddate = value;
                OnPropertyChanged(nameof(DeliveredDate));
            }
        }

        private IEnumerable<BookTransaction> _booktransdatasource;
        /// <summary>
        /// All Trasaction Collection 
        /// </summary>
        public IEnumerable<BookTransaction> BooktransDatasource
        {
            get { return _booktransdatasource; }
            set
            {
                _booktransdatasource = value;
                OnPropertyChanged(nameof(BooktransDatasource));
            }
        }

        private BookTransaction _booktransselectedItem;
        /// <summary>
        /// one selected Item of Trasaction
        /// </summary>    
        public BookTransaction BooktransSelectedItem
        {
            get { return _booktransselectedItem; }
            set
            {
                _booktransselectedItem = value;
                OnPropertyChanged(nameof(BooktransSelectedItem));
                getSelectedRow();
            }
        }
        #endregion

        public BookTransactionViewModel()
        {
            getAllTrasaction();
        }
        #region Functions
        /// <summary>
        /// Method get All details
        /// </summary>  
        void getAllTrasaction()
        {
            DataBaseFunction objdbfun = new DataBaseFunction();
            BooktransDatasource = objdbfun.GetBTCollection();
        }

        /// <summary>
        /// Method get Show record in controls
        /// </summary>  
        void getSelectedRow()
        {
            try
            {
                if (BooktransSelectedItem != null)
                {
                    Id = BooktransSelectedItem.ID;
                    BookName = BooktransSelectedItem.BookName;
                    BorrowedDate = BooktransSelectedItem.BorrowedDate;
                    DeliveredDate = BooktransSelectedItem.DeliveredDate;
                }
                else
                {
                    Id = 0;
                    BookName = String.Empty;
                }

            }
            catch (Exception ex)
            {
                GoldLog.LoggingException("GetBTCollection", "BookTransactionViewModel", ex);

            }
        }
        #endregion
    }
}
