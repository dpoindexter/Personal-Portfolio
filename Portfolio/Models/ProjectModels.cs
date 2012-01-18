using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Norm;
using Norm.BSON.DbTypes;

namespace Portfolio.Models
{
    public class Project
    {
        public Project()
        {
            Images = new List<Image>();
        }

        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
        public string SiteUrl { get; set; }
        public string Keywords { get; set;}
        public string Technologies { get; set; }
        public string Thumbnail { get; set; }
        public List<Image> Images { get; set; }

        public IEnumerable<ImageJsonViewModel> ImagesToJsonModels()
        {
            var images = new List<ImageJsonViewModel>();
            for (var i = 0; i < Images.Count(); i++)
            {
                images.Add(new ImageJsonViewModel(Images[i], i));
            }
            return images;
        }
    }

    public class Image
    {
        public Image() { }
        public string Src { get; set; }
        public string Caption { get; set; }
    }
}