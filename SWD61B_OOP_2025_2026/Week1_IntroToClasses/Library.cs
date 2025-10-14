using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1_IntroToClasses
{
    public class Library
    {
        //constructor
        public Library() //default constructor
        {
            //purpose: is to instaniate the instance of an object
            //2nd purpose: is to initialize/defaults values

            books = new List<Book>();
        }




        //field
        private List<Book> books;

        //property
        public int BooksCount
        {
            get
            {
                return books.Count;
            }
        }

        //methods
        //naming convention:
        //public - Pascal Case
        //private - camel Case
        public void AddBook(Book book)
        {
            if(book != null)
                books.Add(book);
        }

        public void Delete(string isbn)
        {
            //for foreach while do...while
            Book bookToDelete = null; //variable
            foreach(Book book in books)
            {
                if(book.Isbn == isbn)
                {
                    books.Remove(book);
                    return;
                }
            }

            //if(bookToDelete != null)
              //  books.Remove(bookToDelete);
        }

        /// <summary>
        /// When the Buy method is called, check that the book exists, deduct qty from stock
        /// and return total price
        /// </summary>
        /// <param name="isbn">is the isbn of the book</param>
        /// <param name="qty">qty is the amount of copies the user intends to buy</param>
        /// <returns>returns the total price</returns>
        public double Buy(string isbn, int qty)
        {
            foreach (Book book in books)
            {
                if (book.Isbn == isbn)
                {
                   if(book.Stock >= qty)
                    {
                        book.Stock -= qty; //Stock = Stock - qty;
                        return book.RetailPrice * qty;
                    }
                }
            }

            return 0;
        }


    }
}
