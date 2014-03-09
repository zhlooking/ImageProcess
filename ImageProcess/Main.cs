using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

using DoctaJonez.Drawing.Imaging;

namespace ImageProcess
{
    class MainFunc
    {
        public static void Main()
        {
            Console.WriteLine("Input file Directory:");
            string dirIn = Console.ReadLine();
            Console.WriteLine("Output file Directory:");
            string dirOut = Console.ReadLine();

            Console.WriteLine("Input scale ratio:");
            float ratio; 
            if (float.TryParse(Console.ReadLine(), out ratio))
            {
                Console.WriteLine("Get Value of ratio fail!", ratio);
            }
            string[] filesInPath = Directory.GetFiles(dirIn);
            foreach (string file in filesInPath)
            {
                string fileName = "";
                Console.WriteLine("Processing now is {0}", file);
                string[] clips =  file.Split('\\');

                System.Drawing.Image image = System.Drawing.Image.FromFile(file);
                float width = image.Width*ratio;
                float height = image.Height*ratio;
                int w = (int)Math.Floor(width);
                int h = (int)Math.Floor(height);
                
                Bitmap resultImage = ImageUtilities.ResizeImage(image, w, h);
                resultImage.MakeTransparent(Color.White);
                Image rtn = (Image)resultImage;
                fileName += dirOut;
                fileName += clips[2];
                // File.Delete(file);
                try
                {
                    rtn.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                    // ImageUtilities.SaveJpeg(file, resultImage, 90);
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                Console.WriteLine(file+" finished!");
            }
            Console.ReadLine();
        }
    }
}
