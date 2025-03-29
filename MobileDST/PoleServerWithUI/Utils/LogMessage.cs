using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Threading;

namespace PoleServerWithUI.Utils
{
    internal class LogMessage : BindableBase
    {
        private string DirPath = string.Empty;
        private string FilePath = string.Empty;
        private string ReadDataFilePath = string.Empty;
        private string temp = string.Empty;

        public LogMessage()
        {
            CreateLogFilePath();
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

        private void CreateLogFilePath()
        {
            DirPath = Environment.CurrentDirectory + @"\Log\" + DateTime.Today.ToString("yyyy") + @"\" + DateTime.Today.ToString("MM");
            FilePath = DirPath + "\\Log_" + DateTime.Today.ToString("yyyyMMdd") + ".log";
            ReadDataFilePath = DirPath + "\\DataLog_" + DateTime.Today.ToString("yyyyMMdd") + ".log";
        }

        //
        public void DebugLog(string str)
        {
            //Instance.Log.Add(str);
            Debug.WriteLine(str);
        }

        public void LogWrite(string str)
        {
            Debug.WriteLine(str);
            //Instance.Log.Add(str);
            Instance.LogWriteFile(str, FilePath);
        }

        public void LogWriteView(string str)
        {
            DispatcherService.Invoke((System.Action)(() =>
            {
                Instance.Log.Add(str);
            }));
        }

        public void DataLogWrite(string str)
        {
            LogWriteView(str);
            Instance.LogWriteFile(str, ReadDataFilePath);

            if (Instance.Log.Count > 500)
            {
                DispatcherService.Invoke((System.Action)(() =>
                {
                    Instance.Log.RemoveAt(0);
                }));
            }
        }

        public void LogWriteFile(string str, string path)
        {
            CreateLogFilePath();
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
                Console.WriteLine(e);
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