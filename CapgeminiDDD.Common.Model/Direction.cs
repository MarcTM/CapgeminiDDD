using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapgeminiDDD.Common.Model
{
    public class Direction
    {
        public Direction()
        {
        }

        public Direction(string street, int number, int floor,  int door, int studentId)
        {
            Street = street;
            Number = number;
            Floor = floor;
            Door = door;
            StudentId = studentId;
        }

        public int Id{ get; set; }

        public string Street { get; set; }

        public int Number { get; set; }

        public int Floor { get; set; }

        public int Door { get; set; }

        public int StudentId { get; set; }

        public Student Student;
    }
}
