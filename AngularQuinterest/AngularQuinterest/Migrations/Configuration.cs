namespace AngularQuinterest.Migrations
{
    using AngularQuinterest.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Claims;

    internal sealed class Configuration : DbMigrationsConfiguration<AngularQuinterest.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AngularQuinterest.Models.ApplicationDbContext context)
        {
            //var categories = new Category[]
            //{
            //    new Category {Name="Animals and Pets"},
            //    new Category {Name="Architecture"},
            //    new Category {Name="Art"},
            //    new Category {Name="Cars and Motorcycles"},
            //    new Category {Name="Celebrities"},
            //    new Category {Name="Design"},
            //    new Category {Name="DIY and Crafts"},
            //    new Category {Name="Education"},
            //    new Category {Name="Film, Music and Books"},
            //    new Category {Name="Food and Drink"},
            //    new Category {Name="Gardening"},
            //    new Category {Name="Hair and Beauty"},
            //    new Category {Name="Health and Fitness"},
            //    new Category {Name="History"},
            //    new Category {Name="Holidays and Events"},
            //    new Category {Name="Home Decor"},
            //    new Category {Name="Humor"},
            //    new Category {Name="Illustrations and Posters"},
            //    new Category {Name="Kids and Parenting"},
            //    new Category {Name="Men's Fashion"},
            //    new Category {Name="Outdoors"},
            //    new Category {Name="Photography"},
            //    new Category {Name="Products"},
            //    new Category {Name="Quotes"},
            //    new Category {Name="Science and Nature"},
            //    new Category {Name="Sports"},
            //    new Category {Name="Technology"},
            //    new Category {Name="Travel"},
            //    new Category {Name="Weddings"},
            //    new Category {Name="Women's Fashion"}

            //};

            //context.Categories.AddOrUpdate(c => c.Name, categories);



            var boards = new Board[]
            {
                new Board 
                {
                    Id = 1,
                    BoardName = "Vacations",
                    ImageUrl = "http://wdy.h-cdn.co/assets/cm/15/09/54f0fbd48fba0_-_1-couple-vacation-tropical-lgn.jpg",
                    Description = "Places I want to go",
                    NumPinsOnBoard = 2,
                    Pins = new Pin[]
                    {
                        new Pin {
                            Id = 1,
                            Title = "French Polynesia",
                            ImageUrl = "http://www.charterworld.com/news/wp-content/uploads/2011/06/Bora-Bora-in-French-Polynesia-665x346.jpg",
                            Website = "http://www.frenchpolynesia.com",
                            BoardId = 1,
                            ShortDescription = "Want to go back",
                            LongDescription = "Lorem ipsum dolor sit amet, cursus elit ut turpis, vestibulum et accumsan aliquet fermentum erat et, dapibus fringilla, mauris imperdiet fusce odit ut at sollicitudin, vestibulum mauris accumsan aliquam.",
                        },
                        new Pin {
                            Id = 2,
                            Title = "Norway",
                            ImageUrl = "http://fjordtravel.no/wp-content/uploads/2013/10/lofoten2-Andrea-Giubelli-Innovation-Norway-300x225.jpg",
                            Website = "http://www.norway.com",
                            BoardId = 1,
                            ShortDescription = "Love this place",
                            LongDescription = "Feugiat luctus elit, augue sodales lacus nibh sit. Enim arcu ultrices dictum pellentesque justo malesuada, pede eleifend, cras magna.",
                        }
                    }
                },
            
                new Board {
                    Id = 2,
                    BoardName = "Animals",
                    ImageUrl = "http://www.stylemotivation.com/wp-content/uploads/2013/07/cute-baby-animals-3.jpg",
                    Description = "Adorable cuddly babies!",
                    NumPinsOnBoard = 1,
                    Pins = new Pin[]
                    {
                        new Pin {
                            Id = 3,
                            Title = "Cat",
                            ImageUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRPPGWyw4eLwSjHYVPVz-XLWCsZwvtFGoSXnGee1MVUDVEAIV5e",
                            Website = "http://www.cat.com",
                            BoardId = 2,
                            ShortDescription = "I want one!",
                            LongDescription = "Sed molestie hendrerit cras purus, vitae class, integer libero. Nec ullamcorper sed fermentum at id magni, risus metus, fermentum sapien eros aliquam dis neque vel, ligula nec lacinia.",
                        },
                        new Pin {
                            Id = 4,
                            Title = "Dog",
                            ImageUrl = "http://cutepuppyclub.com/wp-content/uploads/2015/05/White-Cute-Puppy--300x188.jpg",
                            Website = "http://www.dog.com",
                            BoardId = 2,
                            ShortDescription = "I need him!",
                            LongDescription = "Sed molestie hendrerit cras purus, vitae class, integer libero. Nec ullamcorper sed fermentum at id magni, risus metus, fermentum sapien eros aliquam dis neque vel, ligula nec lacinia.",
                        }
                    }
                }
            };

            context.Boards.AddOrUpdate(c => c.BoardName, boards);


            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);

            var user = userManager.FindByName("Lindsey@gmail.com");
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "Lindsey@gmail.com",
                    Email = "Lindsey@gmail.com"
                };
                userManager.Create(user, "Secret123!");

                userManager.AddClaim(user.Id, new Claim("IsAdmin", "true"));


            }
        }
    }
}
