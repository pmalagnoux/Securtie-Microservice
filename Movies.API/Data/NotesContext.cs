using Microsoft.EntityFrameworkCore;

namespace Notes.API.Data
{
    public class NotesContext : DbContext
    {
        public NotesContext (DbContextOptions<NotesContext> options)
            : base(options)
        {
        }

        public DbSet<Notes.API.Models.Note> Note { get; set; }
    }
}
