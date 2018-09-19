using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void AddAuthor(Authors aut)
        {
            using (PublishingHouseEntities db = new PublishingHouseEntities())
            {
                db.Authors.Add(aut);
                db.SaveChanges();
                Console.WriteLine("New author with name " + aut.FirstName + " " + aut.LastName + " added");
            }
        }
        static void Main(string[] args)
        {
            Authors aut = new Authors { FirstName = "Isaac", LastName = "NewTone" };
            //AddAuthor(aut);

            ShowAuthors();

            //Authors author = GetAuthorsByName("Taras");

            //if (author != null)
            //    Console.WriteLine($"{author.FirstName} {author.LastName}");
            //else
            //    Console.WriteLine("not found");

            //Init();
        }

        static void ShowAuthors()
        {
            using (PublishingHouseEntities db = new PublishingHouseEntities())
            {
                var books = db.Books.ToList();

                foreach (var item in books)
                    Console.WriteLine($"{item.NameBook}  {item.Authors.FirstName}");
            }
        }

        static Authors GetAuthorsByName(string name)
        {
            using (PublishingHouseEntities db = new PublishingHouseEntities())
            {
                var author = (from a in db.Authors
                              where a.FirstName == name
                              select a).FirstOrDefault(); // if not, return null
                return author;
            }
        }

        static void AddTheme (Themes theme)
        {
            using (PublishingHouseEntities db = new PublishingHouseEntities())
            {
                Themes t = db.Themes.Where(h => h.NameTheme == theme.NameTheme).FirstOrDefault();

                if (t == null)
                {
                    db.Themes.Add(theme);
                    db.SaveChanges();
                    Console.WriteLine("Тема добавлена");
                }
                
            }
        }

        static void AddBook(Books _book)
        {
            using (PublishingHouseEntities db = new PublishingHouseEntities())
            {
                Books currbook = db.Books.Where(b => b.NameBook == _book.NameBook).FirstOrDefault();

                if (currbook == null)
                {
                    db.Books.Add(_book);
                    db.SaveChanges();
                    Console.WriteLine("Книга добавлена");
                }

            }
        }

        static void Init()
        {
            Authors author = new Authors { FirstName = "Steven", LastName = "King", ID_Country = 1 };
            AddAuthor(author);

            author = new Authors { FirstName = "Ivan", LastName = "Franko", ID_Country = 3 };
            AddAuthor(author);

            Themes theme = new Themes { NameTheme = "Sci-Fi" };
            AddTheme(theme);

            Books book = new Books
            {
                NameBook = "Shining",
                ID_Author = 12,
                ID_Theme = 3,
                Price = 35,
                DateOfPublish = DateTime.Now,
                Pages = 800,
                Quantity = 12,
                DrawingOfBook = 3400
            };

            AddBook(book);
            
        }
    }
}
