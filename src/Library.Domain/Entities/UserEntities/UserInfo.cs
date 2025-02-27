using Library.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities.UserEntities
{
    public class UserInfo : EntityBase
    {
        [StringLength(250)]
        public required string FullName { get; set; }
        [StringLength(250)]
        public required string UserName { get; set; }
        [StringLength(50)]
        public string Tel { get; set; }
        [StringLength(100)]
        public string PasswordHash { get; set; }
        [StringLength(64)]
        public string Salt { get; set; }
        public virtual List<UserRole> UserRoles { get; set; }
        public virtual List<Session> Sessions { get; set; }
    }
}
