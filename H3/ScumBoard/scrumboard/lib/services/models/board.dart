import 'dart:convert';
import 'package:scrumboard/services/models/post.dart';

List<Board> boardFromJson(String str) =>
    List<Board>.from(json.decode(str).map((x) => Board.fromJson(x)));

String boardToJson(List<Board> data) =>
    json.encode(List<dynamic>.from(data.map((x) => x.toJson())));

class Board {
  Board({
    required this.id,
    required this.title,
    required this.description,
    required this.dateCreated,
    required this.dateModified,
    required this.posts,
  });

  final int id;
  final String title;
  final String description;
  final DateTime dateCreated;
  final DateTime dateModified;
  final List<Post> posts;

  factory Board.fromJson(Map<String, dynamic> json) => Board(
        id: json["Id"],
        title: json["Title"],
        description: json["description"],
        dateCreated: DateTime.parse(json["DateCreated"]),
        dateModified: DateTime.parse(json["DateModified"]),
        posts: List<Post>.from(json["posts"].map((x) => Post.fromJson(x))),
      );

  Map<String, dynamic> toJson() => {
        "Id": id,
        "Title": title,
        "description": description,
        "DateCreated": dateCreated.toIso8601String(),
        "DateModified": dateModified.toIso8601String(),
        "posts": List<dynamic>.from(posts.map((x) => x.toJson())),
      };
}

//     final board = boardFromJson(jsonString);
