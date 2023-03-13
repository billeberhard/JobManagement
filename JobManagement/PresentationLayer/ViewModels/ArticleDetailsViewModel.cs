using DataLayer.Repository;
using DataLayer.TransferObjects;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PresentationLayer.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PresentationLayer.ViewModels;

public class ArticleDetailsViewModel : ViewModel
{
    public ICommand SaveCommand { get; set; }
    public ICommand CancelCommand { get; set; }
    public ICommand NavigateToCommand { get; set; }

    public Article Article
    {
        get => m_Article;
        set
        {
            if (value == null)
                throw new ArgumentException();

            m_Article = value;
            OnPropertyChanged(nameof(Article));
        }
    }

    public ICollection<ArticleGroup> ArticleGroups { get; set; } = new List<ArticleGroup>();

    public ArticleDetailsViewModel()
    {
        SaveCommand = new RelayCommand(OnSave, o => true);
        CancelCommand = new RelayCommand(OnCancel, o => true);

        LoadData(m_Repo.ArticleGroups.GetAll());
    }

    public void OnSave(object property)
    {
        if (m_Article.ArticleGroup == null ||
            m_Article.Name == null || m_Article.Name == "" ||
            m_Article.Price <= 0)
            return;

        if (m_Repo.Articles.Contains(m_Article))
            m_Repo.Articles.Update(m_Article);
        else
            m_Repo.Articles.Add(m_Article);

        NavigateToCommand?.Execute(SelectedWindow.ArticleGrid);
    }
    public void OnCancel(object property)
    {
        var result = MessageBox.Show("Do you want to discard the changes?", "Leaving without saving!",
            MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (result == MessageBoxResult.No)
            return;

        NavigateToCommand?.Execute(SelectedWindow.ArticleGrid);
    }

    private void LoadData(ICollection<ArticleGroup> artileGroups)
    {
        ArticleGroups.Clear();
        foreach (var group in artileGroups)
            ArticleGroups.Add(group);
    }

    private Article m_Article;
    private DataRepository m_Repo = new DataRepository();
}