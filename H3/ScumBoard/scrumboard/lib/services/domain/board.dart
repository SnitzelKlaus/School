import 'package:testscrumboard/services/domain/post.dart';

class Board {
  int id;
  String title;
  String description;
  List<Post> posts;
  DateTime dateCreated;
  DateTime dateModified;

  Board(
      {required this.id,
      required this.title,
      required this.description,
      required this.dateCreated,
      required this.dateModified,
      required this.posts});
}




/*
  factory Board.fromJson(Map<String, dynamic> json) {
    return Board(
      id: json['id'],
      title: json['title'],
      description: json['description'],
      posts: List<Post>.from(json['tasks'].map((x) => Post.fromJson(x))),
      dateCreated: DateTime.parse(json['dateCreated']),
      dateModified: DateTime.parse(json['dateModified']),
    );
  }

  static Future<Board> fetchBoard() async {
    final response = await http
        .get(Uri.parse('https://localhost:7131/api/ScrumBoard/board?id=1'));

    if (response.statusCode == 200) {
      return Board.fromJson(jsonDecode(response.body));
    } else {
      throw Exception('Failed to load scrum board');
    }
  }



    Future<Board> getBoard(int boardId) async {
    try {
      // Get data from API
      http.Response response = await http.get(
          Uri.parse('https://localhost:7131/api/ScrumBoard/board?id=$boardId'));

      // Decode data
      Map data = jsonDecode(response.body);

      // Get properties from data
      id = data['id'];
      title = data['title'];
      description = data['description'];
      posts = List<Post>.from(data['posts'].map((x) => Post.fromJson(x)));
      dateCreated = DateTime.parse(data['dateCreated']);
      dateModified = DateTime.parse(data['dateModified']);
    } catch (e) {
      title = 'Board does not exist';
      print(e);
    }

    // Return board
    return this;
  }
  */
