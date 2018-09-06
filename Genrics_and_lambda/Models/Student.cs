using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genrics_and_lambda.Models
{
    public class Student 
    {
        private static int _id = 1;

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public int Id { get; set; }

        public Student()
        {
            this.Id = _id;
            _id++;
        }
    }
}
