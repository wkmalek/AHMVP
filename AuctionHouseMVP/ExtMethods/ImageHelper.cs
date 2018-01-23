using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AHWForm.ExtMethods
{
    public class ImageHelper
    {
        public static string GetUrlForImage(string ID, string ext, int width = 300, int height = 300, bool ver = true)
        {
            if(ver)
                return "~/"+"Images/" + ID + ext + "?Width=" + width + "&Height=" + height;
            return "Images/" + ID + ext + "?Width=" + width + "&Height=" + height;
        }
    }
}