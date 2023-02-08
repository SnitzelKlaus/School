import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:scrumboard/services/board_service.dart';
import 'package:scrumboard/pages/board_view/bloc/board_bloc.dart';

class BoardView extends StatefulWidget {
  const BoardView({super.key});

  @override
  State<BoardView> createState() => _BoardViewState();
}

class _BoardViewState extends State<BoardView> {
  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (context) => BoardBloc(
        RepositoryProvider.of<BoardService>(context),
      )..add(const LoadApiEvent(id: 1)),
      child: Scaffold(
        appBar: AppBar(
          title: const Text('Scrum Board Demo'),
        ),
        body: BlocBuilder<BoardBloc, BoardState>(
          builder: (context, state) {
            if (state is BoardLoadingState) {
              return const Center(
                child: CircularProgressIndicator(),
              );
            }
            if (state is BoardLoadedState) {
              return Column(
                children: [
                  Text(state.id.toString()),
                  Text(state.title),
                  Text(state.description),
                  ElevatedButton(
                    onPressed: () => BlocProvider.of<BoardBloc>(context)
                        .add(LoadApiEvent(id: 2)),
                    child: Text('Load next board'),
                  ),
                ],
              );
            }
            return Container();
          },
        ),
      ),
    );
  }
}
