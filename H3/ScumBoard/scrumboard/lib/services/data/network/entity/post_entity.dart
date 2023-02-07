import 'package:json_annotation/json_annotation.dart';
import 'package:testscrumboard/services/data/network/entity/note_entity.dart';

part 'post_entity.g.dart';

@JsonSerializable()
class PostListResponse {
  List<PostEntity> posts;

  PostListResponse({required this.posts});

  factory PostListResponse.fromJson(Map<String, dynamic> json) =>
      _$PostListResponseFromJson(json);

  Map<String, dynamic> toJson() => _$PostListResponseToJson(this);
}

@JsonSerializable()
class PostEntity {
  int id;
  String title;
  List<NoteEntity> notes;

  PostEntity({required this.id, required this.title, required this.notes});

  factory PostEntity.fromJson(Map<String, dynamic> json) =>
      _$PostEntityFromJson(json);

  Map<String, dynamic> toJson() => _$PostEntityToJson(this);
}
