using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordRecoder.Presentation.WPF.General.Interfaces
{
    public interface IPageManager
    {
        void AddPage(ViewAware viewAware);
    }
}
