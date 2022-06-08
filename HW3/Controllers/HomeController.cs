using u21520659_HW03.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace u21520659_HW03.Controllers
{
    public class HomeController : Controller
    {

        //Home page
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        // File + radio button input (Receiving both) 
        [HttpPost]
        public ActionResult Index(string FileType, HttpPostedFileBase file)
        {                     
            
               
            //Uploaded files for images, videos and documents 
            if (file != null)
            {
                string extension = Path.GetExtension(file.FileName);
                
                //Image + radio button selected + file type 
                if( FileType == "Image")
                {
                    // Image into image folder 
                    file.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Media/Images"), Path.GetFileName(file.FileName)));
                    ViewBag.Message = "File uploaded successfully";
                } 
                else if( FileType == "Video")
                {
                    // Video into video folder 
                    file.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Media/Videos"), Path.GetFileName(file.FileName)));
                    ViewBag.Message = "File uploaded successfully";
                }
                else if(FileType == "Document")
                {
                    // Document into document folder
                    file.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Media/Documents"), Path.GetFileName(file.FileName)));
                    ViewBag.Message = "File uploaded successfully";
                }
            }
            else
            {
                ViewBag.Message = "Please select a file";
             
            }
            
            //Return RedirectToAction = ("actionname", "controller name");
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        //After successfully returning 


    }
}