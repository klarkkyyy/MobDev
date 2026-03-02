namespace ToDoMaui_Listview;

using System.ComponentModel;
using System.Runtime.CompilerServices;

public class ToDoClass : INotifyPropertyChanged
{
    private static int _nextId = 1;

    int _id;
    string _title = string.Empty;
    string _detail = string.Empty;

    public ToDoClass()
    {
        _id = _nextId++;
    }

    public int id
    {
        get => _id;
        set { _id = value; OnPropertyChanged(); }
    }

    public string title
    {
        get => _title;
        set { _title = value; OnPropertyChanged(); }
    }

    public string detail
    {
        get => _detail;
        set { _detail = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}