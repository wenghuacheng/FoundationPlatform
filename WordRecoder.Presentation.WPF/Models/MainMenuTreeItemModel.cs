using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordRecoder.Presentation.WPF.Models
{
    public class MainMenuTreeItemModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ParentId { get; set; }

        public bool IsSelected { get; set; }
    }
}
