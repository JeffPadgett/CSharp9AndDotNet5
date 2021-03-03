using System;
using System.IO;// types for managing the filesystem
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

// You can use these assemblies to make a systen dynamic and work with various systems. 
namespace WorkingWithFileSystems
{
    class Program
    {
        static void OutputFileSystemInfo()
        {
            WriteLine($"{"Path.PathSeperator"} {PathSeparator}");
            WriteLine($"{"Path.DirectorySeparatorChar"} {DirectorySeparatorChar}");
            WriteLine($"{"Directory.GetCurrentDirectory()"} {GetCurrentDirectory()}");
            WriteLine($"{"Environment.CurrentDirectory"} {CurrentDirectory}");
            WriteLine($"{"Environment.SystemDirectory"} {SystemDirectory}");
            WriteLine($"{"Path.GetTempPath()"} {GetTempPath()}");
            WriteLine($"{"GetFolderPath(SpecialFolder)"}");
            WriteLine($"{" .System)"} {GetFolderPath(SpecialFolder.System)}");
            WriteLine($"{" .ApplicationData)"} {SpecialFolder.ApplicationData}");
            WriteLine($"{" .MyDocuments)"} {GetFolderPath(SpecialFolder.MyDocuments)}");
            WriteLine($"{" .Personal)"} {GetFolderPath(SpecialFolder.Personal)}");

        }

        static void WorkWithDrives()
        {
            WriteLine($"{"NAME", -30} | {"TYPE", -10} | {"FORMAT", -7} | {"SIZE (BYTES)", 18} | {"FREE SPACE", 18}");

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    WriteLine($"{drive.Name, -30} | {drive.DriveType, -10} | {drive.DriveFormat, -7} | {drive.TotalSize, 18} | {drive.AvailableFreeSpace, 18}");
                }
                else
                {
                    WriteLine($"{drive.Name, -30} | {drive.DriveType, -10}");
                }
            }
        }

        static void WorkingWithDirectories()
        {
            // define a directory path for an new folder
            // starting in the user's folder. 

            var newFolder = Combine(GetFolderPath(SpecialFolder.Personal), "Code", "Chapter09", "NewFolder");

            WriteLine($"Working with: {newFolder}");

            // check if it exist
            WriteLine($"Does it exist? {Exists(newFolder)}");

            //Create directory
            WriteLine("Creating it...");
            CreateDirectory(newFolder);
            WriteLine($"Does it exist? {Exists(newFolder)}");
            Write($"Confirm the directory exists, and then press ENTER: ");
            ReadLine();

            //delete directory
            WriteLine("Deleting it...");
            Delete(newFolder, recursive: true);
            WriteLine($"Does it exist? {Exists(newFolder)}");
            
        }
        static void Main(string[] args)
        {
            //OutputFileSystemInfo();
            //WorkWithDrives();
            WorkingWithDirectories();
        }
    }
}
