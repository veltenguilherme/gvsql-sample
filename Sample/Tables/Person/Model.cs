using Persistence.Controllers.Base.CustomAttributes;
using Persistence.Models;
using System;
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

        [Column("sex")]
        [TypeInfo(DataType.INTEGER_NOT_NULL)]
        public EnmSex Sex { get; set; }

        [Column("birth")]
        [TypeInfo(DataType.DATE_NOT_NULL)]
        public DateTime Birth { get; set; }

        [Column("age")]
        [TypeInfo(DataType.INTEGER_NOT_NULL)]
        public int Age { get; set; }

        [Column("death")]
        [TypeInfo(DataType.DATE)]
        public DateTime? Death { get; set; }
    }

    public enum EnmSex
    {
        FEMALE = 1,
        MALE
    }
}