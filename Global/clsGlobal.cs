using BusinessLayer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace VehicleRentalManagmentSystem.Global
{
    public class clsGlobal
    {
        public static clsUsers CurrentUser;

        public static void RememberUsernameAndPasswordInWindowsRegistry(string Username, string Password)
        {
            try
            {
                    
                string keyPath = @"HKEY_CURRENT_USER\Software\VehicleRentalManagementSystem";
                Registry.SetValue(keyPath, "Username", Username, RegistryValueKind.String);
                Registry.SetValue(keyPath, "Password", Password, RegistryValueKind.String);

            }
            catch (Exception ex)
            {

            }
        }

        public static void GetStoredUsernameAndPasswordFromWindowsRegistry(ref string Username, ref string Password)
        {
            try
            {
                string keyPath = @"HKEY_CURRENT_USER\Software\VehicleRentalManagementSystem";

                Username = Registry.GetValue(keyPath, "Username", null) as string;
                Password = Registry.GetValue(keyPath, "Password", null) as string;
            }
            catch (Exception ex)
            {

            }
        }

        
    }
}
