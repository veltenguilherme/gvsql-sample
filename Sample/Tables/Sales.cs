using ConsoleApp.Models;
using Persistence.Controllers;

namespace ConsoleApp.Tables
{
    public class Sales : Table<Sale>
    {
        public Sales(bool create = false, bool createView = false) : base(create, createView)
        {
        }
    }
}