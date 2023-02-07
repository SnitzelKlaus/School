// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'post_entity.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

PostListResponse _$PostListResponseFromJson(Map<String, dynamic> json) =>
    PostListResponse(
      posts: (json['posts'] as List<dynamic>)
          .map((e) => PostEntity.fromJson(e as Map<String, dynamic>))
          .toList(),
    );

Map<String, dynamic> _$PostListResponseToJson(PostListResponse instance) =>
    <String, dynamic>{
      'posts': instance.posts,
    };

PostEntity _$PostEntityFromJson(Map<String, dynamic> json) => PostEntity(
      id: json['id'] as int,
      title: json['title'] as String,
      notes: (json['notes'] as List<dynamic>)
          .map((e) => NoteEntity.fromJson(e as Map<String, dynamic>))
          .toList(),
    );

Map<String, dynamic> _$PostEntityToJson(PostEntity instance) =>
    <String, dynamic>{
      'id': instance.id,
      'title': instance.title,
      'notes': instance.notes,
    };
