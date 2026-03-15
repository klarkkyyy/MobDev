namespace ToDoApplication;

public partial class App : Application
{
    // Hold the page instance explicitly to avoid using the obsolete Application.MainPage getter
    private readonly Page _initialPage;

    public App()
    {
        InitializeComponent();

        _initialPage = new NavigationPage(new Pages.SignInPage());

    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        // Return a Window that uses the explicitly stored initial page instance
        return new Window(_initialPage);
    }
}