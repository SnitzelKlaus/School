part of 'board_bloc.dart';

abstract class BoardEvent extends Equatable {
  const BoardEvent();
}

class LoadApiEvent extends BoardEvent {
  final int id;

  const LoadApiEvent({required this.id});

  @override
  List<Object> get props => [id];
}
