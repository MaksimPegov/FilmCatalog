using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmCatalog.Models;
using Mopups.Services;

namespace FilmCatalog.Views;

[QueryProperty(nameof(FilmName),"filmName")]
public partial class FilmPage : ContentPage
{
    private Film _film;
    
    public FilmPage()
    {
        InitializeComponent();
    }

    public string FilmName
    {
        set
        {
            _film = FilmRepository.GetFilm(value);
            
            BindingContext = _film;
            
            commentsListView.ItemsSource = _film._comments;
        }
    }

    private void AddCommentButton_OnClicked(object sender, EventArgs e)
    {
        var commentModal = new ComentModal();
        commentModal.CommentSubmitted += OnCommentSubmitted;
        MopupService.Instance.PushAsync(commentModal);
    }
    
    private void OnCommentSubmitted(Comment comment)
    {
        FilmRepository.AddComment(_film.Title, comment);
        
        _film = FilmRepository.GetFilm(_film.Title);

        filmRaiting.Text = null;
        filmRaiting.Text = _film.Rating.ToString();

        commentsListView.ItemsSource = null;
        commentsListView.ItemsSource = _film._comments;
    }
}