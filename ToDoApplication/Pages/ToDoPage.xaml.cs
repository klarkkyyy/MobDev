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
        ToDoApplication.Services.TaskStore.StarredTasks.Clear(); 
    }

    private void OnToggleMenuClicked(object sender, EventArgs e)
    {
        if (Shell.Current != null)
        {
            Shell.Current.FlyoutIsPresented = !Shell.Current.FlyoutIsPresented;
        }
    }

    private void OnDeleteSwiped(object sender, EventArgs e)
    {
        var swipeItem = sender as SwipeItem;
        var todoItem = swipeItem?.BindingContext as ToDoClass;
        if (todoItem != null)
        {
            tasks.Remove(todoItem);
            ToDoApplication.Services.TaskStore.StarredTasks.Remove(todoItem); 
        }
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is ToDoClass item)
        {
            ((CollectionView)sender).SelectedItem = null;
            ToDoApplication.Services.TaskStore.SelectedTask = item;
            await Shell.Current.GoToAsync(nameof(EditToDoPage));
        }
    }

    private void OnStarClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var item = button?.BindingContext as ToDoClass;

        if (item != null)
        {
            item.isStarred = !item.isStarred;
            button.Text = item.isStarred ? "★" : "☆";

            if (item.isStarred)
                ToDoApplication.Services.TaskStore.StarredTasks.Add(item);
            else
                ToDoApplication.Services.TaskStore.StarredTasks.Remove(item);
        }
    }
}