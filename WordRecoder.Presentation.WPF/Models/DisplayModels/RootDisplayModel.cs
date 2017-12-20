using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordRecoder.Domain.ValueObjects;
using WordRecoder.Presentation.WPF.CustomerControls.CustomerControls.MultiTextboxInput;

namespace WordRecoder.Presentation.WPF.Models.DisplayModels
{
    public class RootDisplayModel : PropertyChangedBase
    {
        public RootDisplayModel()
        {
            Derivative = new BindableCollection<InputModel>();
        }

        #region Properties

        public int Id { get; set; }

        private string name;
        /// <summary>
        /// 词根
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        private RootType type;
        /// <summary>
        /// 词根类型
        /// </summary>
        public RootType Type
        {
            get { return type; }
            set
            {
                type = value;
                NotifyOfPropertyChange(() => Type);
            }
        }

        private string mean;
        /// <summary>
        /// 英文映射
        /// </summary>
        public string Mean
        {
            get { return mean; }
            set
            {
                mean = value;
                NotifyOfPropertyChange(() => Mean);
            }
        }

        private string chineseMean;
        /// <summary>
        /// 中文含义
        /// </summary>
        public string ChineseMean
        {
            get { return chineseMean; }
            set
            {
                chineseMean = value;
                NotifyOfPropertyChange(() => ChineseMean);
            }
        }

        private string remark;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set
            {
                remark = value;
                NotifyOfPropertyChange(() => Remark);
            }
        }

        private BindableCollection<InputModel> derivative;
        public BindableCollection<InputModel> Derivative
        {
            get { return derivative; }
            set
            {
                derivative = value;
                NotifyOfPropertyChange(() => Derivative);
            }
        }
        #endregion

    }
}
