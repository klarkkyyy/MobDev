using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication.Pages;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
    }

    private void OnLogoutClicked(object sender, EventArgs e)
    {
        // Return to sign-in page by setting MainPage to a NavigationPage with SignInPage
        Application.Current.MainPage = new NavigationPage(new SignInPage());
    }
}