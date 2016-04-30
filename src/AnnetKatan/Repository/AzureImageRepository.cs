using System.Collections.Generic;
using System.Linq;
using AnnetKatan.Models;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AnnetKatan.Repository
{
  /// <summary>
  /// Defines the image repository that is based on the Azure Blob Storage.
  /// </summary>
  public class AzureImageRepository : IImageRepository
  {
    /// <summary>
    /// The application setting name that contains the connection string to Azure Storage.
    /// </summary>
    private const string StorageConnectionStringAppSetting = "AzureStorage.ConnectionString";

    /// <summary>
    /// The application setting name that contains the custom domain for Azure Storage.
    /// </summary>
    private const string StorageCustomDomainAppSetting = "AzureStorage.CustomDomain";

    /// <summary>
    /// The cloud BLOB client.
    /// </summary>
    private readonly CloudBlobClient blobClient;

    /// <summary>
    /// The cloud blob container name
    /// </summary>
    private readonly string containerName;

    /// <summary>
    /// The custom domain for Azure Storage.
    /// </summary>
    private readonly string customDomain;

    public AzureImageRepository(string containerName)
    {
      CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting(StorageConnectionStringAppSetting));
      blobClient = storageAccount.CreateCloudBlobClient();

      this.containerName = containerName;
      this.customDomain = CloudConfigurationManager.GetSetting(StorageCustomDomainAppSetting);
    }

    /// <summary>
    /// Gets the image.
    /// </summary>
    /// <param name="directoryName">Name of the directory.</param>
    /// <param name="imageName">Name of the image.</param>
    /// <returns>The specified image from the directory.</returns>
    public Image GetImage(string directoryName, string imageName)
    {
      CloudBlobContainer container = blobClient.GetContainerReference(this.containerName);

      string blobName = string.Format("{0}/{1}", directoryName, imageName);
      CloudBlockBlob blob= container.GetBlockBlobReference(blobName);

      return new Image(string.Format("http://{0}{1}", this.customDomain, blob.Uri.AbsolutePath));
    }

    /// <summary>
    /// Lists the images.
    /// </summary>
    /// <param name="directoryName">Name of the directory.</param>
    /// <returns>List of the images from the specified directory.</returns>
    public ICollection<Image> ListImages(string directoryName)
    {
      CloudBlobContainer container = blobClient.GetContainerReference(this.containerName);

      var blobList = container.ListBlobs(directoryName, true).Cast<ICloudBlob>();
      
      ICollection<Image> images = new List<Image>();
      foreach (var blob in blobList)
      {
        images.Add(new Image(string.Format("http://{0}{1}", this.customDomain, blob.Uri.AbsolutePath)));
      }

      return images;
    }
  }
}