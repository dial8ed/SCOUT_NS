using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SCOUT.Core.Data
{
    public class ImageService
    {
        public const string ImageFilter =
            "Image files (.jpg .gif .png .bmp)|*.jpg;*.gif;*.png;*.bmp";


        public static byte[] CovertImageToByteArray(Image imageToConvert)
        {
            // Clone the image in case it has locks 
            // which prevent it from being saved
            // to another stream.
            Image clone = imageToConvert.Clone() as Image;

            if(clone == null)
                return null;

            imageToConvert.Dispose();
            
            byte[] imageByteArray;
            using (MemoryStream ms = new MemoryStream())
            {
                clone.Save(ms, clone.RawFormat);
                imageByteArray = ms.ToArray();
            }

            return imageByteArray;
        }


        public static Image ConvertByteArrayToImage(byte[] imageByteArray,
                                                    ImageFormat formatOfImage)
        {
            Image image;

            using (
                MemoryStream ms = new MemoryStream(imageByteArray, 0,
                                                   imageByteArray.Length))
            {
                ms.Write(imageByteArray, 0, imageByteArray.Length);
                image = Image.FromStream(ms, true);
            }

            return image;
        }
    }
}