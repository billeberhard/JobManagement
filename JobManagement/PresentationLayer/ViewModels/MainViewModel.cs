using System;
using System.Runtime.InteropServices.ObjectiveC;
using System.Windows.Input;
using DataLayer.TransferObjects;
using Microsoft.Identity.Client;
using PresentationLayer.Core;
using PresentationLayer.Services;

namespace PresentationLayer.ViewModels;

internal enum SelectedWindow
{
    Home,
    CustomerGrid,
    CustomerDetailsNew,
    CustomerDetailsEdit,
    ArticleGrid,
    ArticleDetailsNew,
    ArticleDetailsEdit,
    OrderGrid,
    OrderDetailsNew,
    OrderDetailsEdit,
    ArticleGroupGrid,
    ArticleGroupDetailsNew,
    ArticleGroupDetailsEdit
}

public class MainViewModel : ObservableObject
{
    public INavigationService Navigation { get; set; }

    public ICommand NavigateToHomeViewCommand { get; set; }
    public ICommand NavigateToCustomerGridViewCommand { get; set; }
    public ICommand NavigateToArticleGridViewCommand { get; set; }
    public ICommand NavigateToArticleGroupGridViewCommand { get; set; }
    public ICommand NavigateToOrderGridCommand { get; set; }

    public ICommand SearchCommand { get; set; }
    public ICommand NewCommand { get; set; }
    public ICommand DeleteCommand { get; set; }
    public ICommand EditCommand { get; set; }

    public MainViewModel(INavigationService navService)
    {
        Navigation = navService;

        NavigateToHomeViewCommand = new RelayCommand(o => OnNavigateTo(SelectedWindow.Home), o => true);
        NavigateToCustomerGridViewCommand = new RelayCommand(o => OnNavigateTo(SelectedWindow.CustomerGrid), o => true);
        NavigateToArticleGridViewCommand = new RelayCommand(o => OnNavigateTo(SelectedWindow.ArticleGrid), o => true);
        NavigateToArticleGroupGridViewCommand = new RelayCommand(o => OnNavigateTo(SelectedWindow.ArticleGroupGrid), o => true);
        NavigateToOrderGridCommand = new RelayCommand(o => OnNavigateTo(SelectedWindow.OrderGrid), o => true);

        SearchCommand = new RelayCommand(OnSearch, o => true);
        NewCommand = new RelayCommand(o => OnNew(), o => true);
        DeleteCommand = new RelayCommand(o => OnDelete(), o => true);
        EditCommand = new RelayCommand(o => OnEdit(), o => true);
    }

    private void OnNavigateTo(object property)
    {
        var selectedWindow = (SelectedWindow)property;
        m_SelectedWindow = selectedWindow;

        ICRUDDataViewModel perviousViewModel;

        switch (selectedWindow)
        {
            case SelectedWindow.Home:
                Navigation.NavigateTo<HomeViewModel>();
                break;

            case SelectedWindow.CustomerGrid:
                Navigation.NavigateTo<CustomerGridViewModel>();
                break;

            case SelectedWindow.CustomerDetailsEdit:
                NavigateToCustomerDetailsEdit();
                break;

            case SelectedWindow.CustomerDetailsNew:
                NavigateToCustomerDetailsNew();
                break;

            case SelectedWindow.ArticleGrid:
                Navigation.NavigateTo<ArticleGridViewModel>();
                break;

            case SelectedWindow.ArticleDetailsNew:
                NavigateToArticleDetailsNew();
                break;

            case SelectedWindow.ArticleDetailsEdit:
                NavigateToArticleDetailsEdit();
                break;

            case SelectedWindow.ArticleGroupGrid:
                Navigation.NavigateTo<ArticleGroupGridViewModel>();
                break;

            case SelectedWindow.ArticleGroupDetailsEdit:
                NavigateToArticleGroupDetailsEdit();
                break;

            case SelectedWindow.ArticleGroupDetailsNew:
                NavigateToArticleGroupDetailsNew();
                break;

            case SelectedWindow.OrderGrid:
                Navigation.NavigateTo<OrderGridViewModel>();
                break;
            
            case SelectedWindow.OrderDetailsEdit:
                NavigateToOrderDetailsEdit();
                break;

            case SelectedWindow.OrderDetailsNew:
                NavigateToOrderDetailsNew();
                break;
        }
    }

    private void NavigateToCustomerDetailsNew()
    {
        var viewModel = Navigation.NavigateTo<CustomerDetailsViewModel>();
        viewModel.Customer = new Customer();
        viewModel.NavigateToCommand = new RelayCommand(OnNavigateTo, p => true);
    }
    private void NavigateToOrderDetailsNew()
    {
        var viewModel = Navigation.NavigateTo<OrderDetailsViewModel>();
        viewModel.Order = new Order();
        viewModel.NavigateToCommand = new RelayCommand(OnNavigateTo, p => true);
    }
    private void NavigateToArticleDetailsNew()
    {
        var viewModel = Navigation.NavigateTo<ArticleDetailsViewModel>();
        viewModel.Article = new Article();
        viewModel.NavigateToCommand = new RelayCommand(OnNavigateTo, p => true);
    }
    private void NavigateToArticleGroupDetailsNew()
    {
        var viewModel = Navigation.NavigateTo<ArticleGroupDetailsViewModel>();
        viewModel.ArticleGroup = new ArticleGroup();
        viewModel.NavigateToCommand = new RelayCommand(OnNavigateTo, p => true);
    }

    private void NavigateToCustomerDetailsEdit()
    {
        var previous = Navigation.CurrentView as ICRUDDataViewModel;

        var selectedItem = previous.SelectedItem;
        var itemToEdit = selectedItem as Customer;

        var current = Navigation.NavigateTo<CustomerDetailsViewModel>();
        current.Customer = itemToEdit;
        current.NavigateToCommand = new RelayCommand(OnNavigateTo, p => true);
    }
    private void NavigateToArticleDetailsEdit()
    {
        var previous = Navigation.CurrentView as ICRUDDataViewModel;

        var selectedItem = previous.SelectedItem;
        var itemToEdit = selectedItem as Article;

        var current = Navigation.NavigateTo<ArticleDetailsViewModel>();
        current.Article = itemToEdit;
        current.NavigateToCommand = new RelayCommand(OnNavigateTo, p => true);
    }
    private void NavigateToArticleGroupDetailsEdit()
    {
        var previous = Navigation.CurrentView as ICRUDDataViewModel;

        var selectedItem = previous.SelectedItem;
        var itemToEdit = selectedItem as ArticleGroup;

        var current = Navigation.NavigateTo<ArticleGroupDetailsViewModel>();
        current.ArticleGroup = itemToEdit;
        current.NavigateToCommand = new RelayCommand(OnNavigateTo, p => true);
    }
    private void NavigateToOrderDetailsEdit()
    {
        var previous = Navigation.CurrentView as ICRUDDataViewModel;

        var selectedItem = previous.SelectedItem;
        var itemToEdit = selectedItem as Order;
        if (itemToEdit == null)
            return;

        var current = Navigation.NavigateTo<OrderDetailsViewModel>();
        current.Order = itemToEdit;
        current.NavigateToCommand = new RelayCommand(OnNavigateTo, p => true);
    }

    private void OnNew()
    {
        switch (m_SelectedWindow)
        {
            case SelectedWindow.Home:
                break;

            case SelectedWindow.CustomerGrid:
                OnNavigateTo(SelectedWindow.CustomerDetailsNew);
                break;

            case SelectedWindow.OrderGrid:
                OnNavigateTo(SelectedWindow.OrderDetailsNew);
                break;

            case SelectedWindow.ArticleGrid:
                OnNavigateTo(SelectedWindow.ArticleDetailsNew);
                break;

            case SelectedWindow.ArticleGroupGrid:
                OnNavigateTo(SelectedWindow.ArticleGroupDetailsNew);
                break;
        }
    }
    private void OnSearch(object parameter)
    {
        var searchContext = parameter;
        var viewModel = Navigation.CurrentView as ICRUDDataViewModel;

        viewModel.SearchCommand?.Execute(searchContext);
    }
    private void OnDelete()
    {
        var currentView = Navigation.CurrentView as ICRUDDataViewModel;

        currentView.DeleteCommand?.Execute(null);
    }
    private void OnEdit()
    {
        switch (m_SelectedWindow)
        {
            case SelectedWindow.Home:
                break;

            case SelectedWindow.CustomerGrid:
                OnNavigateTo(SelectedWindow.CustomerDetailsEdit);
                break;

            case SelectedWindow.OrderGrid:
                OnNavigateTo(SelectedWindow.OrderDetailsEdit);
                break;

            case SelectedWindow.ArticleGrid:
                OnNavigateTo(SelectedWindow.ArticleDetailsEdit);
                break;

            case SelectedWindow.ArticleGroupGrid:
                OnNavigateTo(SelectedWindow.ArticleGroupDetailsEdit);
                break;
        }
    }

    private SelectedWindow m_SelectedWindow;
}