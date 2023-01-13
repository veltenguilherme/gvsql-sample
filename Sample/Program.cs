using Persistence;
using Persistence.Controllers.Base.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new Database(hostName: "localhost",
                         port: 5432,
                         name: "sample",
                         userName: "postgres",
                         password: "123Mudar",
                         schema: GetSchema());

            var person = InsertPerson().Result;
            var user = InsertUser().Result;
            var customer = InsertCustomer().Result;
            var partner = InsertPartner().Result;
            var sale = InsertSale().Result;

            var persons = new Tables.Person.Table().ToListAsync(new Query<Tables.Person.Model>(x => x.FirstName == user.Person.FirstName)).Result;
            var users = new Tables.User.Table().ToListAsync(new Query<Tables.User.Model>(x => x.Person.FirstName == user.Person.FirstName)).Result;
            var customers = new Tables.Customer.Table().ToListAsync(new Query<Tables.Customer.Model>(x => x.Person.FirstName == partner.Person.FirstName)).Result;
            var patners = new Tables.Partner.Table().ToListAsync(new Query<Tables.Partner.Model>(x => x.Person.FirstName == customer.Person.FirstName)).Result;
            var sales = new Tables.Sale.Table().ToListAsync(new Query<Tables.Sale.Model>(x => x.Partner.Person.FirstName == sale.User.Person.FirstName)).Result;
        }

        private static List<Structure> GetSchema()
        {
            return new List<Structure>()
            {
                new Structure()
                {
                    Model =  typeof(Tables.Person.Model),
                    Table = typeof(Tables.Person.Table)
                },
                new Structure()
                {
                    Model =  typeof(Tables.User.Model),
                    Table = typeof(Tables.User.Table)
                },
                new Structure()
                {
                    Model =  typeof(Tables.Customer.Model),
                    Table = typeof(Tables.Customer.Table)
                },
                new Structure()
                {
                    Model =  typeof(Tables.Partner.Model),
                    Table = typeof(Tables.Partner.Table)
                },
                new Structure()
                {
                    Model =  typeof(Tables.Sale.Model),
                    Table = typeof(Tables.Sale.Table)
                }
            };
        }

        private static async Task<Tables.User.Model> InsertUser()
        {
            return await new Tables.User.Table().UpdateOrInsertAsync(new Tables.User.Model()
            {
                NickName = Guid.NewGuid().ToString(),
                Password = "123",
                PersonGuid = InsertPerson().Result?.Guid
            });
        }

        private static async Task<Tables.Customer.Model> InsertCustomer()
        {
            return await new Tables.Customer.Table().UpdateOrInsertAsync(new Tables.Customer.Model()
            {
                NickName = Guid.NewGuid().ToString(),
                PersonGuid = InsertPerson().Result?.Guid
            });
        }

        private static async Task<Tables.Partner.Model> InsertPartner()
        {
            return await new Tables.Partner.Table().UpdateOrInsertAsync(new Tables.Partner.Model()
            {
                NickName = Guid.NewGuid().ToString(),
                PersonGuid = InsertPerson().Result?.Guid
            });
        }

        private static async Task<Tables.Sale.Model> InsertSale()
        {
            return await new Tables.Sale.Table().UpdateOrInsertAsync(new Tables.Sale.Model()
            {
                Code = 1,
                UserGuid = InsertUser().Result?.Guid,
                CustomerGuid = InsertCustomer().Result?.Guid,
                PartnerGuid = InsertPartner().Result?.Guid
            });
        }

        private static async Task<Tables.Person.Model> InsertPerson()
        {
            return await new Tables.Person.Table().UpdateOrInsertAsync(new Tables.Person.Model()
            {
                FirstName = "Guilherme",
                LastName = "Velten",
                Birth = new DateTime(1993, 09, 14),
                Age = DateTime.Now.Year - new DateTime(1993, 09, 14).Year,
                Sex = Tables.Person.EnmSex.MALE
            });
        }
    }
}