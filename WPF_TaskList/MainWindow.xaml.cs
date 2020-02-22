using System.Windows;
using WPF_TaskList.ViewModels;

namespace WPF_TaskList
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
    }
}
