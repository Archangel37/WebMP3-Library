using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;

namespace WebMP3.temp
{
    public static class FileHelper
    {
        public static byte[] GetFile(string path)
        {
            return File.ReadAllBytes(path);
        }

        public static IEnumerable<byte[]> GetFilesInDirrectory(string dir)
        {
            string[] files = Directory.GetFiles(dir, "*.mp3");
            return files.Select(f => GetFile(f));
        }


        public static IEnumerable<string> GetPaths(string dir)
        {
            return Directory.GetFiles(dir, "*.mp3");
        }

        public static string GetStringFromImage(System.Drawing.Image image)
        {
            byte[] xByte = CopyImageToByteArray(image);
            return String.Format("data:image;base64,{0}", Convert.ToBase64String(xByte));
        }

        private static byte[] CopyImageToByteArray(System.Drawing.Image theImage)
        {
            Image image = theImage;
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            return memoryStream.ToArray();
        }
    }
}