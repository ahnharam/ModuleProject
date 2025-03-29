using Prism.Mvvm;
using Protocol.Enum;
using Protocol.Login;
using Protocol.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.ShareLib.Cache
{
    public sealed class Cache : BindableBase
    {
        private static readonly Lazy<Cache> lazy = new Lazy<Cache>(() => new Cache());

        public static Cache Instance => lazy.Value;

        private LoginFormat user;
        public LoginFormat User
        {
            get { return user ?? null; }
            set { SetProperty(ref user, value); }
        }

        private DeviceList deviceList;
        public DeviceList DeviceList
        {
            get { return deviceList ?? null; }
            set { SetProperty(ref deviceList, value); }
        }

        private int defaultDashBoard = 0;
        public int DefaultDashBoardNo
        {
            get { return defaultDashBoard; }
            set { SetProperty(ref defaultDashBoard, value); }
        }

        public int GetUserAuthinfo(int type)
        {
            switch (type)
            {
                case 1:
                    return user.Auth;
                case 2:
                    return user.Level;
                case 3:
                    return user.Config;
                case 4:
                    return user.Function;
                default:
                    return 0;
            }
        }
    }
}
