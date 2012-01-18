using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class ImageJsonViewModel
    {
        public ImageJsonViewModel(Image img, int ix)
        {
            this.ix = ix;
            this.src = VirtualPathUtility.ToAbsolute("~/img/" + img.Src);
            this.caption = img.Caption;
        }

        public int ix { get; set; }
        public string src { get; set; }
        public string caption { get; set; }
    }
}