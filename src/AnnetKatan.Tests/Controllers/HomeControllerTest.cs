using System.Web.Mvc;
using AnnetKatan.Tests.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnnetKatan.Controllers;

namespace AnnetKatan.Tests.Controllers
{
  [TestClass]
  public class HomeControllerTest
  {
    [TestMethod]
    public void Index()
    {
      // Arrange
      LocalImageRepository imageRepository = new LocalImageRepository();
      HomeController controller = new HomeController(imageRepository);

      // Act
      ViewResult result = controller.Index() as ViewResult;

      // Assert
      Assert.IsNotNull(result);
    }

    [TestMethod]
    public void About()
    {
      // Arrange
      LocalImageRepository imageRepository = new LocalImageRepository();
      HomeController controller = new HomeController(imageRepository);

      // Act
      ViewResult result = controller.About() as ViewResult;

      // Assert
      Assert.IsNotNull(result);
    }

    [TestMethod]
    public void Contact()
    {
      // Arrange
      LocalImageRepository imageRepository = new LocalImageRepository();
      HomeController controller = new HomeController(imageRepository);

      // Act
      ViewResult result = controller.Contact() as ViewResult;

      // Assert
      Assert.IsNotNull(result);
    }

    [TestMethod]
    public void Portfolio()
    {
      // Arrange
      LocalImageRepository imageRepository = new LocalImageRepository();
      HomeController controller = new HomeController(imageRepository);

      // Act
      ViewResult result = controller.Portfolio() as ViewResult;

      // Assert
      Assert.IsNotNull(result);
    }

    [TestMethod]
    public void Pricing()
    {
      // Arrange
      LocalImageRepository imageRepository = new LocalImageRepository();
      HomeController controller = new HomeController(imageRepository);

      // Act
      ViewResult result = controller.Pricing() as ViewResult;

      // Assert
      Assert.IsNotNull(result);
    }
  }
}
