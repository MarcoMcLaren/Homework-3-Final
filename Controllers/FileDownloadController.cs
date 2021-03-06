using FileUploading.Models;
using System.Collections.Generic; // Helps with lists
using System.IO; // Required for reading and writing IO (Input / Output).
using System.Web.Mvc;

namespace FileUploading.Controllers
{
    public class FileDownloadController : Controller // Complete then Add View as List using model
    {
        // GET: Home
        public ActionResult Index()
        {
            //Fetch all files in the Folder (Directory).

            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Media/Documents/")); //retrieving data and storing in array

            //Copy File names to Model collection.
            //The return below returns to the list here.

            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(files);
        }

        public FileResult DownloadFile(string fileName) 
        {
            //Build the File Path.

            string path = Server.MapPath("~/Media/Documents/") + fileName;

            //Read the File data into Byte Array.
            //Use a byte array becasue of octet-stream.

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.

            //The OCTET-STREAM format is used for file attachments on the Web with an
            //unknown file type. These .octet-stream files are arbitrary binary data
            //files that may be in any multimedia format.

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {
            //Delete requires reading the files and then the allocation of a file path.
            //The file is then deleted based on the identified file path.

            string path = Server.MapPath("~/Media/Documents/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }
    }
}

