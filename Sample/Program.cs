using ConsoleApp.Models;
using ConsoleApp.Tables;
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

            var persons = new Persons().ToListAsync(new Query<Person>(x => x.FirstName == user.Person.FirstName)).Result;
            var users = new Users().ToListAsync(new Query<User>(x => x.Person.FirstName == user.Person.FirstName)).Result;
            var customers = new Customers().ToListAsync(new Query<Customer>(x => x.Person.FirstName == partner.Person.FirstName)).Result;
            var patners = new Partners().ToListAsync(new Query<Partner>(x => x.Person.FirstName == customer.Person.FirstName)).Result;
            var sales = new Sales().ToListAsync(new Query<Sale>(x => x.Partner.Person.FirstName == sale.User.Person.FirstName)).Result;
        }

        private static List<Structure> GetSchema()
        {
            return new List<Structure>()
            {
                new Structure()
                {
                    Model =  typeof(Person),
                    Table = typeof(Persons)
                },
                new Structure()
                {
                    Model =  typeof(User),
                    Table = typeof(Users)
                },
                new Structure()
                {
                    Model =  typeof(Customer),
                    Table = typeof(Customers)
                },
                new Structure()
                {
                    Model =  typeof(Partner),
                    Table = typeof(Partners)
                },
                new Structure()
                {
                    Model =  typeof(Sale),
                    Table = typeof(Sales)
                }
            };
        }
        private static async Task<User> InsertUser()
        {
            return await new Users().UpdateOrInsertAsync(new User()
            {
                NickName = Guid.NewGuid().ToString(),
                Password = "123",
                PersonGuid = InsertPerson().Result?.Guid
            });
        }

        private static async Task<Customer> InsertCustomer()
        {
            return await new Customers().UpdateOrInsertAsync(new Customer()
            {
                NickName = Guid.NewGuid().ToString(),
                PersonGuid = InsertPerson().Result?.Guid
            });
        }

        private static async Task<Partner> InsertPartner()
        {
            return await new Partners().UpdateOrInsertAsync(new Partner()
            {
                NickName = Guid.NewGuid().ToString(),
                PersonGuid = InsertPerson().Result?.Guid
            });
        }

        private static async Task<Sale> InsertSale()
        {
            return await new Sales().UpdateOrInsertAsync(new Sale()
            {
                Code = 1,
                UserGuid = InsertUser().Result?.Guid,
                CustomerGuid = InsertCustomer().Result?.Guid,
                PartnerGuid = InsertPartner().Result?.Guid
            });
        }

        private static async Task<Person> InsertPerson()
        {
            return await new Persons().UpdateOrInsertAsync(new Person()
            {
                FirstName = "Guilherme",
                LastName = "Velten",
                Birth = new DateTime(1993, 09, 14),
                Age = DateTime.Now.Year - new DateTime(1993, 09, 14).Year,
                Sex = EnmSex.MALE
            });
        }
    }
}