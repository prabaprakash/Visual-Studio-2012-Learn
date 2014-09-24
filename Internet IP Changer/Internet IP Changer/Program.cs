using System.Net;
using System.Management;


namespace Internet_IP_Changer
{
    using System;

    using Microsoft.Win32;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter The Proxy:Port");
            string d = Console.ReadLine();
            try
            {
                RegistryKey rk =
                    Registry.CurrentUser.OpenSubKey(
                        "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
                rk.SetValue("ProxyEnable", 1);
                rk.SetValue("ProxyServer", d);
                rk.Flush();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);

            }
            finally
            {
                Console.WriteLine("All Went Successfully");
            }
            Console.ReadLine();

        }

    }
}
