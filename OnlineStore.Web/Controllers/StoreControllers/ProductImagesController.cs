using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;
using OnlineStore.Web.ViewModels;

public class ProductImagesController : Controller
{
    private readonly ProductImageRepo<ProductImage> imageRepo;
    private readonly ProductImagesController productImagesController;
    private readonly IWebHostEnvironment hostingEnvironment;

    public ProductImagesController( ProductImageRepo<ProductImage> _imageRepo,ProductImagesController _productImagesController,IWebHostEnvironment hostingEnvironment)
    {
        imageRepo = _imageRepo;
        productImagesController = _productImagesController;
        this.hostingEnvironment = hostingEnvironment;
    }

    [HttpGet]
    public ActionResult UploadImage()
    {
        return View();
    }

    public ActionResult UploadImage(IFormFile file)
    {
        string rootPath = Path.Combine(hostingEnvironment.WebRootPath, "UploadedFiles");
        string fileName = file.FileName;
        string fullPath = Path.Combine(rootPath, fileName);
        file.CopyTo(new FileStream(fullPath, FileMode.Create));

        return View();
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