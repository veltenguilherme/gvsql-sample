using Persistence.Controllers.Base.CustomAttributes;
using Persistence.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Tables.Sale
{
    [Table("sales")]
    public class Model : Model<Model>
    {
        [Column("code")]
        [TypeInfo(DataType.INTEGER_NOT_NULL)]
        public int Code { get; set; }

        [Column("user_fk")]
        [Fk("usr", "uuid", FkType.ON_DELETE_CASCADE_ON_UPDATE_NO_ACTION_NOT_NULL)]
        [TypeInfo(DataType.GUID)]
        public Guid? UserGuid { get; set; }

        [Persistence.Controllers.Base.CustomAttributes.JoinType("sales", "user_fk", Persistence.Models.JoinType.INNER)]
        public User.Model User { get; set; } = new User.Model();

        [Column("customer_fk")]
        [Fk("customer", "uuid", FkType.ON_DELETE_CASCADE_ON_UPDATE_NO_ACTION_NOT_NULL)]
        [TypeInfo(DataType.GUID)]
        public Guid? CustomerGuid { get; set; }

        [Persistence.Controllers.Base.CustomAttributes.JoinType("sales", "customer_fk", Persistence.Models.JoinType.INNER)]
        public Customer.Model Customer { get; set; } = new Customer.Model();

        [Column("partner_fk")]
        [Fk("partner", "uuid", FkType.ON_DELETE_CASCADE_ON_UPDATE_NO_ACTION)]
        [TypeInfo(DataType.GUID)]
        public Guid? PartnerGuid { get; set; }

        [Persistence.Controllers.Base.CustomAttributes.JoinType("sales", "partner_fk", Persistence.Models.JoinType.LEFT)]
        public Partner.Model Partner { get; set; } = new Partner.Model();
    }
}