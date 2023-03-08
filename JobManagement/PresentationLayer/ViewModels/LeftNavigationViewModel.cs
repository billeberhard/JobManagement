using System.Windows.Controls;
using System.Windows.Input;
using PresentationLayer.Components;
using PresentationLayer.Core;

namespace PresentationLayer.ViewModels;

public class LeftNavigationViewModel : BaseViewModel
{
    //private object _currentView;
    //private RadioButtonContent _radioButtonContent;

    //public LeftNavigationViewModel(HomeViewModel homeViewModel, CustomerGridViewModel customerGridViewModel,
    //    ArticleGridViewModel articleGridViewModel)
    //{
    //    HomeViewModel = homeViewModel;
    //    CustomerGridViewModel = customerGridViewModel;
    //    ArticleGridViewModel = articleGridViewModel;

    //    CurrentView = HomeViewModel;

    //    HomeViewCommand = new RelayCommand(o =>
    //    {
    //        CurrentView = HomeViewModel;
    //        _radioButtonContent = RadioButtonContent.Home;
    //    });

    //    CustomerViewCommand = new RelayCommand(o =>
    //    {
    //        CurrentView = CustomerViewCommand;
    //        _radioButtonContent = RadioButtonContent.Customer;
    //    });

    //    ArticleViewCommand = new RelayCommand(o =>
    //    {
    //        CurrentView = ArticleViewCommand;
    //        _radioButtonContent = RadioButtonContent.Article;
    //    });

    //    ArticleGroupViewCommand = new RelayCommand(o =>
    //    {
    //        CurrentView = ArticleGroupViewCommand;
    //        _radioButtonContent = RadioButtonContent.ArticleGroup;
    //    });

    //    JobViewCommand = new RelayCommand(o =>
    //    {
    //        CurrentView = JobViewCommand;
    //        _radioButtonContent = RadioButtonContent.Job;
    //    });
    //}


    //public HomeViewModel HomeViewModel { get; }
    //public CustomerGridViewModel CustomerGridViewModel { get; }
    //public ArticleGridViewModel ArticleGridViewModel { get; }


    //public RelayCommand CustomerViewCommand { get; set; }
    //public RelayCommand HomeViewCommand { get; set; }
    //public RelayCommand ArticleViewCommand { get; set; }
    //public RelayCommand ArticleGroupViewCommand { get; set; }
    //public RelayCommand JobViewCommand { get; set; }


    //public object CurrentView
    //{
    //    get => _currentView;
    //    set
    //    {
    //        _currentView = value;
    //        OnPropertyChanged();
    //    }
    //}

    private UserControl _selectedView;

    public UserControl SelectedView
    {
        get { return _selectedView; }
        set
        {
            _selectedView = value;
            OnPropertyChanged(nameof(SelectedView));
        }
    }
    public ICommand SelectViewCommand { get; }

    public LeftNavigationViewModel()
    {
        SelectViewCommand = new RelayCommand(SelectView, null); 
    }


    private void SelectView(object view)
    {
        if (view.ToString() == RadioButtonContent.HomeView.ToString())
        {
            SelectedView = new HomeView(); 
        }

        else if (view.ToString() == RadioButtonContent.CustomerGridView.ToString())
        {
            SelectedView = new CustomersGridView();
        }        
        
        else if (view.ToString() == RadioButtonContent.ArticleGridView.ToString())
        {
            SelectedView = new ArticleGroupGridView();
        }       
        
        else if (view.ToString() == RadioButtonContent.ArticleGroupGridView.ToString())
        {
            SelectedView = new ArticleGridView();
        }        
        
        else if (view.ToString() == RadioButtonContent.JobGridView.ToString())
        {
            SelectedView = new OrderGridView();
        }
    }


    private bool CanExecuteSelectView(object view)
    {
        return true; 
    }

    private enum RadioButtonContent
    {
        HomeView,
        CustomerGridView,
        ArticleGridView,
        ArticleGroupGridView,
        JobGridView
    }
}