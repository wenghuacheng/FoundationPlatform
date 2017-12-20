using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using WordRecoder.Domain.ValueObjects;
using Infrastructure.Extensions;
using WordRecoder.Infrastructure.Container;
using WordRecoder.Application.IApplicationServices;
using WordRecoder.Application.Dto;
using System.Windows;
using WordRecoder.Presentation.WPF.General.Interfaces;
using WordRecoder.Presentation.WPF.CustomerControls.AutoCompleteTextbox;
using AutoMapper;

namespace WordRecoder.Presentation.WPF.ViewModels.Word
{
    public class WordEditorViewModel : ViewAware
    {
        public const string PrefixString = "Prefix";
        public const string RootString = "Root";
        public const string SuffixString = "Suffix";

        public WordEditorViewModel()
        {
            WordTypes.AddRange(typeof(WordType).ToList().Select(p => new WordTypeDisplayModel() { Type = (WordType)p.Key }));
            this.Model = new WordDisplayModel();
        }

        public WordEditorViewModel(WordDisplayModel model)
        {
            WordTypes.AddRange(typeof(WordType).ToList().Select(p => new WordTypeDisplayModel() { Type = (WordType)p.Key }));
            this.Model = model;
        }

        #region Properties
        private BindableCollection<WordTypeDisplayModel> wordTypes = new BindableCollection<WordTypeDisplayModel>();
        public BindableCollection<WordTypeDisplayModel> WordTypes
        {
            get { return wordTypes; }
            set
            {
                wordTypes = value;
                NotifyOfPropertyChange(() => WordTypes);
            }
        }

        private WordDisplayModel model;

        public WordDisplayModel Model
        {
            get { return model; }
            set
            {
                model = value;
                NotifyOfPropertyChange(() => Model);
            }
        }

        private BindableCollection<AutoCompleteRootDisplayModel> prefixDataSource = new BindableCollection<AutoCompleteRootDisplayModel>();
        public BindableCollection<AutoCompleteRootDisplayModel> PrefixDataSource
        {
            get { return prefixDataSource; }
            set { prefixDataSource = value; NotifyOfPropertyChange(() => PrefixDataSource); }
        }

        private BindableCollection<AutoCompleteRootDisplayModel> rootDataSource = new BindableCollection<AutoCompleteRootDisplayModel>();
        public BindableCollection<AutoCompleteRootDisplayModel> RootDataSource
        {
            get { return rootDataSource; }
            set { rootDataSource = value; }
        }

        private BindableCollection<AutoCompleteRootDisplayModel> suffixDataSource = new BindableCollection<AutoCompleteRootDisplayModel>();
        public BindableCollection<AutoCompleteRootDisplayModel> SuffixDataSource
        {
            get { return suffixDataSource; }
            set { suffixDataSource = value; }
        }
        #endregion

        #region Event Handler
        public async void PrefixInput(RoutedEventArgs args)
        {
            AutoCompleteTextbox control = args.Source as AutoCompleteTextbox;
            if (control == null) return;

            var services = IoC.Get<IDependencyContainer>().GetSerivces<IRootSerivce>();

            var source = await services.QueryRoot(new RootDto() { Name = args.OriginalSource.ToString() });
            var items = source.Select(p => new AutoCompleteRootDisplayModel(p));

            if (control.Tag.ToString() == PrefixString)
            {
                PrefixDataSource.Clear();
                PrefixDataSource.AddRange(items);
            }
            else if (control.Tag.ToString() == RootString)
            {
                RootDataSource.Clear();
                RootDataSource.AddRange(items);
            }
            else if (control.Tag.ToString() == SuffixString)
            {
                SuffixDataSource.Clear();
                SuffixDataSource.AddRange(items);
            }
        }

        public void ItemSelected(RoutedEventArgs args)
        {
            AutoCompleteTextbox control = args.Source as AutoCompleteTextbox;

            var item = args.OriginalSource as AutoCompleteRootDisplayModel;
            if (item == null || control == null) return;

            if (control.Tag.ToString() == PrefixString)
                this.Model.PrefixId = item.Id;
            else if (control.Tag.ToString() == RootString)
                this.Model.RootId = item.Id;
            else if (control.Tag.ToString() == SuffixString)
                this.Model.SuffixId = item.Id;
        }

        public void Save()
        {
            var services = IoC.Get<IDependencyContainer>().GetSerivces<IWordService>();
            services.AddOrUpdateWord(Mapper.Map<WordDto>(this.Model));
        }

        #endregion

        #region Inner Class
        public class WordDisplayModel : PropertyChangedBase
        {
            private int id;
            public int Id
            {
                get { return id; }
                set { id = value; }
            }

            private string name;
            public string Name
            {
                get { return name; }
                set
                {
                    name = value;
                    NotifyOfPropertyChange(() => Name);
                }
            }

            /// <summary>
            /// 含义
            /// </summary>
            private string mean;
            public string Mean
            {
                get { return mean; }
                set
                {
                    mean = value;
                    NotifyOfPropertyChange(() => Mean);
                }
            }

            /// <summary>
            /// 助记词
            /// </summary>
            private string mnemonicWord;
            public string MnemonicWord
            {
                get { return mnemonicWord; }
                set
                {
                    mnemonicWord = value;
                    NotifyOfPropertyChange(() => MnemonicWord);
                }
            }

            /// <summary>
            /// 帮助说明
            /// </summary>
            private string helpMsg;
            public string HelpMsg
            {
                get { return helpMsg; }
                set
                {
                    helpMsg = value;
                    NotifyOfPropertyChange(() => HelpMsg);
                }
            }


            public List<int> RootIds
            {
                get
                {
                    return new List<int>() { PrefixId, RootId, SuffixId }.Where(p => p > 0).ToList();
                }
            }

            public int PrefixId { get; set; }
            public int RootId { get; set; }
            public int SuffixId { get; set; }

        }

        public class WordTypeDisplayModel : PropertyChangedBase
        {
            private bool isSelected;
            public bool IsSelected
            {
                get { return isSelected; }
                set
                {
                    isSelected = value;
                    NotifyOfPropertyChange(() => IsSelected);
                }
            }

            private WordType type;
            public WordType Type
            {
                get { return type; }
                set
                {
                    type = value;
                    NotifyOfPropertyChange(() => Type);
                    NotifyOfPropertyChange(() => Description);
                }
            }

            public string Description
            {
                get { return Type.GetDescription(); }
            }
        }

        public class AutoCompleteRootDisplayModel : PropertyChangedBase, ISelectedable
        {
            public AutoCompleteRootDisplayModel(RootDto root)
            {
                this.Id = root.Id;
                this.Type = root.Type;
                this.Name = root.Name;
                this.Mean = root.Mean;
                this.ChineseMean = root.ChineseMean;
            }


            public int Id { get; private set; }

            public RootType Type { get; set; }

            public string Name { get; set; }

            public string Mean { get; set; }

            public string ChineseMean { get; set; }

            private bool isSelected;

            public bool IsSelected
            {
                get { return isSelected; }
                set
                {
                    isSelected = value;
                    NotifyOfPropertyChange(() => IsSelected);
                }
            }

        }
        #endregion
    }
}
