using System.Collections.ObjectModel;
using System.Windows.Input;
using FilmCatalog.Models;
using FilmCatalog.Views;

namespace FilmCatalog;

public partial class MainPage : ContentPage
{
    
    public ICommand RemoveFilmCommand { get; }

    public MainPage()
    {
        InitializeComponent();
        
        BindingContext = this;
        
        RemoveFilmCommand = new Command<Film>(RemoveFilm_OnClicked);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        UpdateList();
    }

    private void FilmList_OnItemTapped(object sender, ItemTappedEventArgs e)
    {
        filmList.SelectedItem = null;
    }

    private async void FilmList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (filmList.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(FilmPage)}?filmName={((Film) filmList.SelectedItem).Title}");
        }
    }

    private async void AddFilm_OnClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddFilmPage));
    }

    private void RemoveFilm_OnClicked(Film film)
    {
        if (film != null)
        {
            string filmName = film.Title;
            FilmRepository.RemoveFilm(filmName);
            UpdateList();
        }
    }
    
    private void UpdateList()
    {
        var films = new ObservableCollection<Film>(FilmRepository.GetFilms());
        filmList.ItemsSource = films;
    }
}
