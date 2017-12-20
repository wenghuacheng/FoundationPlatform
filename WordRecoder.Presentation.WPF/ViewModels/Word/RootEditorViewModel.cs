using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordRecoder.Domain.ValueObjects;
using Infrastructure.Extensions;
using static WordRecoder.Presentation.WPF.CustomerControls.CustomerControls.MultiTextboxInput.MultiTextboxInput;
using WordRecoder.Presentation.WPF.CustomerControls.CustomerControls.MultiTextboxInput;
using WordRecoder.Application.IApplicationServices;
using AutoMapper;
using WordRecoder.Application.Dto;
using WordRecoder.Infrastructure.Container;
using WordRecoder.Domain.IRepository;
using MaterialDesignThemes.Wpf;
using System.Threading;
using WordRecoder.Presentation.WPF.General;
using WordRecoder.Presentation.WPF.General.Interfaces;
using WordRecoder.Presentation.WPF.Models.DisplayModels;

namespace WordRecoder.Presentation.WPF.ViewModels.Word
{
    public class RootEditorViewModel : ViewAware
    {
        private IRootSerivce mRootSerivce;

        public RootEditorViewModel(RootDisplayModel model = null)
        {
            RootTypeList = typeof(RootType).ToList();
            var container = IoC.Get<IDependencyContainer>();
            this.mRootSerivce = container.GetSerivces<IRootSerivce>();
            if (model == null)
                Model = new RootDisplayModel();
            else
                Model = model;
        }

        #region Properties
        private RootDisplayModel model;
        public RootDisplayModel Model
        {
            get { return model; }
            set
            {
                model = value;
                NotifyOfPropertyChange(() => Model);
            }
        }

        private List<KeyValuePair<Enum, string>> rootTypeList;
        public List<KeyValuePair<Enum, string>> RootTypeList
        {
            get { return rootTypeList; }
            set { rootTypeList = value; }
        }

        #endregion

        #region Event Handler
        public async void Save()
        {
            try
            {
                await mRootSerivce.AddOrUpdateRoot(Mapper.Map<RootDto>(this.Model));
                this.Model = new RootDisplayModel();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

    }
}
