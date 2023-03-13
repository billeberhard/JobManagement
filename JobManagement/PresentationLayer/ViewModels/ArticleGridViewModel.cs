using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DataLayer.Repository;
using DataLayer.TransferObjects;
using PresentationLayer.Core;

namespace PresentationLayer.ViewModels
{
    public class ArticleGridViewModel : ViewModel, ICRUDDataViewModel
    {
        public ObservableCollection<Article> Articles { get; set; } = new ObservableCollection<Article>();
        public ICommand LoadCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public object SelectedItem { get; set; }

        public ArticleGridViewModel()
        {
            LoadCommand = new RelayCommand(OnLoad, o => true);
            DeleteCommand = new RelayCommand(OnDelete, o => true);
            SearchCommand = new RelayCommand(OnSearch, o => true);
        }

        private void OnLoad(object prameter)
        {
            var articles = m_Repo.Articles.GetAll();
            LoadData(articles);
        }
        private void OnSearch(object prameter)
        {
            string searchContext = (string)prameter;
            ICollection<Article> result = m_Repo.Articles.Search(searchContext);
            LoadData(result);
        }
        private void OnDelete(object parameter)
        {
            var selectedItem = SelectedItem as Article;
            if (selectedItem == null)
                return;

            m_Repo.Articles.Remove(selectedItem);
            LoadData(m_Repo.Articles.GetAll());
        }
        private void LoadData(ICollection<Article> articles)
        {
            Articles.Clear();
            foreach (Article a in articles)
                Articles.Add(a);
        }
        private DataRepository m_Repo = new DataRepository();
    }
}
