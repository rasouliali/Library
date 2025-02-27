using Library.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities.UserEntities
{
    public class UserRole : EntityBase
    {
        [ForeignKey("CurrentUserInfo")]
        public int UserId { get; set; }
        [ForeignKey("CurrentRole")]
        public int RoleId { get; set; }
        public virtual UserInfo CurrentUserInfo { get; set; }
        public virtual Role CurrentRole { get; set; }
    }
}
