using System;
using System.Collections.Generic;
using System.Text;

namespace BookLib
{
    //an interface who holds one function, that will be implemented at the classes 'book' and 'journal'
    public interface ISaleable
    {
         void DoubleSale(Object obj1, object obj2);
           
    }
}
