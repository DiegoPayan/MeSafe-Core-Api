using System;
using Microsoft.Azure.Storage;
using Backend.Models;
using Microsoft.Azure.Storage.Blob;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace Backend.utils
{
  public class UploadFiles
  {
    string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=mesafe;AccountKey=zRJfoy+UBhXYmhYZfgMg9MCban0/waydOmLPLPRSjc0nCW6H0jh5UIIWpfBl3EirQ5uBvzah0NpZwwIPoAJC2w==;EndpointSuffix=core.windows.net";
    public List<String> saveImagesAsync(String origen, List<String> fileList)
    {
      CloudStorageAccount storageAccount;
      if (CloudStorageAccount.TryParse(storageConnectionString, out storageAccount))
      {
        CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();

        CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(origen.ToString());
        cloudBlobContainer.CreateAsync();

        BlobContainerPermissions permissions = new BlobContainerPermissions
        {
          PublicAccess = BlobContainerPublicAccessType.Blob
        };
        cloudBlobContainer.SetPermissionsAsync(permissions);

        int cont = 0;
        List<string> fileUris = new List<string>();
        fileList.ForEach(delegate (String name)
        {
          cont++;
          string nombreOrigen = origen.Split("-")[0];
          byte[] imageBytes = Convert.FromBase64String(name);
          CloudBlockBlob blob = cloudBlobContainer.GetBlockBlobReference(nombreOrigen + cont);
          blob.Properties.ContentType = GetFileExtension(name);
          blob.UploadFromByteArray(imageBytes, 0, imageBytes.Length);
          fileUris.Add(blob.StorageUri.PrimaryUri.AbsoluteUri);
        });
        return fileUris;
      }
      else
      {
        Console.WriteLine("No");
      }
      return new List<string>();
    }

    public static string GetFileExtension(string base64String)
    {
      var data = base64String.Substring(0, 5);

      switch (data.ToUpper())
      {
        case "IVBOR":
          return "png";
        case "/9J/4":
          return "jpg";
        case "AAAAF":
          return "mp4";
        case "JVBER":
          return "pdf";
        case "AAABA":
          return "ico";
        case "UMFYI":
          return "rar";
        case "E1XYD":
          return "rtf";
        case "U1PKC":
          return "txt";
        case "MQOWM":
        case "77U/M":
          return "srt";
        default:
          return string.Empty;
      }
    }

  }
}