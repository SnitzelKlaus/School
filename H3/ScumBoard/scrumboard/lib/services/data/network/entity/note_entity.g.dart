// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'note_entity.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

NoteListResponse _$NoteListResponseFromJson(Map<String, dynamic> json) =>
    NoteListResponse(
      notes: (json['notes'] as List<dynamic>)
          .map((e) => NoteEntity.fromJson(e as Map<String, dynamic>))
          .toList(),
    );

Map<String, dynamic> _$NoteListResponseToJson(NoteListResponse instance) =>
    <String, dynamic>{
      'notes': instance.notes,
    };

NoteEntity _$NoteEntityFromJson(Map<String, dynamic> json) => NoteEntity(
      id: json['id'] as int,
      title: json['title'] as String,
      content: json['content'] as String,
      date: DateTime.parse(json['date'] as String),
      priority: json['priority'] as int,
    );

Map<String, dynamic> _$NoteEntityToJson(NoteEntity instance) =>
    <String, dynamic>{
      'id': instance.id,
      'title': instance.title,
      'content': instance.content,
      'date': instance.date.toIso8601String(),
      'priority': instance.priority,
    };
