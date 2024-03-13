using Business.IBusiness;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using System;
using System.Web;
using System.IO;

namespace Business.Business
{
    public class FileBusiness : IFileBusiness
    {
        public string UploadFile(HttpPostedFileBase PostedFile)
        {
            string fileName = string.Empty;
            try
            {
                if (PostedFile != null && PostedFile.ContentLength > 0)
                {
                    Account account = new Account("dh0bzbs4u", "414972347571279", "8ow0Al1fkR5OdQVMOgYkcnxZCUw");
                    Cloudinary cloudinary = new Cloudinary(account);

                    byte[] fileBytes;
                    using (var binaryReader = new BinaryReader(PostedFile.InputStream))
                    {
                        fileBytes = binaryReader.ReadBytes(PostedFile.ContentLength);
                    }
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(PostedFile.FileName, new MemoryStream(fileBytes)),
                        PublicId = $"{Guid.NewGuid().ToString()}"
                    };
                    var uploadResult = cloudinary.Upload(uploadParams);
                    fileName = uploadResult.Url.ToString();
                }
                return fileName;
            }
            catch (Exception)
            {
                return fileName;
                throw;
            }
        }
    }
}
