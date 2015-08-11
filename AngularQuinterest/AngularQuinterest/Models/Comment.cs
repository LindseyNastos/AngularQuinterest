using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularQuinterest.Models
{
    public class Comment
    {

        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        //[Required(ErrorMessage = "*required")]
        //[MaxLength(500, ErrorMessage = "*limit: 500 characters")]
        //[DataType(DataType.MultilineText)]
        public string Words { get; set; }

        public Pin Pin { get; set; }

        public int PinId { get; set; }

    }
}