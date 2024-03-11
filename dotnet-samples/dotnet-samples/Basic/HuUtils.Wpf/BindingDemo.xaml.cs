using System.Collections.ObjectModel;
using System.Windows;
using HuUtils.Wpf.Model;

namespace HuUtils.Wpf
{
    /// <summary>
    /// BindingDemo.xaml 的交互逻辑
    /// </summary>
    public partial class BindingDemo : Window
    {
        public ObservableCollection<Group> GroupLst = new ObservableCollection<Group>();
        
        public BindingDemo()
        {

            Init();
            //listView.DataContext = GroupLst;
        }

        private void Init()
        {
            for (int i = 0; i < 8; i++)
            {
                Group gp = new Group();
                gp.yhukou = "由户口" + i;
                gp.zhukou = "至户口" + i;
                gp.GroupItemLst = new ObservableCollection<GroupItem>();
                for (int j = 0; j < 2; j++)
                {
                    GroupItem gpItem = new GroupItem();
                    gpItem.cName = "中文" + j;
                    gp.GroupItemLst.Add(gpItem);
                }
                GroupLst.Add(gp);
            }
        }
    }
}
