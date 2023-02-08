import 'dart:async';
import 'package:bloc/bloc.dart';
import 'package:connectivity_plus/connectivity_plus.dart';
import 'package:equatable/equatable.dart';
import 'package:scrumboard/services/board_service.dart';
import 'package:scrumboard/services/connectivity_service.dart';

part 'board_event.dart';
part 'board_state.dart';

class BoardBloc extends Bloc<BoardEvent, BoardState> {
  final BoardService _boardService;
  final ConnectivityService _connectivityService;

  BoardBloc(this._boardService, this._connectivityService)
      : super(BoardLoadingState()) {
    _connectivityService.connectivityStream.stream.listen((event) {
      if (event == ConnectivityResult.none) {
        print('No internet connection');
        add(NoInternetEvent());
      }
    });

    on<LoadApiEvent>((event, emit) async {
      emit(BoardLoadingState());
      final board = await _boardService.getBoard(event.id);
      emit(BoardLoadedState(
          id: board.id, title: board.title, description: board.description));
    });
  }
}
