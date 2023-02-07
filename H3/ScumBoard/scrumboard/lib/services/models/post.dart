import 'package:scrumboard/services/models/note.dart';

class Post {
  Post({
    required this.id,
    required this.title,
    required this.notes,
  });

  final int id;
  final String title;
  final List<Note> notes;

  factory Post.fromJson(Map<String, dynamic> json) => Post(
        id: json["Id"],
        title: json["Title"],
        notes: List<Note>.from(json["Notes"].map((x) => Note.fromJson(x))),
      );

  Map<String, dynamic> toJson() => {
        "Id": id,
        "Title": title,
        "Notes": List<dynamic>.from(notes.map((x) => x.toJson())),
      };
}
