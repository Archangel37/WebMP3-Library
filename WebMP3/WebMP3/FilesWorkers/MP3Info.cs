using System;
using System.Drawing;
using System.IO;
using System.Linq;
using TagLib;

namespace WebMP3.FilesWorkers
{
    public class MP3Info
    {
        public string Path { get; set; }
        public string Album { get; set; }
        public string Genres { get; set; }
        public string Performers { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public uint Bpm { get; set; }
        public string Duration { get; set; }
        public int AudioBitrate { get; set; }
        public Image Image { get; set; }

        public MP3Info(string path)
        {
            var audioFile = TagLib.File.Create(path);
            Path = path;
            Album = audioFile.Tag.Album;
            Genres = string.Join(", ", audioFile.Tag.Genres);
            Performers = String.Join(", ", audioFile.Tag.Performers);
            Title = audioFile.Tag.Title;
            Year = audioFile.Tag.Year.ToString();
            Bpm = audioFile.Tag.BeatsPerMinute;
            Duration = audioFile.Properties.Duration.ToString("mm\\:ss");
            AudioBitrate = audioFile.Properties.AudioBitrate;

            if (audioFile.Tag.Pictures.Length > 0)
            {
                MemoryStream ms = new MemoryStream(audioFile.Tag.Pictures[0].Data.Data);
                Image image = Image.FromStream(ms);
                Image = image;
            }
            else Image = null;
        }

        public void SaveInfo(MP3Info info)
        {
            var audioFile = TagLib.File.Create(info.Path);
            audioFile.Tag.Album = info.Album;
            audioFile.Tag.Genres = info.Genres.Split(',').Select(g=> g.Trim()).ToArray();
            audioFile.Tag.Performers = info.Performers.Split(',').Select(p => p.Trim()).ToArray();
            audioFile.Tag.Title = info.Title;
            audioFile.Tag.Year = Convert.ToUInt32(info.Year);
            //остальное не надо править давать
            audioFile.Save();
        }
    }
}