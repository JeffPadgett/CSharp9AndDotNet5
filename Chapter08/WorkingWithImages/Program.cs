using System;
using System.Collections.Generic;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace WorkingWithImages
{
    class Program
    {
        static void Main(string[] args)
        {
            string imagesFolder = Path.Combine(Environment.CurrentDirectory, "Images");

            IEnumerable<string> images = Directory.EnumerateFiles(imagesFolder);

            foreach (string imagePath in images)
            {
                string thumbnailpath = Path.Combine(Environment.CurrentDirectory, "Images", Path.GetFileNameWithoutExtension(imagePath) + "-thumbnail" + Path.GetExtension(imagePath));
                using (Image image = Image.Load(imagePath))
                {
                    image.Mutate(x => x.Resize(image.Width / 10, image.Height / 10));
                    image.Save(thumbnailpath);
                }
            }
            Console.WriteLine("Complete");
        }
    }
}
