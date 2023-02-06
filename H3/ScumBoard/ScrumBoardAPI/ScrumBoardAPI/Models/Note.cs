namespace ScrumBoardAPI.Models
{
    public class Note
    {
        public Note(int id, string title, string content, DateTime date, int priority)
        {
            _id = id;
            _title = title;
            _content = content;
            _date = date;
            _priority = priority;
        }

        public int Id { get => _id; set => _id = value; }
        public string Title { get => _title; set => _title = value; }
        public string Content { get => _content; set => _content = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public int Priority { get => _priority; set => _priority = value; }

        private int _id;
        private string _title;
        private string _content;
        private DateTime _date;
        private int _priority;
    }
}
