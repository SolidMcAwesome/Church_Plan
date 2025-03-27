using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Bed = System.Threading.Thread;

namespace Wonder
{
    internal class Bible
    {
        public Bible()
        {

        }

        public string getReading(string[] selection)
        {
            string reading = getVerse(selection);
            return reading;
        }
        public List<string> getChapterReading(string[] selection)
        {
            List<string> chapter = getChapter(selection);
            return chapter;
        }
        public List<string> getChapterNumbers(string[] selection)
        {
            List<string> chapters = getChapters(selection);
            return chapters;
        }
        public List<string> getBibleBooks(string selection)
        {
            List<string> books = getBooks(selection);
            return books;
        }
        public List<string> getBibleVersions()
        {
            List<string> versions = getBible();
            return versions;
        }
        private static List<string> getBible()
        {
            string[] versions = Directory.GetFiles("Bibles");
            //List<string> versionFiles = versions.Where(file => file.EndsWith(".xml", StringComparison.OrdinalIgnoreCase)).ToList();
            //List<string> versionNames = versionFiles.Select(Path.GetFileName).ToList();

            List<string> versionNames = versions
                .Where(file => file.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                .Select(Path.GetFileNameWithoutExtension)
                .ToList();

            return versionNames;
        }
        private static List<string> getBooks(string selection) //////////////////////
        {
            string bible = "Bibles/" + selection;

            XDocument BB = XDocument.Load(bible);
            var output = (from b in BB.Descendants("BIBLEBOOK")
                          select b.Attribute("bname").Value).ToList();
            return output;
        }

        private static List<string> getChapters(string[] selection)
        {
            string bible = "Bibles/" + selection[0];
            string book = selection[1];

            XDocument BB = XDocument.Load(bible);
            var output = (from b in BB.Descendants("BIBLEBOOK")
                          where b.Attribute("bname")?.Value == book
                          from c in b.Descendants("CHAPTER")
                          select c.Value).ToList();
            return output;
        }

        private static List<string> getChapter(string[] selection)
        {
            string bible = "Bibles/" + selection[0];
            string book = selection[1];
            string chapter = selection[2];

            XDocument BB = XDocument.Load(bible);
            var output = (from b in BB.Descendants("BIBLEBOOK")
                     where b.Attribute("bname")?.Value == book
                     from c in b.Descendants("CHAPTER")
                     where c.Attribute("cnumber")?.Value == chapter
                     from v in c.Descendants("VERS")
                     select v.Value).ToList();
            return output;
        }

        private static string getVerse(string[] selection)
        {
            string bible = "Bibles/" + selection[0];
            string book = selection[1];
            string chapter = selection[2];
            string verse = selection[3];
            var output = "";
            XDocument BB = XDocument.Load(bible);
            output = (from b in BB.Descendants("BIBLEBOOK")
                      where b.Attribute("bname")?.Value == book
                      from c in b.Descendants("CHAPTER")
                      where c.Attribute("cnumber")?.Value == chapter
                      from v in c.Descendants("VERS")
                      where v.Attribute("vnumber")?.Value == verse
                      select v.Value).FirstOrDefault();
            /// custom        
            ///  var output = (from b in BB.Descendants("book")        
            ///                  where b.Attribute("title")?.Value == book        
            ///                  from c in b.Descendants("chapter")        
            ///                  where c.Attribute("num")?.Value == chapter        
            ///                  from v in c.Descendants("verse")        
            ///                 where v.Attribute("num")?.Value == verse        
            ///                  select v.Value).FirstOrDefault();       

            return output; 
        }

        private static string[] chooseVerse()
        {
            string Bible = "Bibles/KJV.xml"; // CustomBible.xml     
            string Book = "John";
            string Chapter = "3";
            string Verse = "16";

            Console.WriteLine("Book: ");
            Book = Console.ReadLine();
            Console.WriteLine("Chapter: ");
            Chapter = Console.ReadLine();
            Console.WriteLine("Verse: ");
            Verse = Console.ReadLine();
            string[] selection = { Bible, Book, Chapter, Verse };
            return selection;
        }
    }
}
