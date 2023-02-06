using ScrumBoardAPI.Models;
using System.Security.Cryptography.X509Certificates;

namespace ScrumBoardAPI
{
    public class Database
    {
        public List<Board> Boards 
        {
            get
            {
                // Creates boards
                List<Board> boards = new List<Board>();


                // Creates notes
                List<Note> notes1 = new List<Note>();

                notes1.Add(new Note(1, "Test1", "Content1", DateTime.Now, 1));
                notes1.Add(new Note(2, "Test2", "Content2", DateTime.Now, 2));
                notes1.Add(new Note(3, "Test3", "Content3", DateTime.Now, 3));
                notes1.Add(new Note(4, "Test4", "Content4", DateTime.Now, 4));
                notes1.Add(new Note(5, "Test5", "Content5", DateTime.Now, 5));

                // Adds notes to post
                List<Post> posts1 = new List<Post>();

                posts1.Add(new Post(1, "Post1", notes1));
                posts1.Add(new Post(2, "Post2", notes1));
                posts1.Add(new Post(3, "Post3", notes1));
                posts1.Add(new Post(4, "Post4", notes1));

                // Creates a board with posts
                boards.Add(new Board(1, "Board1", "1", DateTime.Now, DateTime.Now, posts1));

                // Creates notes
                List<Note> notes2 = new List<Note>();

                notes2.Add(new Note(1, "Test1", "Content1", DateTime.Now, 1));
                notes2.Add(new Note(2, "Test2", "Content2", DateTime.Now, 2));
                notes2.Add(new Note(3, "Test3", "Content3", DateTime.Now, 3));
                notes2.Add(new Note(4, "Test4", "Content4", DateTime.Now, 4));
                notes2.Add(new Note(5, "Test5", "Content5", DateTime.Now, 5));

                // Adds notes to post
                List<Post> posts2 = new List<Post>();

                posts2.Add(new Post(1, "Post1", notes1));
                posts2.Add(new Post(2, "Post2", notes1));
                posts2.Add(new Post(3, "Post3", notes1));
                posts2.Add(new Post(4, "Post4", notes1));

                // Creates a board with posts
                boards.Add(new Board(2, "Board2", "2", DateTime.Now, DateTime.Now, posts2));

                // Returns boards
                return boards;
            }
        }
    }
}
