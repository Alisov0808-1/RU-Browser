using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RU_Browser
{
    static class Extension
    {
        async static Task SetProxy(ChromiumWebBrowser cwb, string Address)
        {
            await Cef.UIThreadTaskFactory.StartNew(delegate
            {
                var rc = cwb.GetBrowser().GetHost().RequestContext;
                var v = new Dictionary<string, object>();
                v["mode"] = "fixed_servers";
                v["server"] = Address;
                string error;
                bool success = rc.SetPreference("proxy", v, out error);
            });
        }
        public static void AddInlineCssToPage(string css, string js, ChromiumWebBrowser browser)
        {

            string csss = $"var style = document.createElement('style');" +
                            $"style.innerHTML = `{css}`;" +
                            $"document.head.appendChild(style);";
            string jsWrapped = $"document.addEventListener('DOMContentLoaded', function() {{{js}}});";

            browser.ExecuteScriptAsync(jsWrapped);
            browser.ExecuteScriptAsync(csss);



        }
        static public void Loadded(ChromiumWebBrowser browser)
        {
            string baseDirectory = Environment.CurrentDirectory + @"\browser\exen";

            // MessageBox.Show("", "");
            foreach (var directory in Directory.GetDirectories(baseDirectory))
            {
                string cssFilePath = directory + @"\css.css";
                string[] p = File.ReadAllLines("browser/used.txt");
                string jsFilePath = directory + @"\script.js";
                string helloFilePath = directory + @"\hellowindow.html";
                bool check = false;
                string[] WebList = File.ReadAllLines(directory + @"\WebList.txt");
                foreach (var item in WebList)
                {
                    if (browser.Address.StartsWith(item))
                    {
                        check = true;
                        break;
                    }
                }
                if (check)
                {
                    if (File.Exists(cssFilePath) && File.Exists(jsFilePath))
                    {

                        string cssContent = File.ReadAllText(cssFilePath);
                        string jsContent = File.ReadAllText(jsFilePath);
                        bool used = false;
                        foreach (var item in p)
                        {
                            if (helloFilePath == item) { used = true; break; }



                        }
                        if (!used)
                        {
                            hellowindow_ex hellowindow = new hellowindow_ex(helloFilePath);
                            hellowindow.Show();

                            File.AppendAllText("browser/used.txt", "\n" + helloFilePath);
                        }
                        AddInlineCssToPage(cssContent, jsContent, browser);
                    }
                }
            }
        }
    }
}
