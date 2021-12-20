using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace BookLib
{
    [Serializable]
    public class Journal : Abstractitem, ISaleable
    {
        //the Ctor of 'journal', using the Ctor of the base class. automatically implements the func 'discount', and the field 'duplicationNum'
        public Journal(string name, string author, int releaseyear, double price, int duplicationNum, Edition edition) : base(name, author, releaseyear, price, edition)
        {
            DuplicationNum = duplicationNum;
            this.Discount(price);
        }
        //'duplicationNum' is a field of 'journal', it is limited to 10000 items of each journal
        private int _duplicationNum;

        public int DuplicationNum
        {
            get { return _duplicationNum; }

            set
            {
                if (_duplicationNum < 10000)
                    _duplicationNum = value;
                else
                {
                    _duplicationNum = 10000;
                    _duplicationNum = value;
                }
            }
        }
        //implemention of the abstract func 'discount' the way 'journal' needs
        public override void Discount(double cost)
        {
            if (cost > 70)
            {
                cost = cost * 0.8;
            }
            if (cost > 100)
            {
                cost = cost * 0.7;
            }
            else return;
        }
        //implemention of the interface 'ISaleable' the way 'journal' needs
        public void DoubleSale(object obj1, object obj2)
        {
            Journal journal1 = obj1 as Journal;
            Journal journal2 = obj2 as Journal;
            if (journal1 == null || journal2 == null)
                throw new ArgumentException("at least one of the books is invalid");
            else
            {
                if (journal1.CompareTo(journal2) > 0)
                {
                    journal2.Price = journal2.Price / 2;
                }
                else
                {
                    journal1.Price = journal1.Price / 2;
                }

            }
        }
    }
}
