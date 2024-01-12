using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmCatalog.Models;

namespace FilmCatalog.Views;

public partial class AddFilmPage : ContentPage
{
    public AddFilmPage()
    {
        InitializeComponent();
    }

    private async void Create_Clicked(object sender, EventArgs e)
    {
        try
        {
            FilmRepository.AddFilm(new Film(
                filmTitleEntry.Text,
                directorEntry.Text,
                int.Parse(yearEntry.Text),
                imageUrl.Text,
                filmDescription.Text
            ));
        }
        catch (Exception exception)
        {
            alert.IsVisible = true;
            throw new Exception();
        }

        await Shell.Current.GoToAsync("..");
    }
}