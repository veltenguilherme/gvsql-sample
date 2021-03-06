using Persistence;
using Persistence.Controllers.Base.Queries;

namespace ConsoleApp
{
    internal class Program
    {
        private static DbContext Context { get; set; }

        private static void Main(string[] args)
        {
            var db = new Database("localhost", 5432, "sample", "postgres", "123Mudar");

            Context = new DbContext();
            db.SetTables(Context);

            if (!Database.Exists) return;

            User(Person());
        }

        private static Tables.Person.Model Person()
        {
            var result = Context.Person.UpdateOrInsertAsync(new Tables.Person.Model()
            {
                FirstName = "Guilherme",
                LastName = "Velten",
                Age = 27
            }).Result;

            var results = Context.Person.ToListAsync(new Query<Tables.Person.Model>(x => x.FirstName == "Guilherme"), false).Result;

            return result;
        }

        private static void User(Tables.Person.Model person)
        {
            var result = Context.User.UpdateOrInsertAsync(new Tables.User.Model()
            {
                NickName = "gvelten",
                Password = "123Mudar",
                PersonGuid = person.Guid
            }).Result;

            var results = Context.User.ToListAsync(new Query<Tables.User.Model>(x => x.NickName == "gvelten"), false).Result;
        }
    }
}