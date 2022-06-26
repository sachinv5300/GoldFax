using GoldFax.Model;
using GoldFax.ViewModel;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoldFax.Views
{
   
    public delegate Point GetDragDropPosition(IInputElement theElement);
    public partial class BookTransactionView : MetroWindow
    {
        int prevRowIndex = -1;
        public BookTransactionView()
        {
            InitializeComponent();
            this.DataContext = new BookTransactionViewModel();
            this.dgBookTrasaction.PreviewMouseLeftButtonDown +=
               new MouseButtonEventHandler(dgBookTrasactionPreviewMouseLeftButtonDown);
            //The Drop Event
            this.dgBookTrasaction.Drop += new DragEventHandler(dgBookTrasactionDrop);
        }
       
        void dgBookTrasactionDrop(object sender, DragEventArgs e)
        {
            if (prevRowIndex < 0)
                return;

            int index = this.GetDataGridItemCurrentRowIndex(e.GetPosition);
                       
            if (index < 0)
                return;
          if (index == prevRowIndex)
                return;           
            if (index == dgBookTrasaction.Items.Count - 1)
            {
                MessageBox.Show("Drop point not proper");
                return;
            }
            ObservableCollection<BookTransaction>  objDataSource = (ObservableCollection<BookTransaction>)dgBookTrasaction.ItemsSource;

            BookTransaction objBookTransaction = objDataSource[prevRowIndex];
            objDataSource.RemoveAt(prevRowIndex);

            objDataSource.Insert(index, objBookTransaction);
        }

        void dgBookTrasactionPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            prevRowIndex = GetDataGridItemCurrentRowIndex(e.GetPosition);

            if (prevRowIndex < 0)
                return;
            dgBookTrasaction.SelectedIndex = prevRowIndex;

            BookTransaction selectedBookTransaction = dgBookTrasaction.Items[prevRowIndex] as BookTransaction;

            if (selectedBookTransaction == null)
                return;            
            DragDropEffects dragdropeffects = DragDropEffects.Move;

            if (DragDrop.DoDragDrop(dgBookTrasaction, selectedBookTransaction, dragdropeffects)
                                != DragDropEffects.None)
            {               
                dgBookTrasaction.SelectedItem = selectedBookTransaction;
            }
        }
      
        private bool IsTheMouseOnTargetRow(Visual theTarget, GetDragDropPosition pos)
        {
            Rect posBounds = VisualTreeHelper.GetDescendantBounds(theTarget);
            Point theMousePos = pos((IInputElement)theTarget);
            return posBounds.Contains(theMousePos);
        }
        private DataGridRow GetDataGridRowItem(int index)
        {
            if (dgBookTrasaction.ItemContainerGenerator.Status
                    != GeneratorStatus.ContainersGenerated)
                return null;
            return dgBookTrasaction.ItemContainerGenerator.ContainerFromIndex(index)
                                                           as DataGridRow;
        }
      
        private int GetDataGridItemCurrentRowIndex(GetDragDropPosition pos)
        {
            int curIndex = -1;
            for (int i = 0; i < dgBookTrasaction.Items.Count; i++)
            {
                DataGridRow itm = GetDataGridRowItem(i);
                if (IsTheMouseOnTargetRow(itm, pos))
                {
                    curIndex = i;
                    break;
                }
            }
            return curIndex;
        }
    }
}
