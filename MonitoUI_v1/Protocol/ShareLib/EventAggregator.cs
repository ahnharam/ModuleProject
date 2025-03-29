using Prism.Events;
using Protocol.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Protocol.Enum.CommonEnum;

namespace Protocol.ShareLib
{

    /// <summary>
    /// 
    /// </summary>
    public class DatabaseConnectPublisher : PubSubEvent<string> { };

    /// <summary>
    /// 
    /// </summary>
    public class LoginPublisher : PubSubEvent<LoginFormat> { };
    public class ViewPanelChangePublisher : PubSubEvent<ViewPanel> { };
}
