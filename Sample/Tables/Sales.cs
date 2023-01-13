using Sample.Models;
using Persistence.Controllers;

namespace Sample.Tables
{
    public class Sales : Table<Sale>
    {
        public Sales(bool create = false, bool createView = false) : base(create, createView)
        {
        }
    }
}