using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzduotis02
{
    internal class ReadersClub
    {
        public static List<Reader> Readers { get; set; } = new();

        public async Task LoadItemsAsync()
        {
            for (int i = 0; i < Readers.Count(); i++)
            {
                FileManager fileManager = new($"reader{Readers[i].ReaderId:000}.csv");
                Readers[i].BorrowedItems = await fileManager.ReadItemsAsync();
            }
        }

        public async Task SaveItemsAsync()
        {
            for (int i = 0; i < Readers.Count(); i++)
            {
                FileManager fileManager = new($"reader{Readers[i].ReaderId:000}.csv");
                await fileManager.WriteItemsToFileAsync(Readers[i].BorrowedItems);
            }
        }
    }
}
