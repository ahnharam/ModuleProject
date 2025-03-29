using Protocol.Popup;
using Protocol.ShareLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Protocol.Enum.DashBoardEnum;

namespace Protocol.Database.DashBoard
{
    public class CommonDBMessage
    {
        #region Device
        // Select
        public static string SelectDevice()
        {
            return string.Format(
                "SELECT " +
                "`no`, `devicename`, `type`, `powerport`, `sio`, `datavalue` " +
                "FROM " +
                "`devicelist` "
            );
        }

        // Insert
        public static string InsertDevice(int no, string devicename, int type, int powerport, int sio, string datavalue)
        {
            return string.Format(
                "INSERT INTO " +
                "`devicelist`(`no`, `devicename`, `type`, `powerport`, `sio`, `datavalue`) " +
                "VALUES " +
                "({0},`{1}`, {2}, {3}, {4},`{5}`) ",no, devicename, type, powerport, sio, datavalue
            );
        }

        // Update
        public static string UpdateDevice(int no, string devicename, int type, int powerport, int sio, string datavalue)
        {
            return string.Format(
                "UPDATE " +
                "`devicelist` " +
                "SET " +
                "`no` = {0}, `devicename` = `{1}`, `type` = {2}, `powerport` = {3}, `sio` = {4}, `datavalue` = `{5}` "
                , no, devicename, type, powerport, sio, datavalue
                );
        }
        // Delete
        public static string DeleteDevice(int no)
        {
            return string.Format(
                "DELETE " +
                "FROM " +
                "`devicelist` " +
                "WHERE " +
                "`no` = {0} ", no
            );
        }

        #endregion

        #region User
        public static string SelectUser()
        {
            return string.Format(
                "SELECT " +
                "`id`, `pwd`, `name`, `email`, `groupno`, `authgroupno` " +
                "FROM " +
                "`user` "
            );
        }

        public static string SelectWithGroup()
        {
            return string.Format(
                "SELECT " +
                "`user`.`id`, `user`.`pwd`, `user`.`name`, `user`.`email`, `user`.`groupno`, `user`.`authgroupno`, " +
                "`usergroup`.`no`, `usergroup`.`name` " +
                "FROM " +
                "`user` " +
                "INNER JOIN " +
                "`usergroup` " +
                "ON " +
                "`user`.`groupno` = `usergroup`.`no` "
            );
        }
        public static string InsertUser(string id, string pwd, string name, string email, int groupno, int authgroupno)
        {
            return string.Format(
                "INSERT INTO " +
                "`user`(`id`, `pwd`, `name`, `email`, `groupno`, `authgroupno`) " +
                "VALUES " +
                "(`{0}`, `{1}`, `{2}`, `{3}`, {4}, {5}) ",id, pwd, name, email, groupno, authgroupno
            );
        }

        public static string UpdateUser(string id, string pwd, string name, string email, int groupno, int authgroupno)
        {
            return string.Format(
                "UPDATE " +
                "`user` " +
                "SET " +
                "`id` = `{0}`, `pwd` = `{1}`, `name` = `{2}`, `email` = `{3}`, `groupno` = {4}, `authgroupno` = {5} "
                , id, pwd, name, email, groupno, authgroupno
            );
        }

        public static string DeleteUser(string id)
        {
            return string.Format(
                "DELETE " +
                "FROM " +
                "`user` " +
                "WHERE " +
                "`id` = `{0}` ", id
            );
        }
        #endregion

        #region UserState

        public static string SelectUserState()
        {
            return string.Format(
                "SELECT " +
                "`no`, `group`, `status`, `userno` " +
                "FROM " +
                "`userstate` "
            );
        }

        public static string InsertUserState(int no, string group, int status, int userno)
        {
            return string.Format(
                "INSERT INTO " +
                "`userstate`(`no`, `group`, `status`, `userno`) " +
                "VALUES " +
                "({0}, `{1}`, {2}, {3}) ",no, group, status, userno
            );
        }

        public static string UpdateUserState(int no, string group, int status, int userno)
        {
            return string.Format(
                "UPDATE " +
                "`userstate` " +
                "SET " +
                "`no` = {0}, `group` = `{1}`, `status` = {2}, `userno` = {3} "
                , no, group, status, userno
            );
        }

        public static string DeleteUserState(int no)
        {
            return string.Format(
                "DELETE " +
                "FROM " +
                "`userstate` " +
                "WHERE " +
                "`no` = {0} ", no
            );
        }
        #endregion

        #region UserGroup


        public static string SelectUserGroup()
        {
            return string.Format(
                "SELECT " +
                "`no`, `name` " +
                "FROM " +
                "`usergroup` "
             );
        }

        public static string InsertUserGroup(int no, string name)
        {
            return string.Format(
                "INSERT INTO " +
                "`usergroup`(`no`, `name`) " +
                "VALUES " +
                "({0}, `{1}`) ", no, name
            );
        }

        public static string UpdateUserGroup(int no, string name)
        {
            return string.Format(
                "UPDATE " +
                "`usergroup` " +
                "SET " +
                "`no` = {0}, `name` = `{1}` ", no, name
            );
        }

        public static string DeleteUserGroup(int no)
        {
            return string.Format(
                "DELETE " +
                "FROM " +
                "`usergroup` " +
                "WHERE " +
                "`no` = {0} ", no
            );
        }
        #endregion

        #region AuthGroup

        public static string SelectAuthGroup()
        {
            return string.Format(
                "SELECT " +
                "`functiongroupno`, `functionno` " +
                "FROM " +
                "`authgroup` "
            );
        }

        public static string InsertAuthGroup(int functiongroupno, int functionno)
        {
            return string.Format(
                "INSERT INTO " +
                "`authgroup`(`functiongroupno`, `functionno`) " +
                "VALUES " +
                "({0}, {1}) ",functiongroupno, functionno
            );
        }

        public static string UpdateAuthGroup(int functiongroupno, int functionno)
        {
            return string.Format(
                "UPDATE " +
                "`authgroup` " +
                "SET " +
                "`functiongroupno` = {0}, `functionno` = {1} ", functiongroupno, functionno
            );
        }

        public static string DeleteAuthGroup(int functiongroupno)
        {
            return string.Format(
                "DELETE " +
                "FROM " +
                "`authgroup` " +
                "`functiongroupno` = {0} ", functiongroupno
            );
        }
        #endregion

        #region Auth

        public static string SelectAuth()
        {
            return string.Format(
                "SELECT " +
                "`functionno`, `functionname`, `auth` " +
                "FROM " +
                "`auth` "
            );
        }

        public static string InsertAuth(int functionno, string functionname, int auth)
        {
            return string.Format(
                "INSERT INTO " +
                "`auth`(`functionno`, `functionname`, `auth`) " +
                "VALUES " +
                "({0}, `{1}`, {2}) ", functionno, functionname, auth
            );
        }

        public static string UpdateAuth(int functionno, string functionname, int auth)
        {
            return string.Format(
                "UPDATE " +
                "`auth` " +
                "SET" +
                "`functionno` = {0}, `functionname` = `{1}`, auth = {2} ", functionno, functionname, auth
            );
        }

        public static string DeleteAuth(int functionno)
        {
            return string.Format(
                "DELETE " +
                "FROM" +
                "`auth` " +
                "WHERE " +
                "`functionno` = {0} ", functionno
            );
        }
        #endregion

        #region ServerGroup

        public static string SelectServerGroup()
        {
            return string.Format(
                "SELECT " +
                "`no`, `groupno`, `groupname`, `serverno` " +
                "FROM " +
                "`servergroup` "
            );
        }

        public static string InsertServerGroup(int no, int groupno, string groupname, int serverno)
        {
            return string.Format(
                "INSERT INTO " +
                "`servergroup`(`no`, `groupno`, `groupname`, `serverno`) " +
                "VALUES " +
                "({0}, {1}, `{2}`, {3} ", no, groupno, groupname, serverno
            );
        }

        public static string UpdateServerGroup(int no, int groupno, string groupname, int serverno)
        {
            return string.Format(
                "UPDATE" +
                "`servergroup` " +
                "SET " +
                "`no` = {0}, `groupno` = {1}, `groupname` = `{2}`, `serverno` = {3} "
                , no, groupno, groupname, serverno
            );
        }

        public static string DeleteServerGroup(int no)
        {
            return string.Format(
                "DELETE " +
                "FROM " +
                "`servergroup` " +
                "WHERE " +
                "`no` = {0} ", no
            );
        }
        #endregion

        #region Server

        public static string SelectServer()
        {
            return string.Format(
                "SELECT " +
                "`no`, `name`, `sort`, `ip`, `port`, `function`, `value`, `remark` " +
                "FROM " +
                "`server` "
            );
        }

        public static string InsertServer(int no, string name, int sort, string ip, int port, string function, string value, string remark)
        {
            return string.Format(
                "INSERT INTO " +
                "`server`(`no`, `name`, `sort`, `ip`, `port`, `function`, `value`, `remark`) " +
                "VALUES " +
                "({0}, `{1}`, {2}, `{3}`, {4}, `{5}`, `{6}`, `{7}`) ", no, name, sort, ip, port, function, value, remark
            );
        }

        public static string UpdateServer(int no, string name, int sort, string ip, int port, string function, string value, string remark)
        {
            return string.Format(
                "UPDATE " +
                "`server` " +
                "SET " +
                "`no` = {0}, `name` = `{1}`, `sort` = {2}, `ip` = `{3}`, `port` = {4}, `function` = `{5}`, `value` = `{6}`, `remark` = `{7}` "
                , no, name, sort, ip, port, function, value, remark
            );
        }

        public static string DeleteServer(int no)
        {
            return string.Format(
                "DELETE " +
                "FROM " +
                "`server` " +
                "WHERE " +
                "`no` = {0} ", no
            );
        }
        #endregion

        #region ErrorProcess

        public static string SelectErrorProcess()
        {
            return string.Format(
                "SELECT " +
                "`no`, `errorno`, `name`, `repeatcount`, `repeattime`, `smsyn`, `smsreceiveno`, " +
                "`voice`, `deviceno`, `devicefunction` " +
                "FROM " +
                "`errorprocess` "
            );
        }

        public static string InsertErrorProcess(int no, int errorno, string name, int repeatcount, TimeSpan repeattime, 
                                                int smsyn, int smsreceiveno, int voice, int deviceno, int devicefunction)
        {
            return string.Format(
                "INSERT INTO " +
                "`errorprocess`(`no`, `errorno`, `name`, `repeatcount`, `repeattime`, `smsyn`, `smsreceiveno`, " +
                "`voice`, `deviceno`, `devicefunction`) " +
                "VALUES " +
                "({0}, {1}, `{2}`, {3}, `{4}`, {5}, {6}, {7}, {8}, {9} "
                , no, errorno, name, repeatcount, repeattime, smsyn, smsreceiveno, voice, deviceno, devicefunction
            );
        }

        public static string UpdateErrorProcess(int no, int errorno, string name, int repeatcount, TimeSpan repeattime,
                                                int smsyn, int smsreceiveno, int voice, int deviceno, int devicefunction)
        {
            return string.Format(
                "UPDATE " +
                "`errorprocess` " +
                "SET " +
                "`no` = {0}, `errorno` = {1}, `name` = `{2}`, `repeatcount` = {3}, `repeattime` = `{4}`, `smsyn` = {5}, `smsreceiveno` = {6}, " +
                "`voice` = {7}, `deviceno` = {8}, `devicefunction` = {9} "
                , no, errorno, name, repeatcount, repeattime, smsyn, smsreceiveno, voice, deviceno, devicefunction
            );
        }

        public static string DeleteErrorProcess(int no)
        {
            return string.Format(
                "DELETE " +
                "FROM " +
                "`errorprocess` " +
                "WHERE " +
                "`no` = {0} ", no
            );
        }
        #endregion

        #region ErrorCode

        public static string SelectErrorCode()
        {
            return string.Format(
                "SELECT " +
                "`no`, `errorcode`, `errorname` " +
                "FROM " +
                "`errorcode` "
            );
        }

        public static string InsertErrorCode(int no, int errorcode, string errorname)
        {
            return string.Format(
                "INSERT INTO " +
                "`errorcode`(`no`, `errorcode`, `errorname`) " +
                "VALUES " +
                "({0}, {1}, `{2}`) ", no, errorcode, errorname
            );
        }

        public static string UpdateErrorCode(int no, int errorcode, string errorname)
        {
            return string.Format(
                "UPDATE " +
                "`errorcode` " +
                "SET " +
                "`no` = {0}, `errorcode` = {1}, `errorname` = `{2}` "
                , no, errorcode, errorname
            );
        }

        public static string DeleteErrorCode(int no)
        {
            return string.Format(
                "DELETE " +
                "FROM " +
                "`errorcode` " +
                "WHERE " +
                "`no` = {0} ", no
            );
        }
        #endregion
    }
}
