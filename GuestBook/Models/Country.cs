using System;
using System.Collections.Generic;

namespace GuestBook.Models
{
    public partial class Country
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }
    }
}
