using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzduotis02
{
    internal class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }

        public Item(int id, string title, int publicationYear)
        {
            Id = id;
            Title = title;
            PublicationYear = publicationYear;
        }

        public override string ToString()
        {
            return $"ID:{Id:000} Title: {Title} ({PublicationYear})";
        }
    }
}
