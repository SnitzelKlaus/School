part of 'board_bloc.dart';

abstract class BoardEvent extends Equatable {
  const BoardEvent();
}

class LoadApiEvent extends BoardEvent {
  @override
  List<Object> get props => [];
}

class NoInternetEvent extends BoardEvent {
  @override
  List<Object> get props => [];
}
