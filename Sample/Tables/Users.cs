using Sample.Models;
using Persistence.Controllers;

namespace Sample.Tables
{
    public class Users : Table<User>
    {
        public Users(bool create = false, bool createView = false) : base(create, createView)
        {
        }
    }
}