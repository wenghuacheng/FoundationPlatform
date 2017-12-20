using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordRecoder.Presentation.WPF.General.Interfaces;

namespace WordRecoder.Presentation.WPF.ViewModels.Main
{
    public class PageManagerViewModel : ViewAware, IPageManager
    {
        private Stack<ViewAware> Items { get; set; }

        private ViewAware currentView;
        public ViewAware CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                NotifyOfPropertyChange(() => CurrentView);
            }
        }

        private List<ToolBarButton> toolBarButtons;
        public List<ToolBarButton> ToolBarButtons
        {
            get { return toolBarButtons; }
            set
            {
                toolBarButtons = value;
                NotifyOfPropertyChange(() => ToolBarButtons);
            }
        }

        public void SetRootView(ViewAware viewAware)
        {
            Items = new Stack<ViewAware>();
            Items.Push(viewAware);
            CurrentView = viewAware;

            var haveToolBarButton = viewAware as IHaveToolBarButton;
            if (haveToolBarButton != null)
                ToolBarButtons = haveToolBarButton.GetToolBarButton();
            else
                ToolBarButtons = new List<ToolBarButton>();
        }

        public void Back()
        {
            if (Items.Count > 1)
            {
                Items.Pop();
                CurrentView = Items.Peek();
                SetToolBarButtons(CurrentView);
            }
        }

        public void AddPage(ViewAware viewAware)
        {
            Items.Push(viewAware);
            CurrentView = Items.Peek();
            SetToolBarButtons(viewAware);
        }

        private void SetToolBarButtons(ViewAware viewAware)
        {
            var haveToolBarButton = viewAware as IHaveToolBarButton;
            if (haveToolBarButton != null)
                ToolBarButtons = haveToolBarButton.GetToolBarButton();
            else
                ToolBarButtons = new List<ToolBarButton>();
        }

        public void ToolBarButtonExecute(ToolBarButton toolBarButton)
        {
            var haveToolBarButton = CurrentView as IHaveToolBarButton;
            if (haveToolBarButton != null)
                haveToolBarButton.Execute(toolBarButton);
        }


    }
}
