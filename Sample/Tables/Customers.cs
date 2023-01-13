using ConsoleApp.Models;
using Persistence.Controllers;

namespace ConsoleApp.Tables
{
    public class Customers : Table<Customer>
    {
        public Customers(bool create = false, bool createView = false) : base(create, createView)
        {
        }
    }
}