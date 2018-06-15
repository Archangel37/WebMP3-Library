using System.Web.Mvc;
using WebMP3.Models;
using WebMP3.temp;

namespace WebMP3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("/Home/Start");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Описание решения WebMP3-Library";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //!!!!!!!!!!!
        public ActionResult Start()
        {
            return View();
        }


        //!!!!!!!!!!!!!!!
        [HttpPost]
        public ActionResult Start(SubmitFolder model)
        {
            if (ModelState.IsValid)
            {
                //TODO: SubscribeUser(model.Email);
            }

            return View("Index", model);
        }

        //!!!!!!!!!!!!!!
        public ActionResult GetAudioFile(string file) => File(FileHelper.GetFile(file), "audio/mp3");
    }
}