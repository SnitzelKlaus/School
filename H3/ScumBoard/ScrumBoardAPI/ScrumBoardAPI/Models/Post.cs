namespace ScrumBoardAPI.Models
{
    public class Post
    {
        public Post(int id, string title, List<Note> notes)
        {
            _id = id;
            _title = title;
            _notes = notes;
        }

        public int Id { get => _id; set => _id = value; }
        public string Title { get => _title; set => _title = value; }
        public List<Note> Notes { get => _notes; set => _notes = value; }

        private int _id;
        private string _title;
        private List<Note> _notes;
    }
}
