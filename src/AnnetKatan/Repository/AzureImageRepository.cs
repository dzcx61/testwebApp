using AnnetKatan.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Collections.Generic;
using System.Threading.Tasks;

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

    public AzureImageRepository(string storageConnectionString, string storageCustomDomain, string containerName)
    {
      CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
      this.blobClient = storageAccount.CreateCloudBlobClient();

      this.containerName = containerName;
      this.customDomain = storageCustomDomain;
    }

    /// <summary>
    /// Gets the image.
    /// </summary>
    /// <param name="directoryName">Name of the directory.</param>
    /// <param name="imageName">Name of the image.</param>
    /// <returns>The specified image from the directory.</returns>
    public Image GetImage(string directoryName, string imageName)
    {
      CloudBlobContainer container = this.blobClient.GetContainerReference(this.containerName);

      string blobName = $"{directoryName}/{imageName}";
      CloudBlockBlob blob= container.GetBlockBlobReference(blobName);

      return new Image(this.GetImageUri(blob));
    }

    /// <summary>
    /// Lists the images.
    /// </summary>
    /// <param name="directoryName">Name of the directory.</param>
    /// <returns>List of the images from the specified directory.</returns>
    public async Task<ICollection<Image>> ListImagesAsync(string directoryName)
    {
      CloudBlobContainer container = this.blobClient.GetContainerReference(this.containerName);
      ICollection<Image> blobList = new List<Image>();

      BlobContinuationToken token = null;
      do
      {
        BlobResultSegment resultSegment = await container.ListBlobsSegmentedAsync($"{directoryName}/", token);
        token = resultSegment.ContinuationToken;

        foreach (ICloudBlob blob in resultSegment.Results)
        {          
          blobList.Add(new Image(this.GetImageUri(blob)));
        }

      } while (token != null);

      return blobList;
    }

    protected string GetImageUri(ICloudBlob blob)
    {
      return string.IsNullOrEmpty(this.customDomain) ? blob.Uri.AbsoluteUri : $"http://{this.customDomain}{blob.Uri.AbsolutePath}";
    }
  }
}