namespace ScrumBoardAPI.Models
{
    public class Board
    {
        public Board(int id, string title, string description, DateTime dateCreated, DateTime dateModified, List<Post> posts)
        {
            _id = id;
            _title = title;
            _description = description;
            _dateCreated = dateCreated;
            _dateModified = dateModified;
            _posts = posts;
        }

        public int Id { get => _id; set => _id = value; }
        public string Title { get => _title; set => _title = value; }
        public string description { get => _description; set => _description = value; }
        public DateTime DateCreated { get => _dateCreated; set => _dateCreated = value; }
        public DateTime DateModified { get => _dateModified; set => _dateModified = value; }
        public List<Post> posts { get => _posts; set => _posts = value; }

        private int _id;
        private string _title;
        private string _description;
        private DateTime _dateCreated;
        private DateTime _dateModified;
        private List<Post> _posts;
    }
}
