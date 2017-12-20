using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.ComponentModel.Composition;
using System.Windows;

namespace WordRecoder.Presentation.WPF
{
    [Export(typeof(IWindowManager))]
    public class MetroWindowManager : WindowManager
    {

    }
}
