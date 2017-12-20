using Caliburn.Micro;
using Infrastructure.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WordRecoder.Infrastructure.Container;
using WordRecoder.Presentation.WPF.General;
using WordRecoder.Presentation.WPF.General.Interfaces;
using WordRecoder.Presentation.WPF.Models;
using WordRecoder.Presentation.WPF.Services.ConstantDataProvider;
using WordRecoder.Presentation.WPF.ViewModels.General;
using WordRecoder.Presentation.WPF.ViewModels.Word;
using WordRecoder.Presentation.WPF.Views.Main;

namespace WordRecoder.Presentation.WPF.ViewModels.Main
{
    public class ShellViewModel : Screen, IWaitLayerProvider
    {
        public ShellViewModel()
        {
            var dependencyContainer = IoC.Get<IDependencyContainer>();
            this.ViewAware = dependencyContainer.GetSerivces<IPageManager>() as PageManagerViewModel;

            TreeItems.AddRange(MainMenuTreeItemsProvider.GetDatas());
            TreeItems.FirstOrDefault().IsSelected = true;
            TreeViewSelectedChanged(TreeItems.FirstOrDefault());
        }

        private BindableCollection<MainMenuTreeItemModel> treeItems = new BindableCollection<MainMenuTreeItemModel>();

        public BindableCollection<MainMenuTreeItemModel> TreeItems
        {
            get { return treeItems; }
            set { treeItems = value; }
        }

        private PageManagerViewModel viewAware;
        public PageManagerViewModel ViewAware
        {
            get { return viewAware; }
            set
            {
                viewAware = value;
                NotifyOfPropertyChange(() => ViewAware);
            }
        }

        private bool isWaitLayerOpen;
        public bool IsWaitLayerOpen
        {
            get { return isWaitLayerOpen; }
            set
            {
                isWaitLayerOpen = value;
                NotifyOfPropertyChange(() => IsWaitLayerOpen);
            }
        }

        #region Event Handler
        public void TreeViewSelectedChanged(MainMenuTreeItemModel item)
        {           
            switch (item.Id)
            {
                case 0:
                    ViewAware.SetRootView(new RootListViewModel());
                    break;
                case 1:
                    ViewAware.SetRootView(new WordEditorViewModel());
                    break;
            }

        }
        #endregion

        #region IWaitLayerProvider
        public void ShowDialog()
        {
            IsWaitLayerOpen = true;
        }

        public void CloseDialog()
        {
            IsWaitLayerOpen = false;
        }
        #endregion

    }
}
