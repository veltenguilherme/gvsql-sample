using ConsoleApp.Tables;
using Persistence.Controllers.Base.CustomAttributes;
using Persistence.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models
{
    [Table("usr")]
    public class User : Model<User>
    {
        [Column("nick_name")]
        [SqlType(SqlTypes.TEXT_NOT_NULL_UNIQUE)]
        public string NickName { get; set; }

        [Column("password")]
        [SqlType(SqlTypes.TEXT_NOT_NULL)]
        public string Password { get; set; }

        [Column("person_fk")]
        [SqlFk("person", "uuid", SqlFkTypes.ON_DELETE_CASCADE_ON_UPDATE_NO_ACTION_NOT_NULL)]
        [SqlType(SqlTypes.GUID)]
        public Guid? PersonGuid { get; set; }

        [SqlJoinType("usr", "person_fk", SqlJoinTypes.INNER)]
        public Person Person { get; set; } = new Person();
    }
}