using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebMP3.temp;

namespace WebMP3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //!!!!!!!!!!!!!!
        public ActionResult GetAudioFile(string file)
        {
            return File(FileHelper.GetFile(file), "audio/mp3");
        }

        //!!!!!!!!test
        public ActionResult GetOneFile()
        {
            return File(FileHelper.GetFile(@"D:/Паша/! ! ! Сборки/__ПодборкаВМашину/DubStep/Flux Pavilion - I Can't Stop (Original Mix).mp3"), "audio/mp3");
        }

        //test
        public ActionResult GetNewAudio(string dir)
        {
            AudioArray AA = new AudioArray();
            var paths = FileHelper.GetPaths(dir).ToList();
            var contents = paths.Select(p => FileHelper.GetFile(p)).ToList();

            List<MP3File> MP3s = new List<MP3File>();

            for(int i=0; i<paths.Count(); i++)
            {
                MP3s.Add(new MP3File { Path = paths[i], Mp3Info = new FilesWorkers.MP3Info(paths[i]) });
            }


            AA.AudioFiles.AddRange(MP3s);

            return View(AA);
        }
    }
}