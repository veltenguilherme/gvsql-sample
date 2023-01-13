using ConsoleApp.Models;
using Persistence.Controllers;

namespace ConsoleApp.Tables
{
    public class Partners : Table<Partner>
    {
        public Partners(bool create = false, bool createView = false) : base(create, createView)
        {
        }
    }
}