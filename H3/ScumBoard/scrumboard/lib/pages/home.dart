import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:scrumboard/services/board_service.dart';
import 'package:scrumboard/pages/board_overview/board_overview.dart';
import 'package:scrumboard/services/connectivity_service.dart';

class Home extends StatelessWidget {
  const Home({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Scrum Board Demo',
      home: MultiRepositoryProvider(
        providers: [
          RepositoryProvider(
            create: (context) => BoardService(),
          ),
          RepositoryProvider(
            create: (context) => ConnectivityService(),
          ),
        ],
        child: const BoardOverView(),
      ),
    );
  }
}