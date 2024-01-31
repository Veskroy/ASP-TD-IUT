using Microsoft.AspNetCore.Mvc;
using MonApplicationWebMVC.Models;
using System.Diagnostics;

namespace MonApplicationWebMVC.Controllers
{
    // CHEMIN Home/
    public class HomeController : Controller
    {
        // private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/
        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult HealthCheck()
            {
            return Ok();
            }

        public IActionResult retourVide()
        {
            return new EmptyResult();
        }

        public IActionResult RetourStatus()
        {
            return new StatusCodeResult(200);
        }

        public IActionResult RetourString()
        {
            return Content("Quelque chose pour quelqu'un");
        }

        public IActionResult RetourJson()
        {
            return new JsonResult(new object());
            // ici on doit mettre un object un class
        }

        public IActionResult RetourContent()
        {
            return new ContentResult();
            // ici on peut mettre n'importe contenue
        }

        [HttpGet]
        public IActionResult Divise([FromQuery] float dividende , [FromQuery] float diviseur)
        {
            return Content($" Le resultat de la division de {dividende} par {diviseur} est " + (dividende / diviseur).ToString());
        }

        [HttpGet]
        public FileStreamResult RetournerUnFichier()
        {
            string fileName = "Text.txt";
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, fileName);
            FileStream fs = System.IO.File.OpenRead(filePath);
            return File(fs, "application/octet-stream", fileName);
        }

        [HttpGet]
        public ContentResult RetournerPageDynamique()
        {
            string htmlString = "<!DOCTYPE html>" +
                                "<html>" +
                                    "<head>" +
                                        "<meta charset = \"utf-8\" />" +
                                    "</head>" +
                                    "<body>"+
                                "Les 10 premier entiers pair sont:";
                                    
            for (int i = 1; i <= 10; i++)
            { htmlString+="</br>"+(i * 2); }

              htmlString+="</body>" +
                                "</html>";

            return Content(htmlString, "text/html");

        }
   
    }

  

}
