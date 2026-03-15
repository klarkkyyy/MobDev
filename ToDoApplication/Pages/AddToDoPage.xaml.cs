using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ToDoApplication.Models;

namespace ToDoApplication.Pages;

public partial class AddToDoPage : ContentPage
{
    public AddToDoPage()
    {
        InitializeComponent();
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        ToDoApplication.Services.TaskStore.Tasks.Add(new ToDoClass
        {
            item_name = nameEntry.Text,
            item_description = descEntry.Text,
            status = "todo"
        });

        await Navigation.PopAsync();
    }
}
