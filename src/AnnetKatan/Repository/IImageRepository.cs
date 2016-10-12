using AnnetKatan.Models;
using System.Collections.Generic;

namespace AnnetKatan.Repository
{
  /// <summary>
  /// Defines methods to manipulate image repository.
  /// </summary>
  public interface IImageRepository
  {
    /// <summary>
    /// Gets the image.
    /// </summary>
    /// <param name="directoryName">Name of the directory.</param>
    /// <param name="imageName">Name of the image.</param>
    /// <returns>The specified image from the directory.</returns>
    Image GetImage(string directoryName, string imageName); 

    /// <summary>
    /// Lists the images.
    /// </summary>
    /// <param name="directoryName">Name of the directory.</param>
    /// <returns>List of the images from the specified directory.</returns>
    ICollection<Image> ListImages(string directoryName);
  }
}
