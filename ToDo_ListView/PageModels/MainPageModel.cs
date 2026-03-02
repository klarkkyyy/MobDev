using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ToDoMaui_Listview;

namespace ToDo_ListView.PageModels
{
    public class MainPageModel : INotifyPropertyChanged
    {
        public ObservableCollection<ToDoClass> ToDoItems { get; set; } = new();

        private string _today = DateTime.Now.ToString("dddd, MMM d");
        public string Today
        {
            get => _today;
            set { _today = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}