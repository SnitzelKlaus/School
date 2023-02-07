class Note {
  int id;
  String title;
  String content;
  DateTime date;
  int priority;

  Note(
      {required this.id,
      required this.title,
      required this.content,
      required this.date,
      required this.priority});
}




  /*
  static fromJson(x) {
    return Note(
      id: x['id'],
      title: x['title'],
      content: x['content'],
      date: DateTime.parse(x['date']),
      priority: x['priority'],
    );
  }
  */