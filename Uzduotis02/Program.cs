using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Uzduotis02
{
    internal class Program
    {
        public static ReadersClub readersClub { get; set; } = new();
        public static void Main(string[] args)
        {
            StartProgram();

            EndProgram();
        }

        public async static Task StartProgram()
        {
            await readersClub.LoadItemsAsync();
        }

        public async static Task EndProgram()
        {
            await readersClub.SaveItemsAsync();
        }
    }

}