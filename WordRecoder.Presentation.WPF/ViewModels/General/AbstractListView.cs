using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordRecoder.Presentation.WPF.ViewModels.General
{
    public abstract class AbstractListView<T> : ViewAware
    {
        public AbstractListView()
        {
            Items = new BindableCollection<T>();
        }

        private BindableCollection<T> items;

        public BindableCollection<T> Items
        {
            get { return items; }
            set
            {
                items = value;
                NotifyOfPropertyChange(() => Items);
            }
        }



        public abstract Task LoadData();

        protected override void OnViewLoaded(object view)
        {
            this.LoadData();
            base.OnViewLoaded(view);
        }
    }
}
