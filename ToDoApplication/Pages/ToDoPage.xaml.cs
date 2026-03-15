using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ToDoApplication.Models;

namespace ToDoApplication.Pages;

public partial class ToDoPage : ContentPage
{
    System.Collections.ObjectModel.ObservableCollection<ToDoClass> tasks;

    public ToDoPage()
    {
        InitializeComponent();
        tasks = ToDoApplication.Services.TaskStore.Tasks;
        todoList.ItemsSource = tasks;
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddToDoPage());
    }

    private async void OnViewCompletedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CompletedPage());
    }

    private void OnClearClicked(object sender, EventArgs e)
    {
        tasks.Clear();
    }

    private void OnToggleMenuClicked(object sender, EventArgs e)
    {
        if (Shell.Current != null)
        {
            Shell.Current.FlyoutIsPresented = !Shell.Current.FlyoutIsPresented;
        }
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0 && e.CurrentSelection[0] is ToDoClass item)
        {
            await Navigation.PushAsync(new EditToDoPage(item));
            // clear selection
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}