using Persistence.Controllers;

namespace ConsoleApp.Tables.Customer
{
    public class Table : Table<Model>
    {
        public Table(bool create = false, bool createView = false) : base(create, createView)
        {
        }
    }
}