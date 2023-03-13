using DataLayer.Repository;
using DataLayer.TransferObjects;
using PresentationLayer.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PresentationLayer.ViewModels;

public class HomeViewModel : ViewModel, IUpdatable
{
    public ObservableCollection<OrderEvaluation> OrderEvaluations { get; set; } = new ObservableCollection<OrderEvaluation>();

    public string CustomerNumber
    {
		get => m_CustomerNumber;
        set
        {
			int customerNumber = -1;
			int.TryParse(value, out customerNumber);
            FilterCriterias.CustomerNumber = customerNumber;

			m_CustomerNumber = value;
            OnPropertyChanged(nameof(FilterCriterias));
            LoadData(m_Repo.Orders.GetOrderEvaluations(FilterCriterias));
        }
    }
    public string OrderNumber
    {
        get => m_OrderNumber;
        set
        {
            int orderNumber = -1;
            int.TryParse(value, out orderNumber);
            FilterCriterias.OrderNumber = orderNumber;

            m_OrderNumber = value;
            OnPropertyChanged(nameof(OrderNumber));
            LoadData(m_Repo.Orders.GetOrderEvaluations(FilterCriterias));
        }
    }
    public string MinTotalOrderPrice
    {
        get => m_MinTotalOrderPrice;
        set
        {
            decimal minTotalOrderPrice = -1;
            decimal.TryParse(value, out minTotalOrderPrice);
            FilterCriterias.MaxTotalOrderPrice = minTotalOrderPrice;

            m_MinTotalOrderPrice = value;
            OnPropertyChanged(nameof(MinTotalOrderPrice));
            LoadData(m_Repo.Orders.GetOrderEvaluations(FilterCriterias));
        }
    }
    public string MaxTotalOrderPrice
    {
        get => m_MaxTotalOrderPrice;
        set
        {
            decimal maxTotalOrderPrice = -1;
            decimal.TryParse(value, out maxTotalOrderPrice);
            FilterCriterias.MaxTotalOrderPrice = maxTotalOrderPrice;

            m_MaxTotalOrderPrice = value;
            OnPropertyChanged(nameof(MaxTotalOrderPrice));
            LoadData(m_Repo.Orders.GetOrderEvaluations(FilterCriterias));
        }
    }

    public OrderEvaluationFilterCriterias FilterCriterias
	{
		get => m_FilterCriteria;
		set
		{
			m_FilterCriteria = value;
			OnPropertyChanged(nameof(FilterCriterias));
			LoadData(m_Repo.Orders.GetOrderEvaluations(FilterCriterias));
		}
	}

    public HomeViewModel()
	{
		LoadData(m_Repo.Orders.GetOrderEvaluations(new OrderEvaluationFilterCriterias()));
	}

	private void LoadData(ICollection<OrderEvaluation> orderEvaluations)
	{
        OrderEvaluations.Clear();

		foreach (var o in orderEvaluations)
            OrderEvaluations.Add(o);
	}

    public void Update()
    {
        LoadData(m_Repo.Orders.GetOrderEvaluations(new OrderEvaluationFilterCriterias()));
    }

    private DataRepository m_Repo = new DataRepository();
	private OrderEvaluationFilterCriterias m_FilterCriteria = new OrderEvaluationFilterCriterias();
	private string m_CustomerNumber = "";
	private string m_OrderNumber = "";
	private string m_MinTotalOrderPrice = "";
	private string m_MaxTotalOrderPrice = "";
}