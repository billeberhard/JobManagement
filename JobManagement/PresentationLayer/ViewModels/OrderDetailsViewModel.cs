using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.TransferObjects;
using System.Windows.Input;
using PresentationLayer.Core;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Windows;
using DataLayer.Repository;
using PresentationLayer.Components;

namespace PresentationLayer.ViewModels
{
    public class OrderDetailsViewModel : ViewModel 
    {
        public Order Order
        {
            get => m_Order;
            set
            {
                if (value == null)
                    throw new ArgumentException();

                m_Order = value;
                LoadData(m_Order.Positions);
                OnPropertyChanged(nameof(Order));
            }
        }
        public Position EditingPositoin
        {
            get => m_EditingPosition;
            set
            {
                if (value == null)
                    throw new ArgumentException();

                m_EditingPosition = value;
                if (Order != null)
                    LoadData(Order.Positions);
                OnPropertyChanged(nameof(EditingPositoin));
            }
        }
        public Position SelectedPosition
        {
            get => m_SelectedPosition;
            set
            {
                m_SelectedPosition = value;
                OnPropertyChanged(nameof(SelectedPosition));
            }
        }

        public ObservableCollection<Position> Positions { get; set; } = new ObservableCollection<Position>();
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Article> Articles { get; set; }

        public ICommand SaveOrderCommand { get; set; }
        public ICommand CancelOrderCommand { get; set; }
        public ICommand AddPositionCommand { get; set; }
        public ICommand EditPositionCommand { get; set; }
        public ICommand RemovePositoinCommand { get; set; }
        public ICommand SavePositoinCommand { get; set; }
        public ICommand NavigateToCommand { get; set; }

        public OrderDetailsViewModel()
        {
            SaveOrderCommand = new RelayCommand(OnSaveOrder, o => true);
            CancelOrderCommand = new RelayCommand(OnCancelOrder, o => true);
            AddPositionCommand = new RelayCommand(OnAddPosition, o => true);
            RemovePositoinCommand = new RelayCommand(OnRemovePosition, o => true);
            EditPositionCommand = new RelayCommand(OnEditPosition, o => true);
            SavePositoinCommand = new RelayCommand(OnRemovePosition, o => true);
            EditingPositoin = new Position();
            Customers = m_Repo.Customers.GetAll();
            Articles = m_Repo.Articles.GetAll();

        }

        public void OnSaveOrder(object property)
        {
            if (Order.Customer == null)
                return;

            if (m_Repo.Orders.Contains(m_Order))
                m_Repo.Orders.Update(m_Order);
            else
                m_Repo.Orders.Add(m_Order);

            NavigateToCommand?.Execute(SelectedWindow.OrderGrid);
        }
        public void OnCancelOrder(object property)
        {
            var result = MessageBox.Show("Do you want to discard the changes?", "Leaving without saving!",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.No)
                return;

            NavigateToCommand?.Execute(SelectedWindow.OrderGrid);
        }

        public void OnAddPosition(object property)
        {
            if (EditingPositoin.Article == null || EditingPositoin.Amount <= 0)
                return;

            if (Order.Positions.Contains(EditingPositoin))
                return;

            m_Order.Positions.Add(EditingPositoin);
            EditingPositoin = new Position();
        }
        public void OnEditPosition(object property)
        {
            if (SelectedPosition == null)
                return;

            EditingPositoin = SelectedPosition;
        }
        public void OnRemovePosition(object property)
        {
            if (!Order.Positions.Contains(SelectedPosition))
                return;

            Order.Positions.Remove(SelectedPosition);
            EditingPositoin = new Position();
        }

        private void LoadData(ICollection<Position> positions)
        {
            Positions.Clear();
            foreach (Position p in positions)
                Positions.Add(p);
        }

        private DataRepository m_Repo = new DataRepository();
        private Order m_Order;
        private Position m_SelectedPosition;
        private Position m_EditingPosition;
    }
}
