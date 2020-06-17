using System;
using System.ComponentModel;
using System.Windows;
using WPF_TaskList.Models;
using WPF_TaskList.Services;

namespace WPF_TaskList.ViewModels
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private BindingList<TaskModel> _taskListData;

        public BindingList<TaskModel> TaskListData
        {
            get { return _taskListData; }
            set
            {
                _taskListData = value;
                OnPropertyChanged();
            }
        }

        private readonly FileIOService _fileIOService;

        private readonly string PATH = $"{Environment.CurrentDirectory}\\taskListData.json";

        public ViewModel()
        {
            _fileIOService = new FileIOService(PATH);

            try
            {
                _taskListData = _fileIOService.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }
            _taskListData.ListChanged += TaskListData_ListChanged;
        }

        private void TaskListData_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                _fileIOService.SaveData(sender);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}