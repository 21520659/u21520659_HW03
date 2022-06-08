using u21520659_HW03.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace u21520659_HW03.Controllers
{
    public class FileController : Controller
    {
        // File selection in laptop 
        public ActionResult Index()
        {

            string[] filePaths = Directory.GetFiles(HttpContext.Server.MapPath("~/Media/Documents/"));
            List<FileModel> fileList = new List<FileModel>();
            foreach (string filePath in filePaths)
            {
                FileModel filemodel = new FileModel();
                filemodel.FileName = Path.GetFileName(filePath);
                fileList.Add(filemodel);
            }


            return View(fileList);
        }

        public ActionResult Download(string FileName)
        {
            //File Path
            string path = Server.MapPath("~/Media/Documents/") + FileName;

            //File data into Byte Array
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //File to Downloads folder
            return File(bytes, "application/octet-stream", FileName);

        }

        public ActionResult Delete(string FileName)
        {
            //Delete the document from the application (Microsoft edge) 
            string fullPath = Request.MapPath("~/Media/Documents/" + FileName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            return RedirectToAction("Index");

        } 
    }
}
