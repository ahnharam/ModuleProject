using System;
using static Protocol.Enum.DashBoardEnum;

namespace Protocol.Database.Config
{
    public class ConfigDBMessage
    {
        #region SnsMessage
        public static string SelectSnsMessage()
        {
            return string.Format(
                "SELECT " +
                "`no`, `sender`, `title`, `msg`, `remark` " +
                "FROM " +
                "`smssendinfo` "
            );
        }

        public static string InsertSnsMessage(int no, int sender, string title, string msg, string remark)
        {
            return string.Format(
                "INSERT INTO " +
                "`smssendinfo`(`no`, `sender`, `title`, `msg`, `remark`) " +
                "VALUES " +
                "({0}, {1}, `{2}`, `{3}`, `{4}`) ", no, sender, title, msg, remark
            );
        }

        public static string UpdateSnsMessage(int no, int sender, string title, string msg, string remark)
        {
            return string.Format(
                "UPDATE " +
                "`smssendinfo` " +
                "SET " +
                "`no` = {0}, `sender` = {1}, `title` = `{2}`, `msg` = `{3}`, `remark` = `{4}` "
                , no, sender, title, msg, remark
            );
        }

        public static string DeleteSnsMessage(int no)
        {
            return string.Format(
                "DELETE " +
                "FROM " +
                "`smssendinfo` " +
                "WHERE " +
                "`no` = {0} ", no
            );
        }
        #endregion

        #region SnsReceiver
        public static string SelectSnsReceiver()
        {
            return string.Format(
                "SELECT " +
                "`no`, `receiver`, `recevename`, `mappingkey`, `remark` " +
                "FROM " +
                "`smsreceiverinfo` "
            );
        }

        public static string InsertSnsReceiver(int no, string receiver, string recevename, string mappingkey, string remark)
        {
            return string.Format(
                "INSERT INTO " +
                "`smsreceiverinfo`(`no`, `receiver`, `recevename`, `mappingkey`, `remark`) " +
                "VALUES " +
                "`({0}, `{1}`, `{2}`, `{3}`, `{4}`) ", no, receiver, recevename, mappingkey, remark
            );
        }

        public static string UpdateSnsReceiver(int no, string receiver, string recevename, string mappingkey, string remark)
        {
            return string.Format(
                "UPDATE " +
                "`smsreceiverinfo` " +
                "SET " +
                "`no` = {0}, `receiver` = `{1}`, `recevename` = `{2}`, `mappingkey` = `{3}`, `remark` = `{4}` "
                , no, receiver, recevename, mappingkey, remark
            );
        }

        public static string DeleteSnsReceiver(int no)
        {
            return string.Format(
                "DELETE " +
                "FROM " +
                "`smsreceiverinfo` " +
                "WHERE " +
                "`no` = {0} ", no
            );
        }
        #endregion

        public static string SelectUserState()
        {
            return string.Format(
                "SELECT " +
                "`no`, `id`, `group`, `name`, `emial` " +
                "FROM " +
                "`userstate` "
            );
        }

        public static string SelectServer()
        {
            return string.Format(
                "SELECT "+
                "`serverno`, `servername`,`sort`, `ioaddr`, `secondaryportno` "+
                "FROM "+
                "`server` "
            );
        }
        #region VoiceSchedule
        public static string SelectVoiceSchedule()
        {
            return string.Format(
                "SELECT " + 
                "`no`, `section`, `time`, `voiceno` " +
                "FROM " +
                "`voiceschedule` "
            );
        }

        public static string InsertVoiceSchedule(int no, int section, TimeSpan time, int voiceno)
        {
            return string.Format(
                "INSERT INTO " +
                "`voiceschedule`(`no`, `section`, `time`, `voiceno`) " +
                "VALUES " +
                "({0}, {1}, `{2}`, {3}) ", no, section, time, voiceno
            );
        }

        public static string UpdateVoiceSchedule(int no, int section, TimeSpan time, int voiceno)
        {
            return string.Format(
                "UPDATE " +
                "`voiceschedule` " +
                "SET " +
                "`no` = {0}, `section` = {1}, `time` = `{2}`, `voiceno` = {3} ", no, section, time, voiceno
            );
        }

        public static string DeleteVoiceSchedule(int no)
        {
            return string.Format(
                "DELETE " +
                "FROM " +
                "`voiceschedule` " +
                "WHERE " +
                "`no` = {0} ", no
            );
        }
        #endregion

        #region Voice
        public static string SelectVoice()
        {
            return string.Format(
                "SELECT " +
                "`no`, `title`, `voiceno`, `memo`, remark` " +
                "FROM " +
                "`voice` "
            );
        }

        public static string InsertVoice(int no, string title, int voiceno, string memo, string remark)
        {
            return string.Format(
                "INSERT INTO " +
                "`voice`(`no`, `title`, `voiceno`, `memo`, `remark`) " +
                "VALUES " +
                "({0}, `{1}`, {2}, `{3}`, `{4}` ", no, title, voiceno, memo, remark
            );
        }

        public static string UpdateVoice(int no, string title, int voiceno, string memo, string remark)
        {
            return string.Format(
                "UPDATE " +
                "`voice` " +
                "SET " +
                "`no` = {0}, `title` = `{1}`, `voiceno` = {2}, `memo` = `{3}`, `remark` = `{4}` "
                , no, title, voiceno, memo, remark
            );
        }

        public static string DeleteVoice(int no)
        {
            return string.Format(
                "DELETE " +
                "FROM " +
                "`voice` " +
                "WHERE " +
                "`no` = {0} ", no
            );
        }
        #endregion

        #region IoSchedule
        public static string SelectIoSchedule()
        {
            return string.Format(
                "SELECT " +
                "`no`, `section`, `iono`, `date`, `starttime`, `endtime` " +
                "FROM " +
                "`ioschedule` "
            );
        }

        public static string InsertIoSchedule(int no, int section, int iono, DateTime date, TimeSpan starttime, TimeSpan endtime)
        { 
            return string.Format(
                "INSERT INTO " +
                "`ioschedule`(`no`, `section`, `iono`, `date`, `starttime`, `endtime` " +
                "VALUES " +
                "({0}, {1}, {2}, `{3}`, `{4}`, `{5}`) ", no, section, iono, date, starttime, endtime
            );
        }

        public static string UpdateIoSchedule(int no, int section, int iono, DateTime date, TimeSpan starttime, TimeSpan endtime)
        {
            return string.Format(
                "UPDATE " +
                "`ioschedule` " +
                "SET " +
                "`no` = {0}, `section` = {1}, `iono` = {2}, `date` = `{3}`, `starttime` = `{4}`, `endtime` = `{5}` "
                , no, section, iono, date, starttime, endtime
            );
        }

        public static string DeleteIoSchedule(int no)
        {
            return string.Format(
                "DELETE " +
                "FROM " +
                "`ioschedule` " +
                "WHERE " +
                "`no` = {0} ", no
            );
        }
        #endregion

        #region DeviceSchedule

        public static string SelectDeviceSchedule()
        {
            return string.Format(
                "SELECT " +
                "`no`, `date`, `deviceno`, `starttime`, `endtime`, `errorvalue`, " +
                "`settingvalue`, `maxvalue`, `minvalue`, `settingmode`, `smsreceiveno` " +
                "FROM " +
                "`deviceschedule` "
            );
        }

        public static string InsertDeviceSchedule(int no, DateTime date, int deviceno, TimeSpan starttime, TimeSpan endtime, 
                                                  int errorvalue, int settingvalue, int maxvalue, int minvalue, int settingmode, int smsreceiveno)
        {
            return string.Format(
                "INSERT INTO " +
                "`deviceschedule`(`no`, `date`, `deviceno`, `starttime`, `endtime`, `errorvalue`, " +
                "`settingvalue`, `maxvalue`, `minvalue`, `settingmode`, `smsreceiveno`) " +
                "VALUES " +
                "({0}, `{1}`, {2}, `{3}`, `{4}`, {5}, {6}, {7}, {8}, {9}, {10}) "
                , no, date, deviceno, starttime, endtime, errorvalue, settingvalue, maxvalue, minvalue, settingmode, smsreceiveno
            );
        }

        public static string UpdateDeviceSchedule(int no, DateTime date, int deviceno, TimeSpan starttime, TimeSpan endtime,
                                                  int errorvalue, int settingvalue, int maxvalue, int minvalue, int settingmode, int smsreceiveno)
        {
            return string.Format(
                "UPDATE " +
                "`deviceschedule` " +
                "SET " +
                "`no` = {0}, `date` = `{1}`, `deviceno` = {2}, `starttime` = `{3}`, `endtime` = `{4}`, `errorvalue` = {5} " +
                "`settingvalue` = {6}, `maxvalue` = {7}, `minvalue` = {8}, `settingmode` = {9}, `smsreceiveno` = {10} "
                , no, date, deviceno, starttime, endtime, errorvalue, settingvalue, maxvalue, minvalue, settingmode, smsreceiveno
            );
        }

        public static string DeleteDeviceSchedule(int no)
        {
            return string.Format(
                "DELETE " +
                "FROM " +
                "`deviceschedule` " +
                "WHERE " +
                "`no` = {0} ", no
            );
        }
        #endregion
    }
}