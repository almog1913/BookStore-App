using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLib;

namespace Book_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("1984", "George Orwell", 1949, 100,Book.Genre.Thriller, Abstractitem.Edition.Classic);
            Book book2 = new Book("Lord of the Flies", "William Gerald Golding", 1954, 100, Book.Genre.Drama, Abstractitem.Edition.Directors_cut);
            Journal journal1 = new Journal("Nature", "Philip Campbell", 1869, 50, 5000, Abstractitem.Edition.Limited);
            Journal journal2 = new Journal("deep sea research", "Kenneth Drinkwater", 1953, 80, 3400, Abstractitem.Edition.New);
            Manager manager = new Manager();
            manager.AddBook(book1);
            manager.AddBook(book2);
            manager.UnitBookList();
            

            manager.AddJournal(journal1);
            manager.AddJournal(journal2);
            manager.UnitJournalList();
            //Console.ReadKey();
        }
    }
}
