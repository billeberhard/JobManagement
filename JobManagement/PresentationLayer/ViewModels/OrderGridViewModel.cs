using Castle.Core.Resource;
using DataLayer.Repository;
using DataLayer.TransferObjects;
using PresentationLayer.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PresentationLayer.ViewModels;

internal class OrderGridViewModel : ViewModel, ICRUDDataViewModel
{
	public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();

	public ICommand LoadCommand { get; set; }
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

    public OrderGridViewModel()
	{
		LoadCommand = new RelayCommand(OnLoad, o => true);
		DeleteCommand = new RelayCommand(OnDelete, o => true);
		SearchCommand = new RelayCommand(OnSearch, o => true);
    }

    private void OnLoad(object prameter)
    {
        var orders = m_Repo.Orders.GetAll();
        LoadData(orders);
    }
    private void OnSearch(object prameter)
    {
        string searchContext = (string)prameter;
        ICollection<Order> result = m_Repo.Orders.Search(searchContext);
        LoadData(result);
    }
    private void OnDelete(object parameter)
    {
        var selectedItem = SelectedItem as Order;
        if (selectedItem == null)
            return;

        m_Repo.Orders.Remove(selectedItem);
        LoadData(m_Repo.Orders.GetAll());
    }
    private void LoadData(ICollection<Order> orders)
    {
        Orders.Clear();
        foreach (Order o in orders)
            Orders.Add(o);
    }

    private DataRepository m_Repo = new DataRepository();
    private object m_SelectedItem;
}