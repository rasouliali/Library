using Library.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities.UserEntities
{
    public class Session : EntityBase
    {
        [ForeignKey("CurrentUserInfo")]
        public int UserId { get; set; }
        [StringLength(36)]
        public string Token { get; set; }
        public DateTime ExireDateTime { get; set; }
        public UserInfo CurrentUserInfo { get; set; }
    }
}
