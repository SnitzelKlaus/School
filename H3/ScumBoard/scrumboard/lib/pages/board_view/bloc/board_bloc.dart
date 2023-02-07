import 'dart:async';
import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:scrumboard/services/board_service.dart';

part 'board_event.dart';
part 'board_state.dart';

class BoardBloc extends Bloc<BoardEvent, BoardState> {
  final BoardService _boardService;

  BoardBloc(this._boardService) : super(BoardLoadingState()) {
    on<LoadApiEvent>((event, emit) async {
      final board = await _boardService.getBoard();
      emit(BoardLoadedState(
          id: board.id, title: board.title, description: board.description));
    });
  }
}
