using System;
using System.Collections.Generic;
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

        private static void readVerse() 
        { 
            string verse = getVerse(chooseVerse()); 
            Console.WriteLine($"Verse: {verse}"); 
        }
        private static string[] chooseVerse()
        {
            string Bible = "KJV.xml"; // CustomBible.xml     
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
        private static string getVerse(string[] selection)
        {
            string bible = selection[0]; 
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
            
            return output;    }
        }
    }
