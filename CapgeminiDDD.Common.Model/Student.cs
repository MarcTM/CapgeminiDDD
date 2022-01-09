using System;
using System.Collections.Generic;

namespace CapgeminiDDD.Common.Model
{
    public class Student
    {
        public Student() {
        }

        public Student(int id, string name, string surname, int age)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;

            Directions = new HashSet<Direction>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public ICollection<Direction> Directions { get; set; }
    }
}
