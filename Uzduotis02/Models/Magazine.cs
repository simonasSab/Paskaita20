using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzduotis02
{
    internal class Magazine : Item, IBorrowable
    {
        public int IssueNumber { get; set; }
        public string Publisher { get; set; }

        public Magazine(int id, string title, int publicationYear, int issueNumber, string publisher) : base(id, title, publicationYear)
        {
            IssueNumber = issueNumber;
            Publisher = publisher;
        }

        public void Borrow(Reader reader)
        {
            reader.BorrowedItems.Add(this);
        }
        public void Return(Reader reader)
        {
            reader.BorrowedItems.Remove(this);
        }
    }
}
