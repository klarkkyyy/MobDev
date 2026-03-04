using ToDoMaui_Listview;

namespace ToDo_ListView.Pages
{
    public partial class ManageMetaPage : ContentPage
    {
        private readonly MainPageModel _model;
        private ToDoClass? _itemBeingEdited = null;
        public ManageMetaPage(MainPageModel model, ToDoClass? itemBeingEdited)
        {
            InitializeComponent();
            _model = model;
            _itemBeingEdited = itemBeingEdited;
            BindingContext = _model;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}