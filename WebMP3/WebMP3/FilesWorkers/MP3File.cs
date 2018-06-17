using WebMP3.FilesWorkers;

namespace WebMP3.temp
{
    public class MP3File
    {
        public string Path { get; set; }
        public MP3Info Mp3Info { get; set; }

        public void SaveInfo(MP3Info info)
        {
            Mp3Info.SaveInfo(info);
        }
    }
}