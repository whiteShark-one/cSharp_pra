using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rookieTutorial.Basics
{
    /*
        结构体（struct）是一种值类型（value type），用于组织和存储相关数据
    */
    struct Books
    {
        public string title;
        public string author;
        public string subject;
        public int book_id;


        public void Show()
        {
            Console.WriteLine($"{title},{author},{subject},{book_id}");
        }
    }
    public class learnStruct
    {
        public void displayStruct()
        {
            Books book1;
            Books book2;

            book1.title = "C Programming";
            book1.author = "NL";
            book1.subject = "Telecom Billing Tutorial";
            book1.book_id = 14234;

            book2.title = "Telecom Billing";
            book2.author = "AL";
            book2.subject = "Telecom Billing Tutorial";
            book2.book_id = 6335;
            
            book2.Show();
            Console.WriteLine();
        
            Console.WriteLine("book1 title : {0}", book1.title);
            Console.WriteLine("book1 author : {0}", book1.author);
            Console.WriteLine("book1 subject : {0}", book1.subject);
            Console.WriteLine("book1 book_id :{0}", book1.book_id);

            Console.WriteLine();

            Console.WriteLine("book2 title : {0}", book2.title);
            Console.WriteLine("book2 author : {0}", book2.author);
            Console.WriteLine("book2 subject : {0}", book2.subject);
            Console.WriteLine("book2 book_id :{0}", book2.book_id);

        }
    }
}