using DataLayer.Repository;
using DataLayer.TransferObjects;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PresentationLayer.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.Xml;
using System.Windows;
using System.Windows.Input;

namespace PresentationLayer.ViewModels;

public class ArticleGroupDetailsViewModel : ViewModel, IUpdatable
{
    public ArticleGroup ArticleGroup
    {
        get => m_ArticleGroup;
        set
        {
            if (value == null)
                throw new ArgumentException();

            m_ArticleGroup = value;
            OnPropertyChanged(nameof(ArticleGroup));
        }
    }
    public ObservableCollection<ArticleGroup> ArticleGroups { get; set; } = new ObservableCollection<ArticleGroup>();

    public ICommand SaveCommand { get; set; }
    public ICommand CancelCommand { get; set; }
    public ICommand NavigateToCommand { get; set; }

    public ArticleGroupDetailsViewModel()
    {
        SaveCommand = new RelayCommand(OnSave, o => true);
        CancelCommand = new RelayCommand(OnCancel, o => true);
    }

    public void OnSave(object property)
    {
        if (ArticleGroup.Name == null || ArticleGroup.Name == "")
            return;

        if (m_Repo.ArticleGroups.Contains(ArticleGroup))
            m_Repo.ArticleGroups.Update(ArticleGroup);
        else
            m_Repo.ArticleGroups.Add(ArticleGroup);

        NavigateToCommand?.Execute(SelectedWindow.ArticleGroupGrid);
    }

    public void OnCancel(object property)
    {
        var result = MessageBox.Show("Do you want to discard the changes?", "Leaving without saving!",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (result == MessageBoxResult.No)
            return;

        NavigateToCommand?.Execute(SelectedWindow.ArticleGroupGrid);
    }

    public void Update()
    {
        LoadData(m_Repo.ArticleGroups.GetAll());
    }

    private void LoadData(ICollection<ArticleGroup> articleGroups)
    {
        ArticleGroups.Clear();
        foreach (var a in articleGroups)
            ArticleGroups.Add(a);
    }

    private ArticleGroup m_ArticleGroup;
    DataRepository m_Repo = new DataRepository();
}