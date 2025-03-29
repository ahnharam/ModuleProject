using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;

namespace Protocol.Model
{
    internal interface IBaseMInterface
    {
        void ConvertData(DataRow dataRow);
    }

    public class BaseM : BindableBase, IBaseMInterface
    {
        public static string ConvertString(DataRow dataRow, string name)
        {
            try
            {
                return dataRow.Field<string>(name);
            }
            catch (Exception e)
            {
                throw new Exception("error : " + e);
            }
        }

        public static int ConvertInt(DataRow dataRow, string name)
        {
            try
            {
                return dataRow.Field<int>(name);
            }
            catch (Exception e)
            {
                throw new Exception("error : " + e);
            }
        }

        public static bool ConvertBoolean(DataRow dataRow, string name)
        {
            try
            {
                return dataRow.Field<bool>(name);
            }
            catch (Exception e)
            {
                throw new Exception("error : " + e);
            }
        }

        public static double ConvertDouble(DataRow dataRow, string name)
        {
            try
            {
                return dataRow.Field<double>(name);
            }
            catch (Exception e)
            {
                throw new Exception("error : " + e);
            }
        }

        public static DateTime ConvertDate(DataRow dataRow, string name)
        {
            try
            {
                return dataRow.Field<DateTime>(name);
            }
            catch (Exception e)
            {
                throw new Exception("error : " + e);
            }
        }

        public static TimeSpan ConvertTime(DataRow dataRow, string name)
        {
            try
            {
                return dataRow.Field<TimeSpan>(name);
            }
            catch (Exception e)
            {
                throw new Exception("error : " + e);
            }
        }

        public BaseM()
        { }

        public BaseM(DataRow datarow)
        {
            try
            {
                ConvertData(datarow);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Model 생성 오류" + e.Message);
            }
        }

        public virtual void ConvertData(DataRow dataRow)
        { }
    }

    public class BaseList<T> : ObservableCollection<T>
    {
        public DataTable Dt { get; set; }

        public BaseList()
        {
            Dt = new DataTable();
        }
    }
}