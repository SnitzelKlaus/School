// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'board_entity.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

BoardListResponse _$BoardListResponseFromJson(Map<String, dynamic> json) =>
    BoardListResponse(
      boards: (json['boards'] as List<dynamic>)
          .map((e) => BoardEntity.fromJson(e as Map<String, dynamic>))
          .toList(),
    );

Map<String, dynamic> _$BoardListResponseToJson(BoardListResponse instance) =>
    <String, dynamic>{
      'boards': instance.boards,
    };

BoardEntity _$BoardEntityFromJson(Map<String, dynamic> json) => BoardEntity(
      id: json['id'] as int,
      title: json['title'] as String,
      description: json['description'] as String,
      dateCreated: DateTime.parse(json['dateCreated'] as String),
      dateModified: DateTime.parse(json['dateModified'] as String),
      posts: (json['posts'] as List<dynamic>)
          .map((e) => PostEntity.fromJson(e as Map<String, dynamic>))
          .toList(),
    );

Map<String, dynamic> _$BoardEntityToJson(BoardEntity instance) =>
    <String, dynamic>{
      'id': instance.id,
      'title': instance.title,
      'description': instance.description,
      'posts': instance.posts,
      'dateCreated': instance.dateCreated.toIso8601String(),
      'dateModified': instance.dateModified.toIso8601String(),
    };
