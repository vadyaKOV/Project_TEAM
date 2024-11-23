using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p=Person;

namespace Article
{
    internal class Article
    {
        public Article(Person.Person person, string Name, double mark)
        {
            Person = person;
            NameTitle = Name;
            Mark = mark;
        }
        public Article()
        {
            Person = new Person.Person();
            NameTitle = "Черный дельфин";
            Mark = 10.0;
        }
        public override string ToString()
        {
            return ($"{Person.ToShortString()} Название: {NameTitle} Оценка: {Mark}");
        }
    //    public Person.Person Person { get; set; }
        public p.Person Person { get; set; }
        public string NameTitle { get; set; }
        public double Mark { get; set; }
    }
}
