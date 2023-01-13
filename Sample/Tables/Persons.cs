using Sample.Models;
using Persistence.Controllers;

namespace Sample.Tables
{
    public class Persons : Table<Person>
    {
        public Persons(bool create = false, bool createView = false) : base(create, createView)
        {
        }
    }
}