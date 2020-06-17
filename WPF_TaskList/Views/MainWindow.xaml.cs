using System.Windows;
using System.Windows.Input;
using WPF_TaskList.ViewModels;

namespace WPF_TaskList.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }

        private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete && !isBeingEdited)
            {
                if (MessageBox.Show("Do you want to delete it?", "Confirm delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    dgTaskList.CanUserDeleteRows = true;
                }
                else
                {
                    dgTaskList.CanUserDeleteRows = false;
                }
            }
        }

        private bool isBeingEdited;

        private void BeginningEdit(object sender, System.Windows.Controls.DataGridBeginningEditEventArgs e)
        {
            isBeingEdited = true;
        }

        private void CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {
            isBeingEdited = false;
        }
    }
}