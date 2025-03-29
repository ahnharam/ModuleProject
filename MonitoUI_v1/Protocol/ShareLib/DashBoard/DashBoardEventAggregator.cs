using Prism.Events;
using Protocol.Model.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.ShareLib.DashBoard
{
    public class DashBoardScreenSelectPublisher : PubSubEvent<int> { };
    public class DashBoardDefaultStationNoSelectPublisher : PubSubEvent<int> { };
    public class DashBoardStationNoSelectPublisher : PubSubEvent<int> { };
    public class DashBoardStationSelectPublisher : PubSubEvent<MnStationM> { };
    public class DashBoardStationGroupSelectPublisher : PubSubEvent<int> { };
}
