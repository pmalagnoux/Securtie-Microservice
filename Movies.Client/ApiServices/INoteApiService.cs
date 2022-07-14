using Notes.Client.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notes.Client.ApiServices
{
    public interface INoteApiService
    {
        Task<IEnumerable<Note>> GetNotes();
        Task<Note> GetNote(string id);
        Task<Note> CreateNote(Note note);
        Task<Note> UpdateNote(Note note);
        Task DeleteNote(int id);
        Task<UserInfoViewModel> GetUserInfo();
    }
}
