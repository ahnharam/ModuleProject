using static Protocol.Enum.DashBoardEnum;

namespace Protocol.Database.DashBoard
{
    public class DashBoardDBMessage
    {
        public static string SelectPenel()
        {
            return string.Format(
                "SELECT " +
                "`no`, `name`, `use`, `panel`, `panelno` " +
                "FROM " +
                "`mnconfig` "
            );
        }

        public static string DefaultScreenNo()
        {
            return string.Format(
                "SELECT " +
                "`no` " +
                "FROM " +
                "`mnstation` " +
                "WHERE " +
                "`default` = 1 "
            );
        }

        public static string SelectAllGroup()
        {
            return string.Format(
                "SELECT " +
                "`no`, `name`, `higherno`, `sort`, `screenno`, `screentype` " +
                "FROM " +
                "`group` "
            );
        }

        public static string SelectStationGroup()
        {
            return string.Format(
                "SELECT " +
                "`no`, `name`, `higherno`, `sort`, `screenno`, `screentype` " +
                "FROM " +
                "`group` " +
                "WHERE " +
                "`sort` = 2 "
            );
        }

        public static string SelectGroupOneWithSubGroup(int groupNo)
        {
            return string.Format(
                "SELECT " +
                "`no`, `name`, `higherno`, `sort`, `screenno`, `screentype` " +
                "FROM " +
                "`group` " +
                "WHERE " +
                "`groupno` = {0} ", groupNo
            );
        }

        public static string SelectSubGroup(int highergroupNo)
        {
            return string.Format(
                "SELECT " +
                "`no`, `name`, `higherno`, `sort`, `screenno`, `screentype` " +
                "FROM " +
                "`group` " +
                "WHERE " +
                "`highergroupno` = {0}", highergroupNo
            );
        }

        public static string SelectGroupToHigherGroupNoWithSort(int groupNo)
        {
            return string.Format(
                "SELECT " +
                "`no`, `name`, `higherno`, `sort`,  `screenno`,`screentype` " +
                "FROM " +
                "`group` " +
                "WHERE " +
                "`higherno` = {0} " +
                "AND `sort` = 2 ", groupNo
            );
        }

        public static string SelectStation()
        {
            return string.Format(
               "SELECT " +
               "`no`, `groupno`, `name`, `deviceno`, `ip`, `sort`, `defaultyn` " +
               "FROM " +
               "`mnstation` "
           );
        }

        public static string SelectStationOne(int stationNo)
        {
            return string.Format(
               "SELECT " +
               "`no`, `groupno`, `name`, `deviceno`, `ip`, `sort`, `defaultyn` " +
               "FROM " +
               "`mnstation` " +
               "WHERE " +
               "`no` = {0}", stationNo
           );
        }

        public static string SelectStationWithGroupNo(int groupNo)
        {
            return string.Format(
               "SELECT " +
               "`no`, `groupno`, `name`, `deviceno`, `ip`, `sort`, `defaultyn` " +
               "FROM " +
               "`mnstation` " +
                "WHERE " +
                "`groupno` = {0}", groupNo
           );
        }

        public static string SelectDeviceListFromStationNo(int stationNo, DeviceType deviceType)
        {
            return string.Format(
                "SELECT " +
                "`no`, `stationno`, `name`, `classname`, `device`, `function`, `defaultvalue`, `type`, `sort` " +
                "FROM " +
                "`mncontrol` " +
                "WHERE " +
                "`stationno` = {0} " +
                "AND `classname` = '{1}'", stationNo, deviceType.ToString().ToLower()
            );
        }

        public static string SelectDeviceFunctionListFromGroupNo(int groupNo)
        {
            return string.Format(
                "SELECT " +
                "`no`, `function`,`functionvalue`, `name`, `groupno` " +
                "FROM " +
                "`devicefunction`" +
                "WHERE " +
                "`groupno` = {0}", groupNo
            );
        }

        public static string SelectTimeListFromStationNo(int stationNo)
        {
            return string.Format(
                "SELECT " +
                "`no`, `group`, `stationno`, `stationname`, `starttime`, `endtime`, `user`, `visitantmon`, `visitantday`, `sort` " +
                "FROM " +
                "`stoperate_com` " +
                "WHERE " +
                "`stationno` = {0}", stationNo
            );
        }

        public static string SelectRealTimeDeviceListFromStationNo(int stationNo, DeviceType deviceType)
        {
            /*
             * SELECT `op`.`no`, `op`.`groupno`, `op`.`stationname`, `op`.`device`, `op`.`dicon`, `op`.`defaultvalue`, `op`.`sort`, `df`.`function`, `df`.`functionvalue`, `df`.`name`, `df`.`groupno`
                FROM `mnoperation` op
                LEFT JOIN `devicefunction` df
                ON `op`.defaultvalue = `df`.`no`
                WHERE `op`.`groupno` = 1
             */
            return string.Format(
                "SELECT " +
                "`op`.`no`, `op`.`groupno`, `op`.`stationname`, `op`.`device`, `op`.`dicon`, `op`.`defaultvalue`, `op`.`sort`, `df`.`function`, `df`.`functionvalue`, `df`.`name` " +
                "FROM `mnoperation` op " +
                "LEFT JOIN `devicefunction` df " +
                "ON `op`.defaultvalue = `df`.`no` " +
                "WHERE " +
                "`op`.`groupno` = {0} "
                , stationNo, deviceType.ToString().ToLower()
            );
        }

        public static string SelectDeviceFunctionList()
        {
            return string.Format(
                "SELECT " +
                "`no`, `function`, `functionvalue`, `name`, `groupno` " +
                "FROM " +
                "`devicefunction` "
            );
        }

        public static string SelectDeviceFunctionListFromDGroup(int stationNo, DeviceType deviceType)
        {
            return string.Format(
                "SELECT " +
                "`no`, `groupno`, `stationname`, `device`, `dicon`, `defaultvalue`, `sort` " +
                "FROM " +
                "`mnoperation` " +
                "WHERE " +
                "`groupno` = {0} "
                , stationNo, deviceType.ToString().ToLower()
            );
        }
    }
}