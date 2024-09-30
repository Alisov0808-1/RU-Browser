using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Browser0
{
    public class CustomMenuHandler : CefSharp.IContextMenuHandler
    {
       
        
        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        { model.Clear();
            
            model.AddItem(CefMenuCommand.Copy, "Копировать");
            model.AddItem(CefMenuCommand.Paste, "Вставить");
            model.AddItem(CefMenuCommand.Cut, "Вырезать");
            if (System.IO.File.ReadAllText("browser/extm.txt") == "y")
            {


                model.AddItem(CefMenuCommand.Delete, "Удалить");
                model.AddSeparator();
                model.AddItem(CefMenuCommand.Find, "Найти");
                model.AddItem(CefMenuCommand.ReloadNoCache, "Перезагрузить без кэша");
                model.AddItem(CefMenuCommand.Reload, "Перезагрузить");
                model.AddItem(CefMenuCommand.SelectAll, "Выбрать всё");
             
                model.AddSeparator();
            }
            model.AddItem(CefMenuCommand.Print, "Распечатать");
            model.AddItem(CefMenuCommand.ViewSource, "Посмотреть код");
         


        }

        public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {

            return false;
        }

        public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {

        }

        public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    }
}
