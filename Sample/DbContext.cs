namespace ConsoleApp
{
    internal class DbContext : Persistence.DbContext
    {
        public Tables.Person.Table Person = new Tables.Person.Table();

        public Tables.User.Table User = new Tables.User.Table();
    }
}