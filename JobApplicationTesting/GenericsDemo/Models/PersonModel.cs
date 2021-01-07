using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsDemo.Models
{
    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAlive { get; set; } = true;
    }
}
