using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularQuinterest.Models
{
    public class Pin
    {
        public int Id { get; set; }


        //[Required(ErrorMessage = "*required")]
        public string Title { get; set; }


        //[DataType(DataType.ImageUrl)]
        //[Required(ErrorMessage = "*required")]
        //[Display(Name = "Image URL")]
        public string ImageUrl { get; set; }


        public string Website { get; set; }


        public int BoardId { get; set; }


        public Board Board { get; set; }


        //public int CategoryId { get; set; }


        //public Category Category { get; set; }


        //[MaxLength(150, ErrorMessage = "*limit: 30 characters")]
        //[Display(Name = "Short Description")]
        //[DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }


        //[MaxLength(1000, ErrorMessage = "*limit: 5000 characters")]
        //[Display(Name = "Long Description")]
        //[DataType(DataType.MultilineText)]
        public string LongDescription { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<Comment> Comments { get; set; }




        //Maybe add later?
        //public List<Pin> RelatedPins { get; set; }
    }
}