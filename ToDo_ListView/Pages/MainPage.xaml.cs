using ToDo_ListView.Models;
using ToDo_ListView.PageModels;

namespace ToDo_ListView.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }

        private void AddToDoItem(object sender, EventArgs e)
        {
            // TODO: Implement add functionality
        }

        private void EditToDoItem(object sender, EventArgs e)
        {
            // TODO: Implement edit functionality
        }

        private void CancelEdit(object sender, EventArgs e)
        {
            // TODO: Implement cancel edit functionality
        }

        private void TodoLV_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: Implement selection changed functionality
            if (e.CurrentSelection.Count > 0)
            {
                var selectedItem = e.CurrentSelection[0];
                // Handle selected item
            }
        }

        private void DeleteToDoItem(object sender, EventArgs e)
        {
            // TODO: Implement delete functionality
            if (sender is ImageButton button && button.CommandParameter is int id)
            {
                // Delete item with id
            }
        }
    }
}
