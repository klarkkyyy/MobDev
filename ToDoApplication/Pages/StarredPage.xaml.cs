namespace ToDoApplication.Pages;

public partial class StarredPage : ContentPage
{
    public StarredPage()
    {
        InitializeComponent();
        starredList.ItemsSource = ToDoApplication.Services.TaskStore.StarredTasks;
    }
}