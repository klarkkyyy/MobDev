using ToDoMaui_Listview;
using ToDo_ListView.PageModels;

namespace ToDo_ListView.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageModel _model;
        private ToDoClass? _itemBeingEdited = null;

        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            _model = model;
            BindingContext = _model;
            todoLV.ItemsSource = _model.ToDoItems;
            UpdateEmptyState();
        }

        // ── ADD ──────────────────────────────────────────────
        private void AddToDoItem(object sender, EventArgs e)
        {
            string title = titleEntry.Text?.Trim() ?? "";
            string detail = detailsEditor.Text?.Trim() ?? "";

            if (string.IsNullOrEmpty(title))
            {
                DisplayAlert("Oops", "Title cannot be empty.", "OK");
                return;
            }

            _model.ToDoItems.Add(new ToDoClass { title = title, detail = detail });
            ClearInputs();
            UpdateEmptyState();
        }

        // ── SELECT (load item into inputs for editing) ────────
        private void TodoLV_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is not ToDoClass selected) return;

            _itemBeingEdited = selected;
            titleEntry.Text = selected.title;
            detailsEditor.Text = selected.detail;

            addBtn.IsVisible = false;
            editRow.IsVisible = true;

            todoLV.SelectedItem = null;
        }

        // ── SAVE EDIT ─────────────────────────────────────────
        private void EditToDoItem(object sender, EventArgs e)
        {
            if (_itemBeingEdited == null) return;

            string title = titleEntry.Text?.Trim() ?? "";
            string detail = detailsEditor.Text?.Trim() ?? "";

            if (string.IsNullOrEmpty(title))
            {
                DisplayAlert("Oops", "Title cannot be empty.", "OK");
                return;
            }

            _itemBeingEdited.title = title;
            _itemBeingEdited.detail = detail;

            // Refresh ListView
            todoLV.ItemsSource = null;
            todoLV.ItemsSource = _model.ToDoItems;

            _itemBeingEdited = null;
            ClearInputs();
            ResetButtons();
        }

        // ── CANCEL EDIT ───────────────────────────────────────
        private void CancelEdit(object sender, EventArgs e)
        {
            _itemBeingEdited = null;
            ClearInputs();
            ResetButtons();
        }

        // ── DELETE ────────────────────────────────────────────
        private void DeleteToDoItem(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.CommandParameter is int id)
            {
                var item = _model.ToDoItems.FirstOrDefault(t => t.id == id);
                if (item != null)
                    _model.ToDoItems.Remove(item);

                UpdateEmptyState();
            }
        }

        // ── HELPERS ───────────────────────────────────────────
        private void ClearInputs()
        {
            titleEntry.Text = string.Empty;
            detailsEditor.Text = string.Empty;
        }

        private void ResetButtons()
        {
            addBtn.IsVisible = true;
            editRow.IsVisible = false;
        }

        private void UpdateEmptyState()
        {
            emptyLabel.IsVisible = _model.ToDoItems.Count == 0;
        }
    }
}