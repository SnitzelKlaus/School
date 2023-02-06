import 'package:testscrumboard/services/domain/note.dart';

class Post {
  int id;
  String title;
  List<Note> notes;

  Post({required this.id, required this.title, required this.notes});
}




  /*
  static fromJson(x) {
    return Post(
      id: x['id'],
      title: x['title'],
      notes: List<Note>.from(x['notes'].map((x) => Note.fromJson(x))),
    );
  }
  */
