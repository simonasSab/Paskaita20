using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzduotis02
{
    internal class FileManager
    {
        private StreamWriter? _streamWriter;
        private StreamReader? _streamReader;
        private readonly string _filePath;

        public FileManager(string filePath)
        {
            _filePath = filePath;
        }

        private void OpenStreamWriterToFile()
        {
            _streamWriter = new StreamWriter(_filePath);
        }

        private void OpenStreamWriterToFile(bool append)
        {
            _streamWriter = new StreamWriter(_filePath, append);
        }

        //public async Task WriteItemToFile(Item? item)
        //{
        //    if (item != null)
        //    {
        //        OpenStreamWriterToFile();

        //        if (item is Book)
        //        {
        //            Book book = (Book)item;
        //            _streamWriter.WriteLine($"Book,{book.Id},{book.Title},{book.PublicationYear},{book.Author},{book.Genre}");
        //        }

        //        else if (item is Magazine)
        //        {
        //            Magazine magazine = (Magazine)item;
        //            _streamWriter.WriteLine($"Book,{magazine.Id},{magazine.Title},{magazine.PublicationYear},{magazine.IssueNumber},{magazine.Publisher}");
        //        }

        //        _streamWriter.Close();
        //    }
        //}

        public async Task WriteItemsToFileAsync(List<Item> items)
        {
            OpenStreamWriterToFile();

            foreach (Item item in items)
            {
                if (item is Book)
                {
                    Book book = (Book)item;
                    _streamWriter.WriteLine($"Book,{book.Id},{book.Title},{book.PublicationYear},{book.Author},{book.Genre}");
                }
                    
                else if (item is Magazine)
                {
                    Magazine magazine = (Magazine)item;
                    _streamWriter.WriteLine($"Magazine,{magazine.Id},{magazine.Title},{magazine.PublicationYear},{magazine.IssueNumber},{magazine.Publisher}");
                }
            }
            _streamWriter.Close();
        }

        public async Task<List<Item>> ReadItemsAsync()
        {
            List<Item> items = new();

            _streamReader = new StreamReader(_filePath);
            string line;
            while ((line = _streamReader.ReadLine()) != null)
            {
                string[] values = line.Split(',');
                if (values.Contains("Book"))
                    items.Add(new Book((int.Parse(values[0])), values[1], int.Parse(values[2]), values[3], values[4]));
                else if (values.Contains("Magazine"))
                    items.Add(new Magazine((int.Parse(values[0])), values[1], int.Parse(values[2]), int.Parse(values[3]), values[4]));
            }
            _streamReader.Close();
            return items;
        }
    }
}

