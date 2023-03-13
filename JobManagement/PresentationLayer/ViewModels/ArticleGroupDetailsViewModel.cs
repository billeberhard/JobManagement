using DataLayer.TransferObjects;
using PresentationLayer.Core;
using System;
using System.Windows.Input;

namespace PresentationLayer.ViewModels;

public class ArticleGroupDetailsViewModel : ViewModel
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
    public ICommand SaveCommand { get; set; }
    public ICommand CancelCommand { get; set; }
    public ICommand NavigateToCommand { get; set; }

    private ArticleGroup m_ArticleGroup;
}