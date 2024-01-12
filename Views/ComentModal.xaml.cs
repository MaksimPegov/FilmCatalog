using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmCatalog.Models;
using Mopups.Services;

namespace FilmCatalog.Views;

public partial class ComentModal
{
    public delegate void CommentSubmittedHandler(Comment comment);
    public event CommentSubmittedHandler CommentSubmitted;
    
    public ComentModal()
    {
        InitializeComponent();
    }

    private void CloseBtn_OnClicked(object sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();

    }

    private void Comment_OnClicked(object sender, EventArgs e)
    {

        double result;
        if (double.TryParse(RatingEntry.Text, out result) && result >= 0 && result <= 10 && CommentEntry.Text.Length > 0)
        {
            var comment = new Comment() { Text = CommentEntry.Text, Rating = result };
            CommentSubmitted?.Invoke(comment);
            MopupService.Instance.PopAsync();
        }
        else
        {
            Warning.IsVisible = true;
        }
    }
}