using GuestBook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FizzWare.NBuilder;
using Faker;
using System.Data.Entity.Migrations;

namespace GuestBook.DAL
{
    public class GuestBookInitializer : System.Data.Entity.DropCreateDatabaseAlways<GuestBookContext>
    {
        // Without using builder or faker.net
        //protected override void Seed(GuestBookContext context)        
        //{
        //    var books = new List<Book>
        //    {
        //        new Book { Name = "My Graduation", Owner = "Ahmed Rashad" },
        //        new Book {Name = "My Engagement", Owner = "Ahmed Rashad" },
        //        new Book {Name = "My Widdeng", Owner = "Ahmed Rashad" }
        //    };

        //    books.ForEach(book => context.Books.Add(book));
        //    context.SaveChanges();

        //    var faces = new List<Face>
        //    {   
        //        new Face { Name = "Happy" },
        //        new Face {Name = "Neutral" },
        //        new Face {Name = "Sad" }
        //    };
        //    faces.ForEach(face => context.Faces.Add(face));
        //    context.SaveChanges();

        //    var guests = new List<Guest>
        //    {
        //        new Guest { Name = "Samir Ahmed", Comment = "sample comment 1", BookID = 1, FaceID = 1 },
        //        new Guest {Name = "Salem Mohamed", Comment = "sample comment 2", BookID = 2, FaceID = 1 },
        //        new Guest {Name = "Hany Rashad", Comment = "sample comment 3", BookID = 3, FaceID = 1 },
        //        new Guest {Name = "Hamdy ElBadry", Comment = "sample comment 4", BookID = 3, FaceID = 1},
        //        new Guest {Name = "Huda Rashad", Comment = "sample comment 5", BookID = 3, FaceID = 1},
        //    };
        //    guests.ForEach(guest => context.Guests.Add(guest));
        //    context.SaveChanges();
        //}

        //using nbuilder only
        //protected override void Seed(GuestBookContext context)
        //{
        //    var books = Builder<Book>.CreateListOfSize(3).Build();
        //    context.Books.AddOrUpdate(book => book.ID, books.ToArray());
        //    context.SaveChanges();
        //    var faces = Builder<Face>.CreateListOfSize(3).Build();
        //    context.Faces.AddOrUpdate(face => face.ID, faces.ToArray());
        //    context.SaveChanges();
        //    var guests = Builder<Guest>.CreateListOfSize(7).Build();
        //    context.Guests.AddOrUpdate(guest => guest.ID, guests.ToArray());
        //    context.SaveChanges();
        //}

        // using nbuilder and faker.net
        protected override void Seed(GuestBookContext context)
        {
            var randomGenerator = new RandomGenerator();

            var books = Builder<Book>.CreateListOfSize(3)
                .All()
                .With(book => book.Name = Faker.Name.FullName())
                .With(book => book.Owner = Faker.Name.First() + ' ' + Faker.Name.Last())
                .With(book => book.Description = Faker.Lorem.Sentence(5))
                .With(book => book.Date= DateTime.Now.AddDays(-randomGenerator.Next(1, 100)))
            .Build();
            context.Books.AddOrUpdate(book => book.ID, books.ToArray());
            context.SaveChanges();

            var faces = new List<Face>
                {
                    new Face { Name = "Happy", Date = DateTime.Now },
                    new Face { Name = "Neutral", Date = DateTime.Now },
                    new Face { Name = "Sad", Date = DateTime.Now }
                };
            faces.ForEach(face => context.Faces.Add(face));
            context.SaveChanges();

            var guests = Builder<Guest>.CreateListOfSize(7)
                .All()
                .With(guest => guest.Name = Faker.Name.FullName())
                .With(guest => guest.Comment = Faker.Lorem.Sentence(5))
                .With(guest => guest.BookID = randomGenerator.Next(1,3))
                .With(guest => guest.FaceID = randomGenerator.Next(1, 3))
                .With(guest => guest.Date = DateTime.Now.AddDays(-randomGenerator.Next(1, 100)))
            .Build();
            context.Guests.AddOrUpdate(guest => guest.ID, guests.ToArray());
            context.SaveChanges();
        }

    }
}