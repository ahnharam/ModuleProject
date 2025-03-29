using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Enum
{
    public class DashBoardEnum
    {
        public enum TimeENEnum : int { AM = 1, PM }

        public enum GroupSort : int { Screen = 1, Station }

        public enum DeviceType : int { Power = 1, Control }

        public enum BroadcastType : int { Auto = 1, Live, Com }
    }
}
