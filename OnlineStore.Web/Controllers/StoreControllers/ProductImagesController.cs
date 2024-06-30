using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;
using OnlineStore.Web.ViewModels;

public class ProductImagesController : Controller
{
    private readonly ProductImageRepo<ProductImage> imageRepo;
    private readonly ProductRepo<Product> productRepo;
    private readonly IWebHostEnvironment hostingEnvironment;

    public ProductImagesController(ProductImageRepo<ProductImage> _imageRepo, ProductRepo<Product> _productRepo, IWebHostEnvironment hostingEnvironment)
    {
        imageRepo = _imageRepo;
        productRepo = _productRepo;
        this.hostingEnvironment = hostingEnvironment;
    }

    [HttpGet]
    public IActionResult Index(int productId)
    {
        var product = productRepo.GetById(productId);
        if (product == null)
        {
            return NotFound();
        }

        var images = product.Result.Images;

        var viewModel = new List<ImageViewModel>();
        foreach (var image in images)
        {
            var imageUrl = GetImageUrl(image.Image);
            viewModel.Add(new ImageViewModel { ImageUrl = imageUrl });
        }

        ViewBag.ProductId = productId;
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Upload(int productId, ImageViewModel model)
    {
        var product = productRepo.GetById(productId);
        if (product == null)
        {
            return NotFound();
        }

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
    }

    private void DeleteImage(string imageFileName)
    {
        string imagePath = Path.Combine(hostingEnvironment.WebRootPath, "images", imageFileName);
        if (System.IO.File.Exists(imagePath))
        {
            System.IO.File.Delete(imagePath);
        }
    }

    private string GetImageUrl(string imageFileName)
    {
        var imageUrl = Path.Combine("/images", imageFileName);
        return imageUrl;
    }
}