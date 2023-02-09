import 'package:flutter/src/widgets/placeholder.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:scrumboard/services/models/board.dart';
import 'package:scrumboard/services/models/post.dart';
import 'package:scrumboard/services/models/note.dart';

Function createBoard = (String title, String description, List<Board> boards) {
  // loops through all boards and finds a valid id
  int id = 0;
  for (var i = 0; i < boards.length; i++) {
    if (boards[i].id == id) {
      id++;
    }
  }

  return Board(
    id: id,
    title: title,
    description: description,
    posts: <Post>[
      Post(
        id: 1,
        title: 'To Do',
        notes: <Note>[
          Note(
            id: 1,
            title: 'Note 1',
            content: 'content 1',
            date: DateTime.now(),
            priority: 2,
          ),
          Note(
            id: 2,
            title: 'Note 2',
            content: 'content 2',
            date: DateTime.now(),
            priority: 2,
          ),
          Note(
            id: 3,
            title: 'Note 3',
            content: 'content 3',
            date: DateTime.now(),
            priority: 2,
          ),
        ],
      ),
      Post(
        id: 2,
        title: 'In Progress',
        notes: <Note>[
          Note(
            id: 1,
            title: 'Note 1',
            content: 'content 1',
            date: DateTime.now(),
            priority: 2,
          ),
          Note(
            id: 2,
            title: 'Note 2',
            content: 'content 2',
            date: DateTime.now(),
            priority: 2,
          ),
          Note(
            id: 3,
            title: 'Note 3',
            content: 'content 3',
            date: DateTime.now(),
            priority: 2,
          ),
        ],
      ),
      Post(
        id: 3,
        title: 'Done',
        notes: <Note>[
          Note(
            id: 1,
            title: 'Note 1',
            content: 'content 1',
            date: DateTime.now(),
            priority: 2,
          ),
          Note(
            id: 2,
            title: 'Note 2',
            content: 'content 2',
            date: DateTime.now(),
            priority: 2,
          ),
          Note(
            id: 3,
            title: 'Note 3',
            content: 'content 3',
            date: DateTime.now(),
            priority: 2,
          ),
        ],
      ),
    ],
    dateCreated: DateTime.now(),
    dateModified: DateTime.now(),
  );
};
