using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Enum
{
    public class CommonEnum
    {
        public enum ViewPanel : int { CONFIG = 1 , DASHBOARD, GISMAP, VIEWER, FIND, ALARM, SYSTEM }

        public enum GroupItemType : int { Group = 1, Item }
    }
}
