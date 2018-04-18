using Domain.Core.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordRecoder.Presentation.WPF.General.Interfaces
{
    public interface IHaveToolBarButton
    {
        List<ToolBarButton> GetToolBarButton();

        void Execute(ToolBarButton toolBar);
    }

    public class ToolBarButton
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }
    }
}
