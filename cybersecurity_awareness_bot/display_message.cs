using System.IO;
using System;
using System.Drawing;

namespace cybersecurity_awareness_bot
{
    public class display_message
    {
        public display_message()
        {
            //get full location of the project
            string full_location = AppDomain.CurrentDomain.BaseDirectory;

            //Replace the bin and debug(bin\Debug\)
            string new_location = full_location.Replace("bin\\Debug\\", "");

            //than combine the path
            string full_path = Path.Combine(new_location, "ascii-art (3).png");

            //then time to use ascii
            // creating the Bitmap class
            Bitmap image = new Bitmap(full_path);

            //then set the size
            image = new Bitmap(image, new Size(150, 60));

            //outer and inner loop
            //outer loop for the height
            for (int height = 0; height < image.Height; height++)
            {

                //inner loop for the width
                for (int width = 0; width < image.Width; width++)
                {
                    Color pixelColor = image.GetPixel(width, height);
                    int gray = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    char assciiChar = gray > 220 ? '.' : gray > 180 ? '0' : gray > 120 ? '#' : '@';
                    Console.Write(assciiChar);
                }
                Console.WriteLine();

            }
        }
    }
}


