using Microsoft.AspNetCore.Mvc;
namespace AnnetKatan.Controllers
{
  public class PortfolioController : Controller
  {
    private const string PortfolioPdfUrl = "http://media.annetkatan.com/files/Portfolio.pdf";

    // GET: Portfolio
    public ActionResult Index()
    {
      return Redirect(PortfolioPdfUrl);
    }
  }

}