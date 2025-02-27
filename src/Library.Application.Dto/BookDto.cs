using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string BookCategory { get; set; }
        public required string Author { get; set; }
        public required int PublishYear { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
