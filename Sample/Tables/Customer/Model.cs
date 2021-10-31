using Persistence.Controllers.Base.CustomAttributes;
using Persistence.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Tables.Customer
{
    [Table("customer")]
    public class Model : Model<Model>
    {
        [Column("nick_name")]
        [TypeInfo(DataType.TEXT_NOT_NULL_UNIQUE)]
        public string NickName { get; set; }

        [Column("person_fk")]
        [Fk("person", "uuid", FkType.ON_DELETE_CASCADE_ON_UPDATE_NO_ACTION_NOT_NULL)]
        [TypeInfo(DataType.GUID)]
        public Guid? PersonGuid { get; set; }

        [Persistence.Controllers.Base.CustomAttributes.JoinType("customer", "person_fk", Persistence.Models.JoinType.INNER)]
        public Person.Model Person { get; set; } = new Person.Model();
    }
}