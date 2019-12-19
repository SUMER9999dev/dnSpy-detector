using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace DnKiller
{
    class Program
    {

        public static bool ExistDnSpyFolder() //this method find folder in appdata
        {
            string system = Environment.GetFolderPath(Environment.SpecialFolder.System); //system
            string SystemDisc = Path.GetPathRoot(system); //Get oc disc
            string userName = Environment.UserName; //get username
            string FullPath = $"{SystemDisc}Users/{userName}/AppData/Local/dnSpy"; //Full directory path
            if (Directory.Exists(FullPath)) //check folder exist
            {
                return true; //return true if directory exist
            }
            else
            {
                return false; //return false if directory is not exist
            }
        }

        public static string GenerateTestID() //Generate test id
        {
            string guid = Guid.NewGuid().ToString(); //create guid
            guid = guid.Replace("-", ""); //replace - to none
            return guid; //return id
        }

        public static string[] FindDnSpyFiles()
        {
            string[] files = new DirectoryInfo(@"C:\Users\pc\Desktop\hi").GetFiles("*.*", SearchOption.AllDirectories)
           .Select(f => f.FullName).ToArray();
            return files;
        }

        public static void WriteText(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red; //change foreground color to red
            Console.Write("[DnSpy detector]: "); //Write watermark
            Console.ForegroundColor = ConsoleColor.Blue; //change foreground color to blue
            Console.WriteLine(input); //Write input
        }

        public static void title(string input)
        {
            Console.Title = input; //changed title to input
        }

        public static void dnSpyFinder() //Main
        {
            string TestID = GenerateTestID();
            //strings and more shit
            string system = Environment.GetFolderPath(Environment.SpecialFolder.System); //system
            string SystemDisc = Path.GetPathRoot(system); //Get oc disc
            string userName = Environment.UserName; //get username
            bool Bypassed = true; //bypassed bool
            int a = 0;
            int time = 0;
            //console and functions
            title($"DnSpy detector - {TestID}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("username - ");
            Console.ForegroundColor = ConsoleColor.Green;
            string systemDisc2 = SystemDisc;
            systemDisc2 = systemDisc2.Replace(@"\", "");
            systemDisc2 = systemDisc2.Replace(":", "");
            Console.WriteLine(userName);
            Console.ForegroundColor = ConsoleColor.Red;// change foreground colore to red
            Console.Write("OC - "); //Write OC
            Console.ForegroundColor = ConsoleColor.Green; //change foreground colore to green
            Console.WriteLine(systemDisc2); //write main HDD or SSD
            Console.ForegroundColor = ConsoleColor.Red;// change foreground colore to red
            Console.Write("Test id - "); //Write Test id
            Console.ForegroundColor = ConsoleColor.Green; //change foreground colore to green
            Console.WriteLine(TestID); //write Test id
            Console.ForegroundColor = ConsoleColor.Red; //change foreground colore to red
            Console.WriteLine("===================================================");//write idk
            WriteText("Mady by SUMER#9999!"); //write Mady by SUMER#9999!
            WriteText("DnSpy detector start scan...");
            WriteText("Scan Process...");
            while (a == 0) //Work when a = 0
            {
                var dnSpy = Process.GetProcessesByName("dnSpy"); //Get proccess
                var x86dnSpy = Process.GetProcessesByName("dnSpy-x86"); //Get proccess
                for (int i = 0; i < dnSpy.Length; i++) //Check proccess dnSpy x64
                {
                    WriteText("dnSpy detected!");
                    Console.WriteLine("killing...");
                    dnSpy[i].Kill(); // kill dnSpy x64
                    WriteText("killed!");
                    Bypassed = false; //if Checker kill process of dnSpy this set bool false
                    a++;
                }
                for (int i = 0; i < x86dnSpy.Length; i++) //Check proccess dnSpy x86
                {
                    WriteText("dnSpy detected!");
                    WriteText("killing...");
                    x86dnSpy[i].Kill(); // kill dnSpy x64
                    WriteText("killed!");
                    Bypassed = false; //if Checker kill process of dnSpy this set bool false
                    a++;
                }
                time++;
                if(time == 40)
                {
                    a++;
                }
            }
            WriteText("Process scanned!");
            WriteText("Scan system...");
            if (ExistDnSpyFolder() == true) //if dnSpy folder checker detect this print error message!
            {
                WriteText("dnSpy detected!");
                Bypassed = false; //set bypassed false
            }
            WriteText("Scanned!");
            if(Bypassed == false) //check if Bypassed
            {
                WriteText("Bypass Failed :C");
            }
            else
            {
                WriteText("Bypassed! You good bypasser.");
            }
            Console.ReadKey();
        }

        static void Main(string[] args) => dnSpyFinder();
    }
}
