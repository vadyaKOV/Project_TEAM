using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    internal class Person
    {
        private string name;
        private string surname;
        private DateTime birthday;

        public Person()
        {
            name = "Vasya";
            surname = "Pupkin";
            birthday = new DateTime(2024, 09, 09);
        }

        public Person(string Name, string Surname, DateTime Birthday)
        {
            name = Name;
            surname = Surname;
            birthday = Birthday;
        }

        public string Name { get { return name; } set { name = value; } }
        public string Surname { get { return surname; } set { surname = value; } }
        public DateTime Birthday { get { return birthday; } set { birthday = value; } }
        public int Birthdayint { get { return Birthday.Year; } set { birthday = new DateTime(value, birthday.Month, birthday.Day); } }

        public override string ToString()
        {
            return ($"{Name} {Surname} родился {Birthday}");
        }


        public virtual string ToShortString()
        {
            return ($"Имя: {Name}  Фамилия: {Surname}");
        }


        public virtual bool Equals(object obj)
        {

            if (obj == null || obj.GetType() != this.GetType())
                return false;

            var other = (Person)obj;
            return this.Name == other.Name &&
                   this.Surname == other.Surname &&
                   this.Birthday == other.Birthday;
        }


        public virtual int GetHashCode()
        {
            return HashCode.Combine(Name, Surname, Birthday);
        }


        public static bool operator ==(Person p1, Person p2)
        {

            if (ReferenceEquals(p1, p2)) return true;
            if (p1 == null || p2 == null) return false;

            return p1.Equals(p2);
        }


        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1 == p2);
        }

        public virtual Person DeepCopy()
        {
            return new Person(this.Name, this.Surname, this.Birthday);
        }
    }
}
