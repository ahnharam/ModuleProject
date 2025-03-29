using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace PoleServerWithUI.Utils
{
    class LogMessage : BindableBase
    {
        string DirPath = string.Empty;
        string FilePath = string.Empty;
        string ReadDataFilePath = string.Empty;
        string temp = string.Empty;

        public LogMessage()
        {
            DirPath = Environment.CurrentDirectory + @"\Log\" + DateTime.Today.ToString("yyyy") + @"\" + DateTime.Today.ToString("MM") ;
            FilePath = DirPath + "\\Log_" + DateTime.Today.ToString("yyyyMMdd") + ".log";
            ReadDataFilePath = DirPath + "\\DataLog_" + DateTime.Today.ToString("yyyyMMdd") + ".log";
        }

        // Property
        private static LogMessage _instance { get; set; }
        public static LogMessage Instance
        {
            get
            {
                return _instance ?? (_instance = new LogMessage());
            }
        }

        private ObservableCollection<string> log = new ObservableCollection<string>();
        public ObservableCollection<string> Log
        {
            get { return log; }
            set { SetProperty(ref log, value); }
        }

        public void LogWrite(string str)
        {
            Instance.Log.Add(str);
            Instance.LogWriteFile(str, FilePath);
        }

        public void DataLogWrite(string str)
        {
            Instance.Log.Add(str);
            Instance.LogWriteFile(str, ReadDataFilePath);
        }


        public void LogWriteFile(string str, string path)
        {
            DirectoryInfo di = new DirectoryInfo(DirPath);
            FileInfo fi = new FileInfo(path);

            try
            {
                if (!di.Exists) Directory.CreateDirectory(DirPath);
                if (!fi.Exists)
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        temp = string.Format("[{0}] {1}", DateTime.Now, str);
                        sw.WriteLine(temp);
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        temp = string.Format("[{0}] {1}", DateTime.Now, str);
                        sw.WriteLine(temp);
                        sw.Close();
                    }
                }
            }
            catch (Exception e)
            {
            }
        }
    }
    public static class DispatcherService
    {
        public static void Invoke(Action action)
        {
            Dispatcher dispatchObject = Application.Current != null ? Application.Current.Dispatcher : null;
            if (dispatchObject == null || dispatchObject.CheckAccess())
                action();
            else
                dispatchObject.Invoke(action);
        }
    }


}
