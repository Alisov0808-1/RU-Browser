using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProgressBar = System.Windows.Forms.ProgressBar;

namespace CefSharp.Example
{
    public class DownloadHandler : IDownloadHandler
    {
        public event EventHandler<DownloadItem> OnBeforeDownloadFired;

        public event EventHandler<DownloadItem> OnDownloadUpdatedFired;
        static public int o;
        static public int o2;
        static public string a9;
        static public string y;
        static public int ded;
        static public bool ch;
        static public bool ch2;
        static public bool n;
        static public string[] all;
        static public bool pau = false;

    
        public DownloadHandler(string a, string b)
        {

        }
        public void OnBeforeDownload(IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
        {
            var handler = OnBeforeDownloadFired;
            if (handler != null)
            {
                handler(this, downloadItem);

            }

            if (!callback.IsDisposed)
            {
                using (callback)
                {
                    callback.Continue(downloadItem.SuggestedFileName, showDialog: true);
                }
            }
        }

        public void OnBeforeDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
        {
            var handler = OnBeforeDownloadFired;
            string a = File.ReadAllText("browser/c.txt");
            if (a == "yu")
            {
                string title;
                title = downloadItem.Url.ToString();
                File.AppendAllText("browser/down.txt", title + "\n");
            }
            if (a == "ys")
            {
                string title;
                title = downloadItem.SuggestedFileName.ToString();
                File.AppendAllText("browser/down.txt", title + "\n");
            }  
       
            if (handler != null)
            {


                handler(this, downloadItem);


            }

            if (!callback.IsDisposed)
            {
                using (callback)
                {
                    callback.Continue(downloadItem.SuggestedFileName, showDialog: true);
                }
            }
        }



        bool IDownloadHandler.CanDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, string url, string requestMethod)
        {

            return true;

        }



        void IDownloadHandler.OnDownloadUpdated(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {
            o = (int)downloadItem.TotalBytes;
            o2 = (int)downloadItem.ReceivedBytes;
            a9 = File.ReadAllLines("browser/down.txt").Last();
            ded = (int)downloadItem.CurrentSpeed;
           
            if (!downloadItem.IsInProgress)
            {
                List<string> down2 = File.ReadAllLines("browser/url.txt").ToList();
                string path = downloadItem.FullPath.ToString();
                if (down2.Last() != path)
                {

                    File.AppendAllText("browser/url.txt", path + "\n");
                }
            }
            y = downloadItem.FullPath;
            n = downloadItem.IsInProgress;
            var handler = OnDownloadUpdatedFired;
            if (handler != null)
            {



                handler(this, downloadItem);

            }
            if (ch == true)
            {
                callback.Cancel();
                callback.Dispose();
            }
            if (DownloadHandler.ch2 && downloadItem.IsInProgress && pau == false)
            {
                callback.Pause();
                pau = true;
            }
            // Проверяем, необходимо ли возобновить загрузку
            else if (pau == true)
            {
                try
                {
                    callback.Resume();
                    pau = false;
                }
                catch { }
            }


        }
        public static int Ded()
        {
            return o2;

        }
        public static int Ded2()
        {
            return o;

        }
        public static string Ded3()
        {
            return a9;

        }
        public static int Ded4()
        {
            return ded;

        }
        public static string Dedok()
        {
            return y;

        }
        public static bool Dedok2()
        {
            return n;

        }
      

        bool IDownloadHandler.OnBeforeDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
        {
            var handler = OnBeforeDownloadFired;
            string a = File.ReadAllText("browser/c.txt");
            if (a == "yu")
            {
                string title;
                title = downloadItem.Url.ToString();
                File.AppendAllText("browser/down.txt", title + "\n");
            }
            if (a == "ys")
            {
                string title;
                title = downloadItem.SuggestedFileName.ToString();
                File.AppendAllText("browser/down.txt", title + "\n");
            }

            if (handler != null)
            {


                handler(this, downloadItem);


            }

           
          
            if (handler != null)
            {
                handler(this, downloadItem);

            }

            if (!callback.IsDisposed)
            {
                using (callback)
                {
                    callback.Continue(downloadItem.SuggestedFileName, showDialog: true);
                }
            }
           return true;
        }
       
    }
}