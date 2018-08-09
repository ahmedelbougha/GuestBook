using System;
using System.Collections.Generic;

namespace GuestBook.Models
{
    public partial class Guest
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public int FaceID { get; set; }

        public int BookID { get; set; }

        public DateTime Date { get; set; }

        public virtual Book Book { get; set; }

        public virtual Face Face { get; set; }
    }
}
