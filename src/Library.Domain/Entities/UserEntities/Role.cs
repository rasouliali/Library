using Library.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities.UserEntities
{
    public class Role : EntityBase
    {
        [StringLength(100)]
        public string Title { get; set; }
    }
}
