using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SinglePageApp
{
    public class GalleryProduct
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public string ImagePath { get; set; }

        public string Title { get; set; }

        public virtual Product Product { get; set; }
    }
}