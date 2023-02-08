import 'package:scrumboard/services/models/board.dart';
import 'package:scrumboard/services/models/post.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

class BoardService {
  Future<Board> getBoard(int id) async {
    try {
      final response = await http
          .get(Uri.parse('http://localhost:5123/api/ScrumBoard/board?id=$id'));
      final board = boardFromJson(response.body);

      return board;
    } catch (e, stacktrace) {
      print(StackTrace.current);
      print(e);

      return Board(
        id: 0,
        title: 'Error',
        description: 'Error',
        posts: <Post>[],
        dateCreated: DateTime.now(),
        dateModified: DateTime.now(),
      );
    }
  }
}
