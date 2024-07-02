using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Infrastructure.Repository.Users;
using OnlineStore.Web.ViewModels;

namespace OnlineStore.Web.Controllers.UsersControllers
{
    public class AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,AddressRepo<Address> _addressRepo, CustomerRepo<Customer> _customerRepo, VendorRepo<Vendor> _vendorRepo,ProductImagesController _imagesController) : Controller
    {
        private readonly UserManager<ApplicationUser> userManager = userManager;
        private readonly SignInManager<ApplicationUser> signInManager = signInManager;
        private readonly AddressRepo<Address> addressRepo = _addressRepo;
        private readonly CustomerRepo<Customer> customerRepo = _customerRepo;
        private readonly VendorRepo<Vendor> vendorRepo = _vendorRepo;
        private readonly ProductImagesController imagesController = _imagesController;

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel userData)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new()
                {
                    UserName = userData.UserName,
                    PasswordHash = userData.Password,
                    Email = userData.EmailAddress,
                    FirstName = userData.FirstName,
                    LastName = userData.LastName,
                    PhoneNumber = userData.PhoneNO1,
                    PhoneNo2 = userData.PhoneNO2,
                    Gender = userData.Gender,
                    ImageUrl = userData.Image.FileName,
                };
                imagesController.UploadImage(userData.Image);
                var existsEmail = await userManager.FindByEmailAsync(userData.EmailAddress);
                if (existsEmail is null)
                {
                    var user = await userManager.CreateAsync(appUser, userData.Password);
                    if (user.Succeeded)
                    {
                        var address = new Address
                        {
                            StreetAdderss = userData.StreetAddress,
                            State = userData.State,
                            City = userData.City,
                            Zip = userData.Zip,
                            UserId = appUser.Id
                        };
                        var customer = new Customer
                        {
                           Image = appUser.ImageUrl,
                            
                        };
                        
                       await customerRepo.CreateAsync(customer);
                        await addressRepo.CreateAsync(address);
                        await userManager.AddToRoleAsync(appUser, "Customer");
                        await signInManager.SignInAsync(appUser, true);
                        return RedirectToAction("Index", "Home");
                    }
                    foreach (var item in user.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
                ModelState.AddModelError("EmailAddress", "this Email is already exist");

            }
            return View(userData);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginView)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = await userManager.FindByEmailAsync(loginView.Email);
                if (applicationUser != null)
                {
                    var isExist = await userManager.CheckPasswordAsync(applicationUser, loginView.Password);
                    if (isExist)
                    {
                        await signInManager.SignInAsync(applicationUser, loginView.RememberMe);
                        return RedirectToAction("Index", "Products");
                    }
                }
                ModelState.AddModelError("", "Invalid Email or Password");

            }
            return View(loginView);
        }

        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        [HttpGet]
        public IActionResult CreateAdmin()
        {
            return View();
        }

       // [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAdmin(RegisterViewModel userData)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new()
                {
                    UserName = userData.UserName,
                    PasswordHash = userData.Password,
                    Email = userData.EmailAddress,
                    FirstName = userData.FirstName,
                    LastName = userData.LastName,
                    PhoneNumber = userData.PhoneNO1,
                    PhoneNo2 = userData.PhoneNO2,
                    Gender = userData.Gender,
                    SSN = userData.SSN,
                    ImageUrl = userData.Image.FileName,
                };
                imagesController.UploadImage(userData.Image);
                var existsEmail = await userManager.FindByEmailAsync(userData.EmailAddress);
                if (existsEmail is null)
                {
                    var user = await userManager.CreateAsync(appUser, userData.Password);
                    if (user.Succeeded)
                    {
                        var address = new Address
                        {
                            StreetAdderss = userData.StreetAddress,
                            State = userData.State,
                            City = userData.City,
                            Zip = userData.Zip,
                            UserId = appUser.Id
                        };
                        await addressRepo.CreateAsync(address);
                        await userManager.AddToRoleAsync(appUser, "Admin");
                        await signInManager.SignInAsync(appUser, true);
                        return RedirectToAction("Index", "Adminstrators");
                    }
                    foreach (var item in user.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
                ModelState.AddModelError("EmailAddress", "this Email is already exist");

            }
            return View(userData);
        }
		[Authorize(Roles = "Admin")]
		[HttpGet]
        public IActionResult CreateVendor()
        {
            return View();
        }
        //[Authorize(Roles ="Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVendor(RegisterViewModel userData)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new()
                {
                    UserName = userData.UserName,
                    PasswordHash = userData.Password,
                    Email = userData.EmailAddress,
                    FirstName = userData.FirstName,
                    LastName = userData.LastName,
                    PhoneNumber = userData.PhoneNO1,
                    PhoneNo2 = userData.PhoneNO2,
                    Gender = userData.Gender,
                    ImageUrl = userData.Image.FileName,
                };
                imagesController.UploadImage(userData.Image);
                var existsEmail = await userManager.FindByEmailAsync(userData.EmailAddress);
                if (existsEmail is null)
                {
                    var user = await userManager.CreateAsync(appUser, userData.Password);
                    if (user.Succeeded)
                    {
                        var address = new Address
                        {
                            StreetAdderss = userData.StreetAddress,
                            State = userData.State,
                            City = userData.City,
                            Zip = userData.Zip,
                            UserId = appUser.Id
                        };
                        var vendor = new Vendor
                        {
                            Name = $"{userData.FirstName} {userData.LastName}",
                            Salary = userData.Salary,
                            StoreId = userData.StoreId,
                        };
                        await addressRepo.CreateAsync(address);
                        await userManager.AddToRoleAsync(appUser, "Vendor");
                        await signInManager.SignInAsync(appUser, true);
                        return RedirectToAction("Index", "Venddors");
                    }
                    foreach (var item in user.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
                ModelState.AddModelError("EmailAddress", "this Email is already exist");

            }
            return View(userData);
        }

    }
}
