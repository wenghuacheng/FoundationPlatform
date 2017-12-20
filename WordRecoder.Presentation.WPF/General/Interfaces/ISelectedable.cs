using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordRecoder.Presentation.WPF.General.Interfaces
{
    public interface ISelectedable : IDisplayMember
    {
        bool IsSelected { get; set; }
    }


}
