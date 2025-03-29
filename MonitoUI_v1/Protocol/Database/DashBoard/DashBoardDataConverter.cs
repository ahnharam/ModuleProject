using MySql.Data.MySqlClient;
using Protocol.Model.Common;
using Protocol.Model.Dashboard;
using Protocol.ShareLib.Cache;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Database.DashBoard
{
    public class DashBoardDataConverter : BaseConverter
    {
        public static void GetPanelList(PanelList list)
        {
            if (list == null) return;

            // iterate over the rows of the datatable
            foreach (var row in list.Dt.AsEnumerable())  // AsEnumerable() returns IEnumerable<DataRow>
            {
                PanelM panelM = new PanelM(row);

                if(panelM.Use == 1)
                {
                    panelM.Height = "auto";
                }
                else
                {
                    panelM.Height = "0";
                }

                list.Add(panelM);
            }
        }

        public static void GetGroupList(GroupList list)
        {
            if (list == null) return;

            // iterate over the rows of the datatable
            foreach (var row in list.Dt.AsEnumerable())  // AsEnumerable() returns IEnumerable<DataRow>
            {
                GroupM groupM = new GroupM(row);

                list.Add(groupM);
            }
        }

        public static int GetGroupOne(GroupList list)
        {
            if (list == null) return -1;

            // iterate over the rows of the datatable
            foreach (var row in list.Dt.AsEnumerable())  // AsEnumerable() returns IEnumerable<DataRow>
            {
                GroupM groupM = new GroupM(row);

                return groupM.GroupNo;
            }

            return -1;
        }

        public static void GetStationList(MnStationList list)
        {
            if (list == null) return;

            // iterate over the rows of the datatable
            foreach (var row in list.Dt.AsEnumerable())  // AsEnumerable() returns IEnumerable<DataRow>
            {
                MnStationM mnStationM = new MnStationM(row);

                list.Add(mnStationM);
            }
        }

        public static void DeviceList(MnControlList list)
        {
            if (list == null) return;

            foreach (var row in list.Dt.AsEnumerable())  // AsEnumerable() returns IEnumerable<DataRow>
            {
                MnControlM deviceM = new MnControlM(row);

                var device = Cache.Instance.DeviceList.Single(deviceObj => deviceObj.No == deviceM.Device);
                deviceM.DeviceM = device;
                
                list.Add(deviceM);
            }
        }

        public static void DeviceFunctionList(DeviceFunctionList list)
        {
            if (list == null) return;

            foreach (var row in list.Dt.AsEnumerable())  // AsEnumerable() returns IEnumerable<DataRow>
            {
                DeviceFunctionM deviceFunctionM = new DeviceFunctionM(row);

                list.Add(deviceFunctionM);
            }
        }

        public static void TimeList(StoperateList list)
        {
            if (list == null) return;

            foreach (var row in list.Dt.AsEnumerable())  // AsEnumerable() returns IEnumerable<DataRow>
            {
                StoperateM timeM = new StoperateM(row);

                list.Add(timeM);
            }
        }

        public static void RealTimeDeviceList(MnOperationList list)
        {
            if (list == null) return;

            foreach (var row in list.Dt.AsEnumerable())  // AsEnumerable() returns IEnumerable<DataRow>
            {
                MnOperationM deviceM = new MnOperationM(row);

                var device = Cache.Instance.DeviceList.Single(deviceObj => deviceObj.No == deviceM.Device);
                deviceM.DeviceM = device;

                list.Add(deviceM);
            }
        }
    }
}
