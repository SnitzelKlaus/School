part of 'board_bloc.dart';

abstract class BoardState extends Equatable {
  const BoardState();
}

class BoardLoadingState extends BoardState {
  @override
  List<Object> get props => [];
}

class BoardLoadedState extends BoardState {
  final List<Board> boards;

  const BoardLoadedState({
    required this.boards,
  });

  @override
  List<Object> get props => [boards];
}

class BoardNoInternetState extends BoardState {
  @override
  List<Object> get props => [];
}
