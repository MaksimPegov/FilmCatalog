using FilmCatalog.Views;

namespace FilmCatalog;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute(nameof(FilmPage), typeof(FilmPage));
        Routing.RegisterRoute(nameof(AddFilmPage), typeof(AddFilmPage));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
    }
}