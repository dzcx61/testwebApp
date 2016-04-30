using System.Collections.Generic;
using System.IO;
using AnnetKatan.Models;
using AnnetKatan.Repository;

namespace AnnetKatan.Tests.Repository
{
  public class LocalImageRepository : IImageRepository
  {
    public Image GetImage(string directoryName, string imageName)
    {
      string rootPath = Directory.GetCurrentDirectory();
      string filePath = string.Format(@"{0}\Content\Images\{1}\{2}", rootPath, directoryName, imageName);

      FileInfo file = new FileInfo(filePath);

      string rootFilePath = file.FullName.Replace(rootPath, string.Empty);
      string imageUrl = rootFilePath.Replace("\\", "/");
      
      return new Image(imageUrl);
    }

    public ICollection<Image> ListImages(string directoryName)
    {
      ICollection<Image> images = new List<Image>();

      string rootPath = Directory.GetCurrentDirectory();
      string directoryPath = string.Format(@"{0}\Content\Images\{1}", rootPath, directoryName);
      
      DirectoryInfo directory = new DirectoryInfo(directoryPath);

      foreach (var file in directory.GetFiles())
      {
        string rootFilePath = file.FullName.Replace(rootPath, string.Empty);
        string imageUrl = rootFilePath.Replace("\\", "/"); 
        images.Add(new Image(imageUrl));
      }

      return images;
    }
  }
}
