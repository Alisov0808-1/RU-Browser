using C_Browser;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RU_Browser
{
    internal class TabDragger
    {
        public TabDragger(TabControl tabControl)
            : base()
        {
            this.tabControl = tabControl;
            tabControl.MouseDown += new MouseEventHandler(tabControl_MouseDown);
            tabControl.MouseMove += new MouseEventHandler(tabControl_MouseMove);
            tabControl.DoubleClick += new EventHandler(tabControl_DoubleClick);
        }

        public TabDragger(TabControl tabControl, TabDragBehavior behavior)
            : this(tabControl)
        {
            this.dragBehavior = behavior;
        }

        private TabControl tabControl;
        private TabPage dragTab = null;
        private TabDragBehavior dragBehavior = TabDragBehavior.TabDragArrange;

        private TabDragBehavior DragBehavior
        {
            get
            {
                if (!tabControl.Multiline)
                    return dragBehavior;
                return TabDragBehavior.None;
            }
        }

        private void tabControl_MouseDown(object sender, MouseEventArgs e)
        {
            dragTab = TabUnderMouse();
        }

        private void tabControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (DragBehavior == TabDragBehavior.None)
                return;

            if (e.Button == MouseButtons.Left)
            {
                if (dragTab != null)
                {
                    if (tabControl.TabPages.Contains(dragTab))
                    {
                        if (PointInTabStrip(e.Location))
                        {
                            TabPage hotTab = TabUnderMouse();
                            if (hotTab != dragTab && hotTab != null)
                            {
                                int id1 = tabControl.TabPages.IndexOf(dragTab);
                                int id2 = tabControl.TabPages.IndexOf(hotTab);
                                if (id1 > id2)
                                {
                                    for (int id = id2; id <= id1; id++)
                                    {
                                        if (hotTab != tabControl.TabPages[tabControl.TabCount - 1])
                                        {
                                            try
                                            {
                                                Form1.images.RemoveAt(tabControl.TabPages.IndexOf(hotTab));
                                                Form1.images.RemoveAt(tabControl.TabPages.IndexOf(dragTab));
                                            }
                                            catch { }

                                            SwapTabPages(id1, id);
                                        }
                                    }
                                }
                                else
                                {
                                    for (int id = id2; id > id1; id--)
                                    {
                                        if (hotTab != tabControl.TabPages[tabControl.TabCount - 1])
                                        {
                                            try {
                                           Form1.images.RemoveAt(tabControl.TabPages.IndexOf(hotTab));
                                                Form1.images.RemoveAt(tabControl.TabPages.IndexOf(dragTab)); } catch { }
                                           
                                            SwapTabPages(id1, id);
                                        }
                                    }
                                }
                                tabControl.SelectedTab = dragTab;
                            }
                        }
                        else
                        {
                            if (this.dragBehavior == TabDragBehavior.TabDragOut)
                            {
                                if (tabControl.TabCount!=2) 
                                {
                                    if (File.ReadAllText("browser/poz.txt") == "y")
                                    {
                                        ChromiumWebBrowser h = (ChromiumWebBrowser)tabControl.TabPages[tabControl.SelectedIndex].Controls[0];
                                        Form1 form1 = new Form1(false, h.Address);
                                      
                                        tabControl.TabPages.Remove(tabControl.SelectedTab);  Form1.images.RemoveAt(tabControl.SelectedIndex);
                                        form1.Show();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void del(TabControl tab,TabPage tab1,ChromiumWebBrowser chromium)
        { tab.SelectedTab=tab1;
            string ch9 = File.ReadAllText("browser/ch.txt");
            try {
                if (ch9 == "y")
                {
                    for (int i = 0; i < tab.TabCount - 1; i++)
                    {

                        TabPage tabPage = (TabPage)tab.TabPages[i];
                        
                        try
                        {
                            if (i != tab.TabCount - 1)
                            {
                                tabPage.Dispose(); tab.TabPages.Remove(tabPage);
                            }




                        }
                        catch { tab.TabPages.Remove(tabPage); }
                    }
                    if (tab.TabCount == 2)
                    {
                        
                        Form1 form1 = new Form1(false, chromium.Address);
                        tab.TabPages.Remove(tab.SelectedTab); Form1.images.RemoveAt(tab.SelectedIndex);
                        form1.Show();
                    }
                }

            }catch { }
        }
        public static void newwin(TabControl tab)
        {
            string ch9 = File.ReadAllText("browser/ch.txt");

            if (tab.TabCount != 2)
            {
                
                
                    ChromiumWebBrowser h = (ChromiumWebBrowser)tab.TabPages[tab.SelectedIndex].Controls[0];
                    Form1 form1 = new Form1(false, h.Address);
                    tab.TabPages.Remove(tab.SelectedTab); Form1.images.RemoveAt(tab.SelectedIndex);
                    form1.Show();
                

            }
            else { MessageBox.Show("Не возможно открыть в новом окне при наличии 1 вкладки!","!",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }

        private void tabControl_DoubleClick(object sender, EventArgs e)
        {
            if (this.DragBehavior == TabDragBehavior.TabDragOut)
            {
               
            }
        }

        #region Private Methods

        private TabPage TabUnderMouse()
        {
            NativeMethods.TCHITTESTINFO HTI = new NativeMethods.TCHITTESTINFO(tabControl.PointToClient(Cursor.Position));
            int tabID = NativeMethods.SendMessage(tabControl.Handle, NativeMethods.TCM_HITTEST, IntPtr.Zero, ref HTI);
            return tabID == -1 ? null : tabControl.TabPages[tabID];
        }

        private bool PointInTabStrip(Point point)
        {
            Rectangle tabBounds = Rectangle.Empty;
            Rectangle displayRC = tabControl.DisplayRectangle; ;

            switch (tabControl.Alignment)
            {
                case TabAlignment.Bottom:
                    tabBounds.Location = new Point(0, displayRC.Bottom);
                    tabBounds.Size = new Size(tabControl.Width, tabControl.Height - displayRC.Height);
                    break;

                case TabAlignment.Left:
                    tabBounds.Size = new Size(displayRC.Left, tabControl.Height);
                    break;

                case TabAlignment.Right:
                    tabBounds.Location = new Point(displayRC.Right, 0);
                    tabBounds.Size = new Size(tabControl.Width - displayRC.Width, tabControl.Height);
                    break;

                default:
                    tabBounds.Size = new Size(tabControl.Width, displayRC.Top);
                    break;
            }
            tabBounds.Inflate(-3, -3);
            return tabBounds.Contains(point);
        }

        private void SwapTabPages(int index1, int index2)
        {
            if ((index1 | index2) != -1)
            {
                TabPage tab1 = tabControl.TabPages[index1];
                TabPage tab2 = tabControl.TabPages[index2];
                tabControl.TabPages[index1] = tab2;
                tabControl.TabPages[index2] = tab1;
            }
        }

        #endregion

    }
}
