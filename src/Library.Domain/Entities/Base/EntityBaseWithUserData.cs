using Library.Domain.Entities.UserEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities.Base
{
    public class EntityBaseWithUserData: EntityBase
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public DateTime? CreatedDate { get; set; }
        //public bool IsDeleted { get; set; }
        [ForeignKey("CurrentCreatedUser")]
        public int CreatedUserId { get; set; }
        public UserInfo CurrentCreatedUser { get; set; }
    }
}