using System;
using System.ComponentModel;
using System.Windows;
using WPF_TaskList.Models;
using WPF_TaskList.Services;

namespace WPF_TaskList
{
    public partial class MainWindow : Window
    {
        private BindingList<TaskModel> _taskListData;

        private FileIOService _fileIOService;

        private readonly string PATH = $"{Environment.CurrentDirectory}\\taskListData.json";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOService = new FileIOService(PATH);

            try
            {
                _taskListData = _fileIOService.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            //_taskListData = new BindingList<TaskModel>()
            //{
            //    new TaskModel() {TaskText = "test1"},
            //    new TaskModel() {TaskText = "test2", IsChecked = true}
            //};
           
            dgTaskList.ItemsSource = _taskListData;
            _taskListData.ListChanged += _taskListData_ListChanged;
        }

        private void _taskListData_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _fileIOService.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }
    }
}
