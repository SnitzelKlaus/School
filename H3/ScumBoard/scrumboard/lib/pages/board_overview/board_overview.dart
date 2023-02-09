import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:scrumboard/services/board_service.dart';
import 'package:scrumboard/pages/board_overview/bloc/board_bloc.dart';
import 'package:scrumboard/services/connectivity_service.dart';
import 'package:scrumboard/services/widgets/board_card.dart';
import 'package:scrumboard/utils/colors.dart';
import 'package:scrumboard/utils/fonts.dart';
import 'package:scrumboard/services/functions/create_board.dart';

class BoardOverView extends StatefulWidget {
  const BoardOverView({super.key});

  @override
  State<BoardOverView> createState() => _BoardOverViewState();
}

class _BoardOverViewState extends State<BoardOverView> {
  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (context) => BoardBloc(
        RepositoryProvider.of<BoardService>(context),
        RepositoryProvider.of<ConnectivityService>(context),
      )..add(LoadApiEvent()),
      child: Scaffold(
        backgroundColor: backgroundColor,
        appBar: AppBar(
          title: Center(
            child: Text(
              'Board Overview:',
              style: TextStyle(
                color: fontColor,
                fontSize: fontTitleSize,
              ),
            ),
          ),
          backgroundColor: primaryColor,
        ),
        body: BlocBuilder<BoardBloc, BoardState>(
          builder: (context, state) {
            if (state is BoardLoadingState) {
              return const Center(
                child: CircularProgressIndicator(),
              );
            }
            if (state is BoardLoadedState) {
              return SingleChildScrollView(
                child: Wrap(
                  children: [
                    for (final board in state.boards)
                      BoardCard(
                        board: board,
                        view: () {
                          //Navigator.pushNamed(context, '/board_view',
                              //arguments: board);
                        },
                        delete: () {
                          setState(() {
                            state.boards.remove(board);
                          });
                        },
                      ),
                    Padding(
                      padding: const EdgeInsets.fromLTRB(80, 100, 80, 100),
                      child: SizedBox(
                        height: 70,
                        width: 70,
                        child: FloatingActionButton(
                          onPressed: () => {
                            setState(
                              () => {
                                state.boards.add(createBoard('New board',
                                    'Just a nice board', state.boards)),
                              },
                            )
                          },
                          backgroundColor: primaryColor,
                          child: Icon(
                            Icons.add,
                            size: 50,
                            color: primaryFontButtonColor,
                          ),
                        ),
                      ),
                    ),
                  ],
                ),
              );
            }
            if (state is BoardNoInternetState) {
              return Center(
                child: Text(
                  'No internet connection :(',
                  style: TextStyle(
                    color: fontColor,
                  ),
                ),
              );
            }
            return Container();
          },
        ),
      ),
    );
  }
}



/*
                  ElevatedButton(
                    onPressed: () => BlocProvider.of<BoardBloc>(context)
                        .add(LoadApiEvent()),
                    child: Text('Load next board'),
                  ),
*/