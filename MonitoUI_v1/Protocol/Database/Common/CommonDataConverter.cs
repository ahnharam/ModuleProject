using Protocol.Model.Common;
using Protocol.Model.Dashboard;
using System.Data;

namespace Protocol.Database.DashBoard
{
    public class CommonDataConverter
    {
        public static void GetDeviceList(DeviceList deviceList)
        {
            if (deviceList == null) return;

            foreach (var row in deviceList.Dt.AsEnumerable())  // AsEnumerable() returns IEnumerable<DataRow>
            {
                DeviceM deviceM = new DeviceM(row);

                deviceList.Add(deviceM);
            }
        }

    }
}
