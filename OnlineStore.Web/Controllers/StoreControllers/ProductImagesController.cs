using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;
using OnlineStore.Web.ViewModels;

public class ProductImagesController : Controller
{

    private readonly IWebHostEnvironment hostingEnvironment;

    public ProductImagesController(IWebHostEnvironment hostingEnvironment)
    {

        this.hostingEnvironment = hostingEnvironment;
    }

    //[HttpGet]
    //public ActionResult UploadImage()
    //{
    //    return View();
    //}

    public void UploadImage(IFormFile file)
    {
        string rootPath = Path.Combine(hostingEnvironment.WebRootPath, "UploadedFiles");
        string fileName = file.FileName;
        string fullPath = Path.Combine(rootPath, fileName);
        file.CopyTo(new FileStream(fullPath, FileMode.Create));

       // return RedirectToAction("Index");
    }
    private void DeleteImage(string imageFileName)
    {
        string imagePath = Path.Combine(hostingEnvironment.WebRootPath, "UploadedFiles", imageFileName);
        if (System.IO.File.Exists(imagePath))
        {
            System.IO.File.Delete(imagePath);
        }
    }
}