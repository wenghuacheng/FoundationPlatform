using Caliburn.Micro;
using Domain.Core.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordRecoder.Presentation.WPF.General.Interfaces
{
    public interface IPageManager : ISingletonDependency
    {
        void AddPage(ViewAware viewAware);
    }
}
