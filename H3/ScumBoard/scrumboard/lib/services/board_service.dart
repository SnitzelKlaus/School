import 'package:scrumboard/services/models/board.dart';
import 'package:scrumboard/services/models/post.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

class BoardService {
  Future<Board> getBoard() async {
    try {
      final response = await http
          .get(Uri.parse('https://localhost:7131/api/ScrumBoard/board?id=1'));
      final responseJson = json.decode(response.body);

      return responseJson;
    } catch (e) {
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
