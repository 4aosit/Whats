using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace WhatshAppForm
{
    internal class Mouse
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);


        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;


        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public void Click()
        {
            Cursor.Position = new Point(CoordX, CoordY);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            Thread.Sleep(100);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            Thread.Sleep(200);
        }
        public void Key(string Search)
        {
            Clipboard.SetText(Search);

            SendKeys.SendWait("^{a}");
            SendKeys.SendWait("^{v}");
        }
        public void Ent()
        {
            SendKeys.SendWait("{ENTER}");
            SendKeys.SendWait("{ENTER}");
        }
    }
}
