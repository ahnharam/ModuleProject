using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;

namespace PoleServerWithUI.Model
{
    public class BaseModel : BindableBase
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

        public BaseModel()
        { }

        public BaseModel(DataRow datarow)
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

        protected virtual void ConvertData(DataRow dataRow)
        {
        }
    }

    public class BaseList<T> : ObservableCollection<T>
    {
        public string dbMessage;
        public DataTable dt;

        public BaseList()
        {
            dbMessage = string.Empty;
            dt = new DataTable();
        }

        /// <summary>
        /// Insert Sample : 
        /// return string.Format("SELECT column1, column2 FROM table_name WHERE someCondition = @param1");
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual void SelectData(object obj)
        {
        }

        /// <summary>
        /// Insert Sample : 
        /// return string.Format("INSERT INTO table_name (column1, column2) VALUES (@value1, @value2)");
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual void InsertData(object obj)
        {
        }

        /// <summary>
        /// Update Sample :
        /// return string.Format("UPDATE table_name SET column1 = @newvalue1, column2 = @newvalue2 WHERE id = @id" );
        /// </summary>
        /// <param name="obj">params data</param>
        /// <returns>string format query</returns>
        public virtual void UpdateData(object obj)
        {
        }

        /// <summary>
        /// Delete Sample
        /// return string.Format("DELETE FROM yourTableName WHERE id = @id");
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual void DeleteData(object obj)
        {
        }
    }
}