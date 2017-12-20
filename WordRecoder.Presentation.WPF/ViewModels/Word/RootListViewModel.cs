using AutoMapper;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordRecoder.Application.IApplicationServices;
using WordRecoder.Infrastructure.Container;
using WordRecoder.Presentation.WPF.General.Interfaces;
using WordRecoder.Presentation.WPF.Models.DisplayModels;
using WordRecoder.Presentation.WPF.ViewModels.General;

namespace WordRecoder.Presentation.WPF.ViewModels.Word
{
    public class RootListViewModel : AbstractListView<RootDisplayModel>, IHaveToolBarButton
    {
        private readonly IRootSerivce mRootSerivce;
        private readonly IPageManager mPageManager;

        #region Ctor
        public RootListViewModel() : base()
        {
            var container = IoC.Get<IDependencyContainer>();
            this.mRootSerivce = container.GetSerivces<IRootSerivce>();
            this.mPageManager = container.GetSerivces<IPageManager>();
        }
        #endregion

        public async override Task LoadData()
        {
            try
            {
                var source = await mRootSerivce.QueryRoot(new Application.Dto.RootDto());
                var items = source.Select(p => Mapper.Map<RootDisplayModel>(p)).ToList();
                this.Items.Clear();
                this.Items.AddRange(items);
            }
            catch (Exception ex)
            {

                throw ex;
            }
         
        }

        public void Edit(RootDisplayModel model)
        {
            RootEditorViewModel viewModel = new RootEditorViewModel(model);
            mPageManager.AddPage(viewModel);
        }

        #region IHaveToolBarButton
        public List<ToolBarButton> GetToolBarButton()
        {
            return new List<ToolBarButton>() {
                new ToolBarButton(){ DisplayName="添加",Id=1 },
                new ToolBarButton(){ DisplayName="删除",Id=2 }
            };
        }

        public void Execute(ToolBarButton toolBar)
        {
            switch (toolBar.Id)
            {
                case 1:
                    RootEditorViewModel viewModel = new RootEditorViewModel();
                    mPageManager.AddPage(viewModel);
                    break;
            }
        }
        #endregion
    }
}
