using ConsoleApp.Models;
using Persistence.Controllers;

namespace ConsoleApp.Tables
{
    public class Users : Table<User>
    {
        public Users(bool create = false, bool createView = false) : base(create, createView)
        {
        }
    }
}