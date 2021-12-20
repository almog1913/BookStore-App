using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BookLib
{
    //the purpose of the class 'manager' is presenting the data in files and unit testing the functions
    public class Manager
    {
        //creates linked lists of 'book' and 'journal', and the file who holds them as 'Dir'
        const string Dir = @"C:\Users\almog\Desktop\saved\mywork\data";
        string BookFilePath;
        string JournalFilePath;
        string ErrorFilePath;
        private LinkedList<Book> BookList;
        private LinkedList<Journal> JournalList;

        //the Ctor of 'manager', initializes the linked lists of 'book' and 'journal', and initializes the paths of the files
        public Manager()
        {          
            BookList = new LinkedList<Book>();
            JournalList = new LinkedList<Journal>();
            BookFilePath = Path.Combine(Dir, "BookData.bin");
            JournalFilePath = Path.Combine(Dir, "JournalData.bin");
            ErrorFilePath = Path.Combine(Dir, "Error.bin");
        }
        //adding item of 'book' to the list, after that saves the item in the file
        public void AddBook(Book book)
        {
            BookList.AddFirst(book);
            using (Stream stream = File.Open(BookFilePath, FileMode.OpenOrCreate))
            {
                var binFormatter = new BinaryFormatter();
                binFormatter.Serialize(stream, BookList);
            }
        }
        //adding item of 'journal' to the list, after that saves the item in the file
        public void AddJournal(Journal journal)
        {
            JournalList.AddFirst(journal);
            using (Stream stream = File.Open(JournalFilePath, FileMode.OpenOrCreate))
            {
                var binFormatter = new BinaryFormatter();
                binFormatter.Serialize(stream, JournalList);
            }
        }
        //shows all of the items of 'booklist', and expects error with prepared exception file
        public LinkedList<Book> ShowAllBooks()
        {
            return BookList;
        }
        public void UnitBookList()
        {
            try
            {
                using (Stream stream = File.Open(BookFilePath, FileMode.OpenOrCreate))
                {
                    var binFormatter = new BinaryFormatter();
                    if (stream.Length > 0)
                    {
                        BookList = (LinkedList<Book>)binFormatter.Deserialize(stream);
                    }
                    else throw new Exception("there are no books...check out the book list again");
                }
            }
            catch (Exception ex)
            {
                //throw new NullReferenceException("there are no books...");

                using (Stream stream = File.Open(ErrorFilePath, FileMode.OpenOrCreate))
                {
                    var binFormatter = new BinaryFormatter();
                    binFormatter.Serialize(stream, ex);
                }
            }

        }
        //shows all of the items of 'journallist', and expects error with prepared exception file
        public LinkedList<Journal> ShowAllJournals()
        {
            return JournalList;
        }
        public void UnitJournalList()
        {
            try
            {
                using (Stream stream = File.Open(JournalFilePath, FileMode.OpenOrCreate))
                {
                    var binFormatter = new BinaryFormatter();
                    if (stream.Length > 0)
                    {
                        JournalList = (LinkedList<Journal>)binFormatter.Deserialize(stream);
                    }
                    else throw new Exception("there are no journals...check out the journal list again");
                }
            }

            catch (Exception ex)
            {             
                using (Stream stream = File.Open(ErrorFilePath, FileMode.OpenOrCreate))
                {
                    var binFormatter = new BinaryFormatter();
                    binFormatter.Serialize(stream, ex);
                }
            }
        }
    }
}