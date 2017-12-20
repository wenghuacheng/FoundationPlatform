using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordRecoder.Presentation.WPF.Models;

namespace WordRecoder.Presentation.WPF.Services.ConstantDataProvider
{
    public class MainMenuTreeItemsProvider
    {
        public static List<MainMenuTreeItemModel> GetDatas()
        {
            List<MainMenuTreeItemModel> result = new List<MainMenuTreeItemModel>();

            result.Add(new MainMenuTreeItemModel() { Id = 0, Name = "词根录入" });
            result.Add(new MainMenuTreeItemModel() { Id = 1, Name = "单词录入" });
            result.Add(new MainMenuTreeItemModel() { Id = 2, Name = "每日任务" });
            result.Add(new MainMenuTreeItemModel() { Id = 3, Name = "数据统计" });

            return result;
        }
    }
}
