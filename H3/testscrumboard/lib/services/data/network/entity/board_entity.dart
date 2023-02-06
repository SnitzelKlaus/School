import 'package:json_annotation/json_annotation.dart';
import 'package:testscrumboard/services/data/network/entity/post_entity.dart';

part 'board_entity.g.dart';

@JsonSerializable()
class BoardListResponse {
  List<BoardEntity> boards;

  BoardListResponse({required this.boards});

  factory BoardListResponse.fromJson(Map<String, dynamic> json) =>
      _$BoardListResponseFromJson(json);

  Map<String, dynamic> toJson() => _$BoardListResponseToJson(this);
}

@JsonSerializable()
class BoardEntity {
  int id;
  String title;
  String description;
  List<PostEntity> posts;
  DateTime dateCreated;
  DateTime dateModified;

  BoardEntity(
      {required this.id,
      required this.title,
      required this.description,
      required this.dateCreated,
      required this.dateModified,
      required this.posts});

  factory BoardEntity.fromJson(Map<String, dynamic> json) =>
      _$BoardEntityFromJson(json);

  Map<String, dynamic> toJson() => _$BoardEntityToJson(this);
}
