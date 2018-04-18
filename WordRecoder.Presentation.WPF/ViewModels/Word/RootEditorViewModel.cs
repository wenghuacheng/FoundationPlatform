using AutoMapper;
using Caliburn.Micro;
using Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using WordRecoder.Application.Dto;
using WordRecoder.Application.IApplicationServices;
using WordRecoder.Domain.ValueObjects;
using WordRecoder.Presentation.WPF.Models.DisplayModels;

namespace WordRecoder.Presentation.WPF.ViewModels.Word
{
    public class RootEditorViewModel : ViewAware
    {
        private IRootSerivce mRootSerivce;

        public RootEditorViewModel(RootDisplayModel model = null)
        {
            RootTypeList = typeof(RootType).ToList();
            this.mRootSerivce = IoC.Get<IRootSerivce>();
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
