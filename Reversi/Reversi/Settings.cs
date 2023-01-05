using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Reversi
{
    class Settings
    {
        private static Point location;
        private static int thinkMovesForward = 2;

        //Location Property.
        public static Point Location
        {
            get
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\" + GetAssemblyInfo.AssemblyCompany + "\\" + GetAssemblyInfo.AssemblyProduct);
                if (key == null) key = Registry.CurrentUser.CreateSubKey("Software\\" + GetAssemblyInfo.AssemblyCompany + "\\" + GetAssemblyInfo.AssemblyProduct);
                location = new Point((int)key.GetValue("Left", 0), (int)key.GetValue("Top", 0));
                return (location);
            }
            set
            {
                location = value;
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\" + GetAssemblyInfo.AssemblyCompany + "\\" + GetAssemblyInfo.AssemblyProduct, true);
                key.SetValue("Left", location.X);
                key.SetValue("Top", location.Y);
            }
        }

        //How many moves forward is to think Property.
        public static int ThinkMovesForward
        {
            get
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\" + GetAssemblyInfo.AssemblyCompany + "\\" + GetAssemblyInfo.AssemblyProduct);
                if (key == null) key = Registry.CurrentUser.CreateSubKey("Software\\" + GetAssemblyInfo.AssemblyCompany + "\\" + GetAssemblyInfo.AssemblyProduct);
                thinkMovesForward = (int)key.GetValue("ThinkMovesForward", 2);
                return (thinkMovesForward);
            }
            set
            {
                thinkMovesForward = value;
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\" + GetAssemblyInfo.AssemblyCompany + "\\" + GetAssemblyInfo.AssemblyProduct, true);
                key.SetValue("ThinkMovesForward", thinkMovesForward);
            }
        }
    }
}
