﻿using System.Windows.Input;
using PresentationLayer.Core;
using PresentationLayer.Services;

namespace PresentationLayer.ViewModels;

public class MainViewModel : ObservableObject
{
    private INavigationService _navigation;
    private RadioButtonState _radioButtonState;

    public MainViewModel(INavigationService navService)
    {
        Navigation = navService;

        NavigateToHomeViewCommand = new RelayCommand(o =>
        {
            Navigation.NavigateTo<HomeViewModel>();
            _radioButtonState = RadioButtonState.Home;
        }, o => true);
        NavigateToCustomerGridViewCommand = new RelayCommand(o =>
        {
            Navigation.NavigateTo<CustomerGridViewModel>();
            _radioButtonState = RadioButtonState.Customer;
        }, o => true);
        NavigateToArticleGridViewCommand = new RelayCommand(o =>
        {
            Navigation.NavigateTo<ArticleGridViewModel>();
            _radioButtonState = RadioButtonState.Article;
        }, o => true);
        NavigateToArticleGroupGridViewCommand = new RelayCommand(o =>
        {
            Navigation.NavigateTo<ArticleGroupGridViewModel>();
            _radioButtonState = RadioButtonState.ArticleGroup;
        }, o => true);
        NavigateToOrderGridCommand = new RelayCommand(o =>
        {
            Navigation.NavigateTo<OrderGridViewModel>();
            _radioButtonState = RadioButtonState.Order;
        }, o => true);

        NewCommand = new RelayCommand(o => OnNewCommand(), o => true);
        EditCommand = new RelayCommand(o => OnEditCommand(), o => true);
        DeleteCommand = new RelayCommand(o => OnDeleteCommand(), o => true);
        SearchCommand = new RelayCommand(o => OnSearchCommand(), o => true);
    }

    public INavigationService Navigation
    {
        get => _navigation;
        set
        {
            _navigation = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand NavigateToHomeViewCommand { get; set; }
    public RelayCommand NavigateToCustomerGridViewCommand { get; set; }
    public RelayCommand NavigateToArticleGridViewCommand { get; set; }
    public RelayCommand NavigateToArticleGroupGridViewCommand { get; set; }
    public RelayCommand NavigateToOrderGridCommand { get; set; }


    public RelayCommand NewCommand { get; set; }
    public RelayCommand EditCommand { get; set; }
    public RelayCommand DeleteCommand { get; set; }
    public RelayCommand SearchCommand { get; set; }


    public ICommand UpdateViewCommand { get; set; }


    private void OnNewCommand()
    {
        switch (_radioButtonState)
        {
            case RadioButtonState.Home:
                break;

            case RadioButtonState.Customer:
                Navigation.NavigateTo<CustomerDetailsViewModel>();
                break;

            case RadioButtonState.Article:
                Navigation.NavigateTo<ArticleDetailsViewModel>();
                break;

            case RadioButtonState.Order:
                Navigation.NavigateTo<OrderDetailsViewModel>();
                break;

            case RadioButtonState.ArticleGroup:
                Navigation.NavigateTo<ArticleDetailsViewModel>();
                break;
        }
    }

    private void OnEditCommand()
    {
        switch (_radioButtonState)
        {
            case RadioButtonState.Home:
                break;

            case RadioButtonState.Customer:
                Navigation.NavigateTo<CustomerDetailsViewModel>();
                break;

            case RadioButtonState.Article:
                Navigation.NavigateTo<ArticleDetailsViewModel>();
                break;

            case RadioButtonState.Order:
                Navigation.NavigateTo<OrderDetailsViewModel>();
                break;

            case RadioButtonState.ArticleGroup:
                Navigation.NavigateTo<ArticleGroupDetailsViewModel>();
                break;
        }
    }

    private void OnSearchCommand()
    {
        switch (_radioButtonState)
        {
            case RadioButtonState.Home:
                break;

            case RadioButtonState.Customer:
                Navigation.NavigateTo<CustomerDetailsViewModel>();
                //ReloadSearchCustomerView();
                break;

            case RadioButtonState.Article:
                Navigation.NavigateTo<ArticleDetailsViewModel>();
                //ReloadSearchItemView();
                break;

            case RadioButtonState.Order:
                Navigation.NavigateTo<OrderDetailsViewModel>();
                //ReloadSearchOrderView();
                break;
        }
    }

    private void OnDeleteCommand()
    {
    }

    private enum RadioButtonState
    {
        Home,
        Customer,
        Article,
        Order,
        ArticleGroup
    }
}