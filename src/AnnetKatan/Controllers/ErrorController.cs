using System.Web.Mvc;
using AnnetKatan.Repository;

namespace AnnetKatan.Controllers
{
  /// <summary>
  /// Defines the Error controller.
  /// </summary>
  public class ErrorController : Controller
  {
    private const string ContainerName = "images";
    private const string ErrorDirectoryName = "error";

    private readonly IImageRepository imageRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="HomeController"/> class.
    /// </summary>
    public ErrorController()
    {
      this.imageRepository = new AzureImageRepository(ContainerName);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HomeController"/> class.
    /// </summary>
    /// <param name="imageRepository">The image repository.</param>
    public ErrorController(IImageRepository imageRepository)
    {
      this.imageRepository = imageRepository;
    }

    public ActionResult Internal()
    {
      Response.StatusCode = 500;
      return View();
    }

    public ActionResult PageNotFound()
    {
      Response.StatusCode = 404;

      var image = this.imageRepository.GetImage(ErrorDirectoryName, "Lady-and-Cat.jpg");
      return View(image);
    }
  }
}
