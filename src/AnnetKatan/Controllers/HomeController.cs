using System.Web.Mvc;
using AnnetKatan.Repository;

namespace AnnetKatan.Controllers
{
  /// <summary>
  /// Defines the default Home controller.
  /// </summary>
  [OutputCache(CacheProfile = "CacheOneDay")]
  public class HomeController : Controller
  {
    private const string ContainerName = "images";
    private const string HomeDirectoryName = "home";
    private const string AboutDirectoryName = "about";
    private const string PortfolioDirectoryName = "portfolio";

    private readonly IImageRepository imageRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="HomeController"/> class.
    /// </summary>
    public HomeController()
    {
      this.imageRepository = new AzureImageRepository(ContainerName);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HomeController"/> class.
    /// </summary>
    /// <param name="imageRepository">The image repository.</param>
    public HomeController(IImageRepository imageRepository)
    {
      this.imageRepository = imageRepository;
    }

    public ActionResult Index()
    {
      var images = this.imageRepository.ListImages(HomeDirectoryName);

      return this.View(images);
    }

    public ActionResult About()
    {
      var image = this.imageRepository.GetImage(AboutDirectoryName, "Annet-Katan.jpg");

      return this.View(image);
    }

    public ActionResult Portfolio()
    {
      var images = this.imageRepository.ListImages(PortfolioDirectoryName);

      return this.View(images);
    }

    public ActionResult Pricing()
    {
      return this.View();
    }

    public ActionResult Shop()
    {
      return this.View();
    }

    public ActionResult Contact()
    {
      return this.View();
    }
  }
}