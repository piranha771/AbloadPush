using nQuant;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;

namespace AbloadPush.ImageProcessing
{
    class NQuantImageCreator : IImageCreator
    {
        public Stream CreateFromScreenRegion(RegionSelector.Region region)
        {
            Stream result = new MemoryStream();

            var tlbrRegion = region.ToTLBR();
            var bmp = new Bitmap(tlbrRegion.Width(), tlbrRegion.Height());
            var gImage = Graphics.FromImage(bmp);
            gImage.CopyFromScreen(
                new Point(tlbrRegion.First.X, tlbrRegion.First.Y), 
                Point.Empty, 
                new Size(tlbrRegion.Width(), tlbrRegion.Height())
            );

            var quantizer = new WuQuantizer();
            using (var quantized = quantizer.QuantizeImage(bmp))
            {               
                quantized.Save(result, ImageFormat.Png);
                result.Position = 0;               
            }

            return result;
        }

        public void Save(Stream image, string path, string name)
        {
            Directory.CreateDirectory(path);
            using (var fileStream = File.Create(path +  "\\" + name))
            {
                image.Seek(0, SeekOrigin.Begin);
                image.CopyTo(fileStream);
            }
        }


    }
}
