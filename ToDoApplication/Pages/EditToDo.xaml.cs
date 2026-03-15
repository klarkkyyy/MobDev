using System;
namespace ToDoApplication.Pages;

public partial class EditToDoPage : ContentPage
{
    private ToDoApplication.Models.ToDoClass _item;

    public EditToDoPage()
    {
        InitializeComponent();
        _item = ToDoApplication.Services.TaskStore.SelectedTask;
        BindingContext = _item;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        var ok = await DisplayAlert("Confirm Delete", "Delete this task?", "Delete", "Cancel");
        if (ok)
        {
            ToDoApplication.Services.TaskStore.Tasks.Remove(_item);
            await Shell.Current.GoToAsync("..");
        }
    }
}