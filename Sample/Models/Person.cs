using ConsoleApp.Tables;
using Persistence.Controllers.Base.CustomAttributes;
using Persistence.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models
{
    [Table("person")]
    public class Person : Model<Person>
    {
        [Column("first_name")]
        [SqlType(SqlTypes.TEXT_NOT_NULL)]
        public string FirstName { get; set; }

        [Column("last_name")]
        [SqlType(SqlTypes.TEXT_NOT_NULL)]
        public string LastName { get; set; }

        [Column("sex")]
        [SqlType(SqlTypes.INTEGER_NOT_NULL)]
        public Sex Sex { get; set; }

        [Column("birth")]
        [SqlType(SqlTypes.DATE_NOT_NULL)]
        public DateTime Birth { get; set; }

        [Column("age")]
        [SqlType(SqlTypes.INTEGER_NOT_NULL)]
        public int Age { get; set; }

        [Column("death")]
        [SqlType(SqlTypes.DATE)]
        public DateTime? Death { get; set; }
    }

    public enum Sex
    {
        FEMALE = 1,
        MALE
    }
}