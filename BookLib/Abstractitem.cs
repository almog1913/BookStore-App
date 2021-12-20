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
   public abstract class Abstractitem : IComparable
    {
        // the fields of 'abstract item' are the common fields to 'book' and 'journal' 
        private static int newID = 1;
        private string _name;
        private readonly int _id;
        private string _author;
        private int _releaseYear;
        private double _price;
        private Edition _edition;


        protected string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        // 'id' is 'read only' and it is updated automatically for each object who created
        protected int Id
        {
            get { return _id; }
        }


        protected string Autor
        {
            get { return _author; }
            set { _author = value; }
        }

        protected int ReleaseYear
        {
            get { return _releaseYear; }
            set { _releaseYear = value; }
        }

        protected double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        protected Edition edition
        {
            get { return _edition; }
            set { _edition = value; }
        }


        //the function that updates the field 'ID' automatically in the Ctor
        private static int nextID()
        {
            return newID++;
        }
        //basic Ctor
        public Abstractitem(string name, string author, int releaseyear, double price, Edition edition)
        {
            Name = name;
            Autor = author;
            ReleaseYear = releaseyear;
            Price = Price;
            _id = Abstractitem.nextID();
            EditionType(edition);
        }
        //Ctor overloading, that Ctor does'nt contain the field 'author', for cases that the author is unknown
        public Abstractitem(string name, int releaseyear, double price, Edition edition) : this(name, "unknown", releaseyear, price, edition) 
        { 

        }
        //abstract func who has to be implemented at the inheriting classes
        public abstract void Discount(double cost);

        //the enum 'Edition' is used as a field in the Ctor
        public enum Edition
        {
            New,
            Limited,
            Classic,
            Directors_cut
        }
        //the function 'EditionNumber' is used automatically in the Ctor, taking the field 'Edition' as a parameter
        protected string EditionType(Edition TypeOfEdition)
        {
            switch (TypeOfEdition)
            {
                case Edition.New:
                    return "New Edition";
                case Edition.Limited:
                    return "limited Edition";
                case Edition.Classic:
                    return "Classic Edition";
                case Edition.Directors_cut:
                    return "Director's Edition";
                default:
                    return "Unknown Edition";
            }
        }

        //implemention of the interface 'IComparable', will be used at the inheriting classes
        public int CompareTo(object obj)
        {
            Abstractitem item = obj as Abstractitem;
            if (item == null)
                throw new ArgumentNullException("the type you gave is not matches");
            int res = Price.CompareTo(item.Price);
            if (res != 0)
                return res;
            return Id - item.Id;
        }
    }
}
