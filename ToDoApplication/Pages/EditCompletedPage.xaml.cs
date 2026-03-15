using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication.Pages;

public partial class EditCompletedPage : ContentPage
{
    private ToDoApplication.Models.ToDoClass _item;

    public EditCompletedPage(ToDoApplication.Models.ToDoClass item)
    {
        InitializeComponent();
        _item = item;
        BindingContext = _item;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        var ok = await DisplayAlert("Confirm Delete", "Delete this task?", "Delete", "Cancel");
        if (ok)
        {
            ToDoApplication.Services.TaskStore.Tasks.Remove(_item);
            await Navigation.PopAsync();
        }
    }
}