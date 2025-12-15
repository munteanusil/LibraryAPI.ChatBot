using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
            AuthorGeneres = new HashSet<AuthorGeneres>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty; 

        public string LastName { get; set; } = string.Empty;

        public string? Nationality { get; set; }

        public string? Biography { get; set; }
 
        public string? Site { get; set; }

        public ICollection<AuthorGeneres>? AuthorGeneres { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
