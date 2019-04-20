using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shareDoor.Data
{
    public class CloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        /// <summary>
        /// Set up cloudinary acccount 
        /// </summary>
        /// <param name="apiKey">The Api Key</param>
        /// <param name="apiSecret">The Api Secret</param>
        /// <param name="cloudName">Optional CloudName</param>


        public CloudinaryService(string apiKey = "668971484557574", string apiSecret = "rr4tliPiOi5rVsXyk2P-o8uDzis", string cloudName = "dmizwj8w8")
        {
            var myAccount = new Account { ApiKey = apiKey, ApiSecret = apiSecret, Cloud = cloudName };
            _cloudinary = new Cloudinary(myAccount);
        }

        /// <summary>
        /// Upload image using HttpPostedFileBase
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>

        public ImageUploadResult UploadImage(HttpPostedFileBase file)
        {
            if (file != null)
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, file.InputStream),
                    Transformation = new Transformation().Width(500).Height(500).Crop("fit")
                };

                var uploadResult = _cloudinary.Upload(uploadParams);
                return uploadResult;
            }
            return null;
        }
    }
}