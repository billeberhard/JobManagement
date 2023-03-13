using DataLayer.Repository;
using DataLayer.TransferObjects;
using PresentationLayer.Core;
using System;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Input;

namespace PresentationLayer.ViewModels;

public class CustomerDetailsViewModel : ViewModel
{
	public Customer Customer
	{
		get => m_Customer;
		set
		{
			m_Customer = value;
			OnPropertyChanged(nameof(Customer));
		}
	}
	public ICommand SaveCommand { get; set; }
	public ICommand CancelCommand { get; set; }
	public ICommand NavigateToCommand { get; set; }

	public CustomerDetailsViewModel()
	{
		SaveCommand = new RelayCommand(OnSave, o => true);
		CancelCommand = new RelayCommand(OnCancel, o => true);
	}

	public void OnSave(object property)
	{
		if (m_Customer.FirstName == null || m_Customer.FirstName == "" ||
			m_Customer.LastName == null || m_Customer.LastName == "" ||
			m_Customer.HouseNumber == null || m_Customer.HouseNumber == "" ||
			m_Customer.StreetName == null || m_Customer.StreetName == "" ||
            m_Customer.City == null || m_Customer.City == "" ||
			m_Customer.PostalCode == null || m_Customer.PostalCode == "" ||
			m_Customer.EmailAddress == null || m_Customer.EmailAddress == "" ||
            m_Customer.Password == null || m_Customer.Password == "")
			return;

		if (m_Repo.Customers.Contains(m_Customer))
			m_Repo.Customers.Update(m_Customer);
		else
			m_Repo.Customers.Add(m_Customer);

        NavigateToCommand?.Execute(SelectedWindow.CustomerGrid);
    }
	public void OnCancel(object property)
	{
		var result = MessageBox.Show("Do you want to discard the changes?", "Leaving without saving!",
				MessageBoxButton.YesNo, MessageBoxImage.Warning);

		if (result == MessageBoxResult.No)
			return;

		NavigateToCommand?.Execute(SelectedWindow.CustomerGrid);
	}

	private Customer m_Customer;
	private DataRepository m_Repo = new DataRepository();
}