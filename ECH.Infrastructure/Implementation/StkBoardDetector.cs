using System;
using System.Management;

namespace ECH.Infrastructure.Implementation
{
    public class StkBoardDetector
    {
        public static void MyMethod()
        {
            var usbClass = new ManagementClass("Win32_USBDevice");
            var usbCollection = usbClass.GetInstances();

            foreach (System.Management.ManagementObject usb in usbCollection)
            {
                var deviceId = usb["deviceid"].ToString();
                Console.WriteLine(deviceId);

                var vidIndex = deviceId.IndexOf("VID_");
                var startingAtVid = deviceId.Substring(vidIndex + 4); // + 4 to remove "VID_"                    
                var vid = startingAtVid.Substring(0, 4); // vid is four characters long
                Console.WriteLine("VID: " + vid);

                var pidIndex = deviceId.IndexOf("PID_");
                var startingAtPid = deviceId.Substring(pidIndex + 4); // + 4 to remove "PID_"                    
                var pid = startingAtPid.Substring(0, 4); // pid is four characters long
                Console.WriteLine("PID: " + pid);
            }

            Console.ReadLine();
        } 
    }
}