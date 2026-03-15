using ToDoApplication.Pages;

namespace ToDoApplication;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(EditToDoPage), typeof(EditToDoPage));
        Routing.RegisterRoute(nameof(AddToDoPage), typeof(AddToDoPage));
        Routing.RegisterRoute(nameof(StarredPage), typeof(StarredPage));
    }
}