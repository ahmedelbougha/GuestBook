using System;
using System.Collections.Generic;

namespace GuestBook.Models
{
    public partial class Face
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<Guest> Guests { get; set; }
    }
}
