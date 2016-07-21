namespace AnnetKatan.Models
{
  /// <summary>
  /// Defines the image.
  /// </summary>
  public class Image
  {
    /// <summary>
    /// Gets or sets the image's URL.
    /// </summary>
    /// <value>
    /// The URL.
    /// </value>
    public string Url { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Image"/> class.
    /// </summary>
    /// <param name="url">The URL.</param>
    public Image(string url)
    {
      this.Url = url;
    }
  }
}