part of 'board_bloc.dart';

abstract class BoardState extends Equatable {
  const BoardState();
}

class BoardLoadingState extends BoardState {
  @override
  List<Object> get props => [];
}

class BoardLoadedState extends BoardState {
  final int id;
  final String title;
  final String description;

  const BoardLoadedState({
    required this.id,
    required this.title,
    required this.description,
  });

  @override
  List<Object> get props => [id, title, description];
}
