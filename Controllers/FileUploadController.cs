//Contains types that allow reading and writing to files and data
//streams, and types that provide basic file and directory support.

using System.IO;
using System.Web;
using System.Web.Mvc;

namespace FileUploading.Controllers
{
    public class FileUploadController : Controller
    {
        //Example: A client (browser) sends an HTTP request to the server;
        //then the server returns a response to the client. The response
        //contains status information about the request and may also
        //contain the requested content.

        [HttpGet]
        public ActionResult Index()  //INSIDE FileUpload
        {

            return View();
        }

        //Single File Upload
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files, string Upload) //INSIDE HOME
        {
            // Verify that the user selected a file
            // Not null and has a length
            if (Upload == "File")
            {
                if (files != null && files.ContentLength > 0)
                {
                    // extract only the filename

                    var fileName = Path.GetFileName(files.FileName);

                    // store the file inside ~/App_Data/uploads folder

                    var path = Path.Combine(Server.MapPath("~/Media/Documents/"), fileName);

                    // The chosen default path for saving

                    files.SaveAs(path);
                }
                // redirect back to the index action to show the form once again

                return RedirectToAction("Index");
            }
            else if (Upload == "Image")
            {
                if (files != null && files.ContentLength > 0)
                {
                    // extract only the filename

                    var fileName = Path.GetFileName(files.FileName);

                    // store the file inside ~/App_Data/uploads folder

                    var path = Path.Combine(Server.MapPath("~/Media/Images/"), fileName);

                    // The chosen default path for saving

                    files.SaveAs(path);
                }
                // redirect back to the index action to show the form once again

                return RedirectToAction("Index");
            }
            else
            {
                if (files != null && files.ContentLength > 0)
                {
                    // extract only the filename

                    var fileName = Path.GetFileName(files.FileName);

                    // store the file inside ~/App_Data/uploads folder

                    var path = Path.Combine(Server.MapPath("~/Media/Videos/"), fileName);

                    // The chosen default path for saving

                    files.SaveAs(path);
                }
                // redirect back to the index action to show the form once again

                return RedirectToAction("Index");
            }


        }


    }
}