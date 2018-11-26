using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace Common
{
    public class BlobUploader
    {
        private readonly string storageAccountName;
        private readonly string accessKey;
        private readonly string containerName;
        private readonly string storageConnectionString;

        public BlobUploader()
        {
            storageAccountName = ConfigurationManager.AppSettings["storageAccountName"].ToString();
            accessKey = ConfigurationManager.AppSettings["accessKey"].ToString();
            containerName = ConfigurationManager.AppSettings["containerName"].ToString();
            storageConnectionString = ConfigurationManager.AppSettings["storageConnectionString"].ToString();
        }

        public string UploadFilesToBlob(string supplierName, string documentName, HttpPostedFileBase uploadedFile)
        {
            Microsoft.WindowsAzure.Storage.Auth.StorageCredentials creden = new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(storageAccountName, accessKey);

            CloudStorageAccount account = new CloudStorageAccount(creden, useHttps: true);

            CloudBlobClient client = account.CreateCloudBlobClient();

            CloudBlobContainer container = client.GetContainerReference("poccontainer");

            container.CreateIfNotExists();

            container.SetPermissions(new BlobContainerPermissions
            { PublicAccess = BlobContainerPublicAccessType.Off });


            string fileName = documentName  + Path.GetExtension(uploadedFile.FileName);

            var directory = container.GetDirectoryReference(supplierName);
            CloudBlockBlob cblob = directory.GetBlockBlobReference(fileName);
            cblob.Properties.ContentType = uploadedFile.ContentType;
            cblob.UploadFromStream(uploadedFile.InputStream);
            

            return "";
        }

        public void DownloadFileFromBlob()
        {

        }
    }
}
