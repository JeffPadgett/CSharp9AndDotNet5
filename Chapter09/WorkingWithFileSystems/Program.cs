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

        static void WorkingWithFiles()
        {
            // Define a directory path to output files
            // starting in the user's folder

            var dir = Combine(GetFolderPath(SpecialFolder.Personal), "Code", "Chapter09", "OutputFiles");

            CreateDirectory(dir);

            // define file paths
            string textFile = Combine(dir, "Dummy.txt");
            string backupFile = Combine(dir, "Dummy.bak");
            WriteLine($"Working with: {textFile}");

            // check if a file exist
            WriteLine($"Does it exist? {File.Exists(textFile)}");

            // create a new text file and write a line to it
            StreamWriter textWriter = File.CreateText(textFile);
            textWriter.WriteLine("Hello, C#!");
            textWriter.Close();// close file and release resources
            WriteLine($"Does it exist? {File.Exists(textFile)}");

            //copy the file, and overwrite if it already exist
            File.Copy(sourceFileName: textFile, destFileName: backupFile, overwrite: true);
            WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");
            Write("Confirm the files exist, and then press ENTER:");
            ReadLine();

            // delete file
            File.Delete(textFile);
            WriteLine($"Does it exist? {File.Exists(textFile)}");

            //read from the text file backup
            WriteLine($"Reading contents of {backupFile}:");
            StreamReader textReader = File.OpenText(backupFile);
            WriteLine(textReader.ReadToEnd());
            textReader.Close();



        }
        static void Main(string[] args)
        {
            //OutputFileSystemInfo();
            //WorkWithDrives();
            //WorkingWithDirectories();
            WorkingWithFiles();
        }
    }
}
