using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzduotis02
{
    internal interface IBorrowable
    {
        void Borrow(Reader reader);
        void Return(Reader reader);
    }
}
