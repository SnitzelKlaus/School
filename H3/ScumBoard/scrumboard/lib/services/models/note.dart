class Note {
  Note({
    required this.id,
    required this.title,
    required this.content,
    required this.date,
    required this.priority,
  });

  final int id;
  final String title;
  final String content;
  final DateTime date;
  final int priority;

  factory Note.fromJson(Map<String, dynamic> json) => Note(
        id: json["Id"],
        title: json["Title"],
        content: json["Content"],
        date: DateTime.parse(json["Date"]),
        priority: json["Priority"],
      );

  Map<String, dynamic> toJson() => {
        "Id": id,
        "Title": title,
        "Content": content,
        "Date": date.toIso8601String(),
        "Priority": priority,
      };
}
