using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team12FinalProject.Models
{
    public class Genre
    {
        public Int32 GenreID { get; set; }

        public String GenreType { get; set; }

        public List<Book> Books { get; set; }

        public Genre()
        {
            if(Books==null)
            {
                Books = new List<Book>();
            }
        }
    }
}
