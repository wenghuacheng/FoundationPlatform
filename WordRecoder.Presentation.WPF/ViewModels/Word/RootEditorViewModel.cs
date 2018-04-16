using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using WordRecoder.Domain.ValueObjects;
using Infrastructure.Extensions;
using AutoMapper;
using WordRecoder.Infrastructure.Container;
using WordRecoder.Presentation.WPF.Models.DisplayModels;
using WordRecoder.Application.IApplicationServices;
using WordRecoder.Application.Dto;

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
