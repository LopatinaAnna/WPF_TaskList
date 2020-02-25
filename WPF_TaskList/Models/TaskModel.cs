using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace WPF_TaskList.Models
{
    class TaskModel : INotifyPropertyChanged
    {
        private string _deadline = DateTime.Now.ToString("dd/MM/yyyy");

        private bool _isChecked;

        private string _taskText;

        [JsonProperty(PropertyName = "deadline")]
        public string Deadline
        {
            get { return _deadline; }
            set
            {
                if (_deadline == value)
                    return;
                _deadline = value;
                OnPropertyChanged("Deadline");
            }
        }

        [JsonProperty(PropertyName = "isChecked")]
        public bool IsChecked
        {
            get { return _isChecked; }
            set 
            {
                if (_isChecked == value)
                    return;
                _isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }

        [JsonProperty(PropertyName = "taskText")]
        public string TaskText
        {
            get { return _taskText; }
            set
            {
                if (_taskText == value)
                    return;
                _taskText = value;
                OnPropertyChanged("TaskText");
             }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
