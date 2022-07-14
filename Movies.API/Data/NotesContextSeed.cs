using Notes.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Notes.API.Data
{
    public class NotesContextSeed
    {
        public static void SeedAsync(NotesContext notesContext)
        {
            if (!notesContext.Note.Any())
            {
                var notes = new List<Note>
                {
                    new Note
                    {
                        Id = 1,
                        Content = "Test note",
                        Title = "Note Urgente",
                        Date = new DateTime(1994, 5, 5),
                        Owner = "alice"
                    },
                    new Note
                    {
                        Id = 2,
                        Content = "Acheter du lait",
                        Title = "Liste de course",
                        Date = new DateTime(1972, 5, 5),
                        Owner = "alice"
                    },
                    new Note
                    {
                        Id = 3,
                        Content = "ceci est une note",
                        Title = "la note",
                        Date = new DateTime(2008, 5, 5),
                        Owner = "bob"
                    },
                    new Note
                    {
                        Id = 4,
                        Content = "eeeee",
                        Title = "eeee",
                        Date = new DateTime(1957, 5, 5),
                        Owner = "bob"
                    }
                };
                notesContext.Note.AddRange(notes);
                notesContext.SaveChanges();
            }
        }
    }
}
