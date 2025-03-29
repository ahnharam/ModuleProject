using Prism.Mvvm;
using System.Collections.ObjectModel;
using static Protocol.Enum.CommonEnum;

namespace Protocol.Model.Common
{
    public class GroupTreeItem : BindableBase
    {
        public string Name { get; set; }

        public int No { get; set; }

        public bool LoadItems { get; set; }

        public bool IsFirst { get; set; }

        public GroupItemType GroupSort { get; set; }

        public ObservableCollection<GroupTreeItem> Items { get; set; }

        public GroupTreeItem(string name, int no, GroupItemType groupSort, bool isFirst = false)
        {
            this.Name = name;
            this.No = no;
            this.IsFirst = isFirst;
            this.GroupSort = groupSort;
            this.Items = new ObservableCollection<GroupTreeItem>();
        }

        public void AddItem(string groupName, int groupNo, GroupItemType groupSort)
        {
            GroupTreeItem item = new GroupTreeItem(groupName, groupNo, groupSort);
            this.Items.Add(item);
        }
    }

    public class GroupTree : ObservableCollection<GroupTreeItem>
    { }
}