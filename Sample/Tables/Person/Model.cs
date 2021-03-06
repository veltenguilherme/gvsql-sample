using Persistence.Controllers.Base.CustomAttributes;
using Persistence.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Tables.Person
{
    [Table("person")]
    public class Model : Model<Model>
    {
        [Column("first_name")]
        [TypeInfo(DataType.TEXT_NOT_NULL)]
        public string FirstName { get; set; }

        [Column("last_name")]
        [TypeInfo(DataType.TEXT_NOT_NULL)]
        public string LastName { get; set; }

        [Column("age")]
        [TypeInfo(DataType.INTEGER)]
        public int Age { get; set; }
    }
}