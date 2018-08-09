using System;
using System.Collections.Generic;

namespace GuestBook.Models
{
    public partial class Book
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Owner { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<Guest> Guests { get; set; }
    }
}
