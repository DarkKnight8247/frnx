using FrnxApp.ViewModels;

namespace FrnxApp.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new PostViewModel();
    }
}