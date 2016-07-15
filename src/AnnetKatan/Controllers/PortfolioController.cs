using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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