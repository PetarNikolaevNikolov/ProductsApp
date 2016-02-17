using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace PNN.ProductsApp.Web.Infrastructure
{
    public static class ImageHelper
    {
        public static string SaveBase64Image(string base64Img, string imgExtension)
        {
            string fileUri = null;
            byte[] bytes = Convert.FromBase64String(base64Img);
            string imgName = string.Format("{0}.{1}", Guid.NewGuid().ToString(), imgExtension);
            string fullFileName = Path.Combine(HostingEnvironment.MapPath(ConfigHelper.ImageFolder), imgName);
            File.WriteAllBytes(fullFileName, bytes);
            fileUri = new System.Web.Mvc.UrlHelper(HttpContext.Current.Request.RequestContext).Content(ConfigHelper.ImageFolder + imgName);
            return fileUri;
        }
    }
}