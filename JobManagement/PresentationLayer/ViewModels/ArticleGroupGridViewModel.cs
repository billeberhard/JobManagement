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

        public ICommand LoadCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICommand SelectionChangedCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICommand NewCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICommand DeleteCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICommand EditCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICommand SearchCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object SelectedItem { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ArticleGroupGridViewModel()
        {
            var articleGroups = m_Repo.ArticleGroups.GetAllAtRoot();
            LoadData(articleGroups);
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
