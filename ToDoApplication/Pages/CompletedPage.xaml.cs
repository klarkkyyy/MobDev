using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace ToDoApplication.Pages;

public partial class CompletedPage : ContentPage
{
    System.Collections.ObjectModel.ObservableCollection<ToDoApplication.Models.ToDoClass> _allTasks;
    System.Collections.ObjectModel.ObservableCollection<ToDoApplication.Models.ToDoClass> _completedTasks = new();

    public CompletedPage()
    {
        InitializeComponent();
        _allTasks = ToDoApplication.Services.TaskStore.Tasks;
        RefreshCompleted();
        completedList.ItemsSource = _completedTasks;

        // Subscribe to collection changes to keep completed list up-to-date
        _allTasks.CollectionChanged += AllTasks_CollectionChanged;

        // Subscribe to PropertyChanged on existing items so status changes update the view
        foreach (var t in _allTasks)
            t.PropertyChanged += Item_PropertyChanged;
    }

    void RefreshCompleted()
    {
        _completedTasks.Clear();
        foreach (var t in _allTasks.Where(x => x.status == "completed"))
            _completedTasks.Add(t);
    }

    private void AllTasks_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            foreach (INotifyPropertyChanged ni in e.NewItems.Cast<INotifyPropertyChanged>())
                ni.PropertyChanged += Item_PropertyChanged;
        }
        if (e.OldItems != null)
        {
            foreach (INotifyPropertyChanged ni in e.OldItems.Cast<INotifyPropertyChanged>())
                ni.PropertyChanged -= Item_PropertyChanged;
        }

        RefreshCompleted();
    }

    private void Item_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ToDoApplication.Models.ToDoClass.status) || e.PropertyName == nameof(ToDoApplication.Models.ToDoClass.IsCompleted) || string.IsNullOrEmpty(e.PropertyName))
        {
            // status changed; refresh completed list on UI thread
            MainThread.BeginInvokeOnMainThread(() => RefreshCompleted());
        }
    }

    private async void OnEditClicked(object sender, EventArgs e)
    {
        if (sender is MenuItem mi && mi.CommandParameter is ToDoApplication.Models.ToDoClass item)
        {
            await Navigation.PushAsync(new EditCompletedPage(item));
        }
    }

    private void OnUncompleteClicked(object sender, EventArgs e)
    {
        if (sender is MenuItem mi && mi.CommandParameter is ToDoApplication.Models.ToDoClass item)
        {
            item.status = "todo";
            RefreshCompleted();
        }
    }

    private void OnDeleteClicked(object sender, EventArgs e)
    {
        if (sender is MenuItem mi && mi.CommandParameter is ToDoApplication.Models.ToDoClass item)
        {
            // confirm before deleting
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                var ok = await DisplayAlert("Confirm Delete", "Delete this task?", "Delete", "Cancel");
                if (ok)
                {
                    _allTasks.Remove(item);
                    RefreshCompleted();
                }
            });
        }
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0 && e.CurrentSelection[0] is ToDoApplication.Models.ToDoClass item)
        {
            await Navigation.PushAsync(new EditCompletedPage(item));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}