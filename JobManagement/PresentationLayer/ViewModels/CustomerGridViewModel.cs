using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using DataLayer.Repository;
using DataLayer.TransferObjects;
using PresentationLayer.Core;

namespace PresentationLayer.ViewModels;

public class CustomerGridViewModel : ViewModel, ICRUDDataViewModel
{
    public ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>();

    public ICommand DeleteCommand { get; set; }
    public ICommand SearchCommand { get; set; }
    public object SelectedItem
    {
        get => m_SelectedItem;
        set
        {
            m_SelectedItem = value;
            OnPropertyChanged(nameof(SelectedItem));
        }
    }

    public CustomerGridViewModel()
    {
        DeleteCommand = new RelayCommand(OnDelete, o => true);
        SearchCommand = new RelayCommand(OnSearch, o => true);
    }

    public void Update()
    {
        var customers = m_Repo.Customers.GetAll();
        LoadData(customers);
    }
    private void OnSearch(object prameter)
    {
        string searchContext = (string)prameter;
        ICollection<Customer> result = m_Repo.Customers.Search(searchContext);
        LoadData(result);
    }
    private void OnDelete(object parameter)
    {
        var selectedItem = SelectedItem as Customer;
        if (selectedItem == null)
            return;

        m_Repo.Customers.Remove(selectedItem);
        LoadData(m_Repo.Customers.GetAll());
    }
    private void LoadData(ICollection<Customer> customers)
    {
        Customers.Clear();
        foreach (Customer c in customers)
            Customers.Add(c);
    }

    private DataRepository m_Repo = new DataRepository();
    private object m_SelectedItem;
}