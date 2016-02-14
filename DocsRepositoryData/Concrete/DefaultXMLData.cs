using DocsStorageData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocsStorageData.Concrete
{
    public class DefaultXMLData
    {
        private List<Document> list;

        public DefaultXMLData()
        {
            list = new List<Document>()
                                       {
                                           new Document("C# 2010 и платформа .NET 4.0", 
                                                        new DateTime(2010, 01, 01), 
                                                        "Эндрю Троэлсен", 
                                                        ".NET,4.0,C#,программирование"),
                                           
                                           new Document("WPF в.NET 4.0 с примерами на С#",
                                                        new DateTime(2010, 02, 10),
                                                        "Мэтью Мак-Доналд", 
                                                        ".NET,4.0,C#,программирование,WPF"),
                                           
                                           new Document("ASP.NET 4.0 с примерами на С#", 
                                                        new DateTime(2010, 03, 15), 
                                                        "Мэтью Мак-Доналд", 
                                                        ".NET,4.0,C#,программирование,ASP"),
                                           //#######################################################################################
                                           
                                           new Document("C# 5.0 и платформа .NET 4.5", 
                                                         new DateTime(2013, 01, 01), 
                                                         "Кристиан Нэйгель", 
                                                         ".NET,4.5,C#,программирование"),
                                           
                                           new Document("WPF в C# 5.0 и платформа .NET 4.5", 
                                                        new DateTime(2013, 02, 10), 
                                                        "Мэтью Мак-Доналд", 
                                                        ".NET,4.5,C#,программирование,WPF"),

                                           new Document("C# 2010 и платворма .NET 4.0", 
                                                        new DateTime(2013, 03, 28),
                                                        "Адам Фримэн",
                                                        ".NET,5.0,C#,программирование,ASP,MVC"),
                                           //########################################################################################

                                           new Document("jQuery", 
                                                        new DateTime(2013, 06, 06), 
                                                        "Адам Фримэн", 
                                                        "jQuery,WEB,JavaScrip"),

                                           new Document("Душан Петкович",
                                                        new DateTime(2008, 11, 12),
                                                        "MS SQL 2008", 
                                                        "Базы данных,SQL"),

                                           new Document("Структурный системный анализ", 
                                                        new DateTime(2000, 12, 04), 
                                                        "Вадим Качала", 
                                                        "Теория систем,Управление,Проектирование")
                                       };
        }
        public List<Document> DefaultData 
        { 
            get
            {
                return list;
            }
        }
    }
}
