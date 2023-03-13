using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DataLayer.Repository;
using DataLayer.TransferObjects;
using PresentationLayer.Core;

namespace PresentationLayer.ViewModels
{
    class ArticleGroupGridViewModel : ViewModel, ICRUDDataViewModel
    {
        public ObservableCollection<ArticleGroup> ArticleGroups { get; set; } = new ObservableCollection<ArticleGroup>();

        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public object SelectedItem { get; set; }

        public ArticleGroupGridViewModel()
        {
            DeleteCommand = new RelayCommand(OnDelete, o => true);
            SearchCommand = new RelayCommand(OnSearch, o => true);

            var articleGroups = m_Repo.ArticleGroups.GetAllAtRoot();
            LoadData(articleGroups);
        }


        public void Update()
        {
            var articleGroups = m_Repo.ArticleGroups.GetAllAtRoot();
            LoadData(articleGroups);
        }
        private void OnSearch(object prameter)
        {
            return;

            string searchContext = (string)prameter;
            ICollection<ArticleGroup> result = m_Repo.ArticleGroups.Search(searchContext);
            LoadData(result);
        }
        private void OnDelete(object parameter)
        {
            var selectedItem = SelectedItem as ArticleGroup;
            if (selectedItem == null)
                return;

            bool removed = m_Repo.ArticleGroups.Remove(selectedItem);
            if (removed)
                LoadData(m_Repo.ArticleGroups.GetAllAtRoot());
        }
        private void LoadData(ICollection<ArticleGroup> articleGroups)
        {
            ArticleGroups.Clear();
            foreach (var a in articleGroups)
                ArticleGroups.Add(a);
        }

        DataRepository m_Repo = new DataRepository();
    }
}
