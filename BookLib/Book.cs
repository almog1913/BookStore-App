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
   public class Book : Abstractitem, ISaleable
    {
        //field of the enum 'genre'
        private Genre _type;

        public Genre Type
        {
            get { return _type; }
            set { _type = value; }
        }


        //the Ctor of 'book', using the Ctor of the base class. automatically implements the func 'discount'
        public Book(string name, string author, int releaseyear, double price, Genre genre, Edition edition) : base(name, author, releaseyear, price, edition)
        {
            this.Discount(price);
            this.Type = genre;
        }
        //the 2nd Ctor of 'book', using the overloaded Ctor of the base class. automatically implements the func 'discount'
        public Book(string name, int releaseyear, double price, Edition edition) : base(name, releaseyear, price, edition)
        {
            this.Discount(price);
        }
        //implemention of the abstract func 'discount' the way 'book' needs
        public override void Discount(double cost)
        {
            if (cost > 100)
            {
                cost = cost * 0.8;
            }
            if (cost > 150)
            {
                cost = cost * 0.7;
            }
            else return;
        }
        //enum that is called 'genre', it holds the posible types of books
        public enum Genre
        {
            Drama,
            Horror,
            Comedy,
            Thriller,
            Science
        }
        //switch case who presents the existing genres as string. not implemented yet, maybe will be used in the future
        public string Style(Genre num)
        {
            switch (num)
            {
                case Genre.Drama:
                    return "drama";
                case Genre.Horror:
                    return "horror";
                case Genre.Comedy:
                    return "comedy";
                case Genre.Thriller:
                    return "thriller";
                case Genre.Science:
                    return "science";
                default:
                    return "unknown";
            }
        }
        //implemention of the interface 'ISaleable' the way 'book' needs
        public void DoubleSale(object obj1, object obj2)
        {
          Book book1 = obj1 as Book;
          Book book2 = obj2 as Book;
            if (book1 == null || book2 == null)
                throw new ArgumentException("at least one of the books is invalid");
            if (!(book1.Type == Genre.Horror || book1.Type == Genre.Horror)) return;
            else
            {
                if (book1.CompareTo(book2) > 0)
                {
                    book2.Price = book2.Price / 2;
                }
                else
                {
                    book1.Price = book1.Price / 2;
                }
            }
        }
    }
}
