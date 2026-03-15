using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ToDoApplication.Models
{
    public class ToDoClass : INotifyPropertyChanged
    {
        int _item_id;
        string _item_name;
        string _item_description;
        string _status;
        int _user_id;

        public int item_id
        {
            get { return _item_id; }
            set { _item_id = value; OnPropertyChanged(); }
        }

        public string item_name
        {
            get { return _item_name; }
            set { _item_name = value; OnPropertyChanged(); }
        }

        public string item_description
        {
            get { return _item_description; }
            set { _item_description = value; OnPropertyChanged(); }
        }

        public string status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged(); }
        }

        // Helper boolean property for UI binding
        public bool IsCompleted
        {
            get => string.Equals(_status, "completed", StringComparison.OrdinalIgnoreCase);
            set
            {
                var newStatus = value ? "completed" : "todo";
                if (_status != newStatus)
                {
                    _status = newStatus;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsCompleted));
                }
            }
        }

        public int user_id
        {
            get { return _user_id; }
            set { _user_id = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}