import 'package:json_annotation/json_annotation.dart';

part 'note_entity.g.dart';

@JsonSerializable()
class NoteListResponse {
  List<NoteEntity> notes;

  NoteListResponse({required this.notes});

  factory NoteListResponse.fromJson(Map<String, dynamic> json) =>
      _$NoteListResponseFromJson(json);

  Map<String, dynamic> toJson() => _$NoteListResponseToJson(this);
}

@JsonSerializable()
class NoteEntity {
  int id;
  String title;
  String content;
  DateTime date;
  int priority;

  NoteEntity(
      {required this.id,
      required this.title,
      required this.content,
      required this.date,
      required this.priority});

  factory NoteEntity.fromJson(Map<String, dynamic> json) =>
      _$NoteEntityFromJson(json);

  Map<String, dynamic> toJson() => _$NoteEntityToJson(this);
}
