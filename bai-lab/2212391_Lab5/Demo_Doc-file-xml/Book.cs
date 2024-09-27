using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Doc_file_xml
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price {  get; set; }
        public int YearPulished { get; set; }

        public Book () { }
        public Book (string iSBN, string title, string author, decimal price, int yearPulished)
        {
            ISBN = iSBN;
            Title = title;
            Author = author;
            Price = price;
            YearPulished = yearPulished;
        }
    }
}
