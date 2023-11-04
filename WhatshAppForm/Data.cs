using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace WhatshAppForm
{
    internal class Data
    {
        Mouse mouse = new Mouse();
        private string[] nameList = {"IT - "};
        private string[] message = { "Завтра будет доставка для" };
        private void read()
        {
            string s;
            //FileStream fstream = File.OpenRead(@"\\nas\Switch\DataWhats");
            StreamReader f = new StreamReader(@"name.txt");
            while ((s = f.ReadLine())!=null) {
               Array.Resize(ref nameList, nameList.Length+1);
                nameList[nameList.Length - 1] = s;
            }
            StreamReader c = new StreamReader(@"message.txt");
            while ((s = c.ReadLine()) != null)
            {
                Array.Resize(ref message, message.Length + 1);
                message[message.Length - 1] = s;
            }
        }
        public void Search()
        {
            read();

            for (int i = 1; i < nameList.Length; i++)
            {
                mouse.CoordX = 175;
                mouse.CoordY = 125;
                mouse.Click();
                mouse.Key(nameList[i]);
                Thread.Sleep(2000);
                Mes(nameList[i],i);
            }
        }
        private void Mes(string name,int i)
        {
            mouse.CoordX = 175;
            mouse.CoordY = 200;
            // Console.ReadKey();
            mouse.Click();
            mouse.CoordX = 600;
            mouse.CoordY = 1000;
            mouse.Click();
            mouse.Key(message[i]+" "+name);
            mouse.Ent();
        }
    }
}
