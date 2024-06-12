using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Uzduotis02
{
    // ReaderId, Name ir BorrowedItems (sąrašas iš Item)
    internal class Reader
    {
        public int ReaderId { get; set; }
        public string Name { get; set; }
        public List<Item> BorrowedItems { get; set; }

        public Reader(int readerId, string name)
        {
            ReaderId = readerId;
            Name = name;
            BorrowedItems = new();
        }
        public Reader(int readerId, string name, List<Item> borrowedItems)
        {
            ReaderId = readerId;
            Name = name;
            BorrowedItems = borrowedItems;
        }

        public override string ToString()
        {
            return $"Reader ID:{ReaderId:000} {Name} (has {BorrowedItems.Count()} items borrowed)";
        }

        public void BorrowItem(Item item)
        {
            BorrowedItems.Add(item);
        }

        public void DisplayItems(List<Item> items)
        {
            foreach (Item item in items)
            {
                if (item is Book)
                {
                    Book book = (Book)item;
                    Console.WriteLine(book.ToString());
                }
                else if (item is Magazine)
                {
                    Magazine magazine = (Magazine)item;
                    Console.WriteLine(magazine.ToString());
                }
            }
            Console.WriteLine();
        }

        public List<Book> FindBooks(string phrase)
        {
            List<Book> books = new();

            foreach (Item item in BorrowedItems)
            {
                if (item is Book)
                {
                    Book book = (Book)item;
                    books.Add(book);
                }
            }
            Regex? rx = new("*phrase*", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

            return books.Where(x => rx.IsMatch(x.Author) || rx.IsMatch(x.Genre)).ToList();
        }

        public List<Magazine> FindMagazines(string phrase)
        {
            List<Magazine> magazines = new();

            foreach (Item item in BorrowedItems)
            {
                if (item is Magazine)
                {
                    Magazine magazine = (Magazine)item;
                    magazines.Add(magazine);
                }
            }
            Regex? rx = new("*phrase*", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

            return magazines.Where(x => rx.IsMatch(x.PublicationYear.ToString()) || rx.IsMatch(x.Publisher)).ToList();
        }
    }
}
