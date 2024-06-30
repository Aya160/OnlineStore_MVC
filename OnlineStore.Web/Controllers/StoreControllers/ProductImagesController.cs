using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;
using OnlineStore.Web.ViewModels;

public class ProductImagesController : Controller
{
    private readonly ProductImageRepo<ProductImage> imageRepo;
    private readonly ProductImagesController productImagesController;
    private readonly IWebHostEnvironment hostingEnvironment;

<<<<<<< HEAD
    public ProductImagesController( ProductImageRepo<ProductImage> _imageRepo,ProductImagesController _productImagesController,IWebHostEnvironment hostingEnvironment)
=======
    public ProductImagesController(ProductImageRepo<ProductImage> _imageRepo, ProductRepo<Product> _productRepo, IWebHostEnvironment hostingEnvironment)
>>>>>>> 9c2c017c05e5240d279629376848c07e9e03cb1e
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

<<<<<<< HEAD
        return View();
=======
        if (model.Image != null)
        {
            var imageFileName = await UploadImage(model.Image);
            var productImage = new ProductImage { Image = imageFileName };
            product.Result.Images.Add(productImage);
            await productRepo.UpdateAsync(productId, product.Result);
        }

        return RedirectToAction("Index", new { productId });
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int productId, string imageFileName)
    {
        var product = productRepo.GetById(productId);
        if (product == null)
        {
            return NotFound();
        }

        var imageToDelete = product.Result.Images.FirstOrDefault(i => i.Image == imageFileName);
        if (imageToDelete != null)
        {
            product.Result.Images.Remove(imageToDelete);
            await productRepo.DeleteAsync(imageToDelete.Id);
            await productRepo.UpdateAsync(imageToDelete.Id, product.Result);

            DeleteImage(imageFileName);
        }

        return RedirectToAction("Index", new { productId });
    }

    private async Task<string> UploadImage(IFormFile imageFile)
    {
        string uniqueFileName = null;

        if (imageFile != null)
        {
            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
        }

        return uniqueFileName;
>>>>>>> 9c2c017c05e5240d279629376848c07e9e03cb1e
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