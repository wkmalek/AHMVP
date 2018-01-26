using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace AHWForm.Models
{
    public class CategoryModel
    {
        [ScaffoldColumn(false)]
        public string Id { get; set; }
        [ScaffoldColumn(false)]
        public string ParentCategoryId { get; set; }
        public string Name { get; set; }
    }

}