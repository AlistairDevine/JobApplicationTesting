using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTesting
{
    public class PersonModel
    {
        public int Id { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public PersonModel()
        {

        }
        public PersonModel(int id, string firstname, string lastname)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
        }
    }
}
