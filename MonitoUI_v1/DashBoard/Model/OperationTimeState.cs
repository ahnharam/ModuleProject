using Prism.Mvvm;
using static Protocol.Enum.DashBoardEnum;

namespace DashBoard.Model
{
    public class OperationTimeState : BindableBase
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string subName;
        public string SubName
        {
            get { return subName; }
            set { SetProperty(ref subName, value); }
        }

        private TimeENEnum timeEN = TimeENEnum.AM;
        public TimeENEnum TimeEN
        {
            get { return timeEN; }
            set { SetProperty(ref timeEN, value); }
        }

        private string time;
        public string Time
        {
            get { return time; }
            set { SetProperty(ref time, value); }
        }
    }
}
