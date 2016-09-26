using AnnetKatan.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AnnetKatan.Controllers
{
  public class HomeController : Controller
  {
    private readonly AppSettings appSettings;

    private const string ContainerName = "images";
    private const string HomeDirectoryName = "home";
    private const string AboutDirectoryName = "about";
    private const string PortfolioDirectoryName = "portfolio";

    private readonly IImageRepository imageRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="HomeController"/> class.
    /// </summary>
    public HomeController(IOptions<AppSettings> appSettings)
    {
      this.appSettings = appSettings.Value;
      this.imageRepository = new AzureImageRepository(this.appSettings.AzureStorageConnectionString, this.appSettings.AzureStorageCustomDomain, ContainerName);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HomeController"/> class.
    /// </summary>
    /// <param name="imageRepository">The image repository.</param>
    //public HomeController(IImageRepository imageRepository)
    //{
    //  this.imageRepository = imageRepository;
    //}

    public IActionResult Index()
    {
      var images = this.imageRepository.ListImages(HomeDirectoryName);

      return View(images);
    }

    public IActionResult About()
    {
      var image = this.imageRepository.GetImage(AboutDirectoryName, "Annet-Katan.jpg");

      return View(image);
    }

    public IActionResult Portfolio()
    {
      var images = this.imageRepository.ListImages(PortfolioDirectoryName);

      return View(images);
    }

    public IActionResult Pricing()
    {
      return View();
    }

    public IActionResult Shop()
    {
      return View();
    }

    public IActionResult Contact()
    {
      return View();
    }

    public IActionResult Error()
    {
      return View();
    }
  }
}