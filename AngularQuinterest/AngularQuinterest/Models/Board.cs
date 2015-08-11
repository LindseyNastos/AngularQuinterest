using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularQuinterest.Models
{
    public class Board
    {
        public int Id { get; set; }


        //[Required(ErrorMessage = "*required")]
        //[Display(Name = "Board Name")]
        //[MaxLength(20, ErrorMessage = "*limit: 20 characters")]
        public string BoardName { get; set; }

        //[Required(ErrorMessage = "*required")]
        public string ImageUrl { get; set; }


        //[DataType(DataType.MultilineText)]
        //[MaxLength(30, ErrorMessage = "*limit: 30 characters")]
        public string Description { get; set; }


        public ApplicationUser User { get; set; }


        public string UserId { get; set; }



        //[Display(Name = "Pins")]
        public int NumPinsOnBoard { get; set; }


        public ICollection<Pin> Pins { get; set; }


        public Board()
        {
            this.Pins = new List<Pin>();
        }


        //Maybe add later?
        //public bool Secret { get; set; }


    }
}