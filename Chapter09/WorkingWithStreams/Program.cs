using System;
using System.IO;
using System.Xml;
using static System.Console;
using static System.Environment;
using static System.IO.Path;
using System.IO.Compression;

namespace WorkingWithStreams
{
    class Program
    {

        // define an array of Viper pilot call signs
        static string[] callSigns = new string[] {
            "Husker", "Starbuck", "Apollo", "Boomer",
            "Bulldog", "Athena", "Helo", "Racetrack"
        };

        static void WorkWithText()
        {
            // define a file to write to
            string textFile = Combine(CurrentDirectory, "streams.txt");

            //create a text file and return a helper writer
            StreamWriter text = File.CreateText(textFile);

            // enumerate the strings, writing each one 
            // to the stream on a seperate line
            foreach (string item in callSigns)
            {
                text.WriteLine(item);
            }
            text.Close(); //release resources

            //output the contents of the file
            WriteLine($"{textFile} contains {new FileInfo(textFile).Length}  bytes.");
            WriteLine(File.ReadAllText(textFile));
        }

        static void WorkWithXML()
        {

            FileStream xmlFileStream = null;
            XmlWriter xml = null;

            try
            {
                // define a file to write to
                string xmlFile = Combine(CurrentDirectory, "streams.xml");

                // create a file stream
                xmlFileStream = File.Create(xmlFile);

                //Wrap the file stream in an XML writer helper
                //and automatically indent nested elements
                xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });

                // write the XML declaration
                xml.WriteStartDocument();

                //Write a root element
                xml.WriteStartElement("callsigns");

                // enumerate the strings writing each one to the stream
                foreach (string item in callSigns)
                {
                    xml.WriteElementString("callsign", item);
                }

                // write the close root element
                xml.WriteEndElement();

                // close helper and stream
                xml.Close();
                xmlFileStream.Close();

                // output all the contents of the file
                WriteLine($"{xml} contains {new FileInfo(xmlFile).Length} bytes.");
                WriteLine(File.ReadAllText(xmlFile));

            }
            catch (Exception ex)
            {
                // if the path does not exist the exception will be caught
                WriteLine($"{ex.GetType()} says {ex.Message}");
            }
            finally
            {
                if (xml != null)
                {
                    xml.Dispose();
                    WriteLine($"The XML writer's unmanaged resources have been disposed");
                }
                if (xmlFileStream != null)
                {
                    xmlFileStream.Dispose();
                    WriteLine("The file stream's unmanaged resources have been disposed.");
                }
            }

        }
        static void WorkingWithCompression(bool useBrotli = true)
        {
            string fileExt = useBrotli ? "brotli" : "gzip";
            // compress the XML output
            string gzipFilePath = Combine(CurrentDirectory, $"streams.{fileExt}");

            FileStream file = File.Create(gzipFilePath);

            Stream compressor;
            if (useBrotli)
            {
                compressor = new BrotliStream(file, CompressionMode.Compress);
            }
            else
            {
                compressor = new GZipStream(file, CompressionMode.Compress);
            }

            using (compressor)
            {
                using (XmlWriter xmlGzip = XmlWriter.Create(compressor))
                {
                    xmlGzip.WriteStartDocument();
                    xmlGzip.WriteStartElement("callsigns");
                    foreach (string item in callSigns)
                    {
                        xmlGzip.WriteElementString("callsign", item);
                    }

                    // the normal call to WriteEndElement is not necessary
                    // because when the XmlWriter disposes, it will
                    // automatically end any elements of any depth
                }
            }// also closes the underLying stream

            // output all the contents of the compressed file
            WriteLine($"{gzipFilePath}, contains {new FileInfo(gzipFilePath).Length} bytes");
            WriteLine($"The compressed contents:");
            WriteLine(File.ReadAllText(gzipFilePath));

            // read a compressed file
            WriteLine("Reading the compressed XML file:");
            file = File.Open(gzipFilePath, FileMode.Open);

            Stream decompressor;
            if (useBrotli)
            {
                decompressor = new BrotliStream(file, CompressionMode.Decompress);
            }
            else
            {
                decompressor = new GZipStream(file, CompressionMode.Decompress);
            }



            using (decompressor)
            {
                using (XmlReader reader = XmlReader.Create(decompressor))
                {
                    while (reader.Read()) //read the next XML node
                    {
                        // check if ew are on an element node named callsign
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsign"))
                        {
                            reader.Read(); //move to the text inside element
                            WriteLine($"{reader.Value}"); //read it's value
                        }
                    }
                }
            }


        }
        static void Main(string[] args)
        {
            //WorkWithText();
            //WorkWithXML();
            //WriteLine("______________________________");
            WorkingWithCompression();
            WorkingWithCompression(useBrotli: false);
        }
    }
}
