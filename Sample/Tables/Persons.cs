using ConsoleApp.Models;
using Persistence.Controllers;

namespace ConsoleApp.Tables
{
    public class Persons : Table<Person>
    {
        public Persons(bool create = false, bool createView = false) : base(create, createView)
        {
        }
    }
}