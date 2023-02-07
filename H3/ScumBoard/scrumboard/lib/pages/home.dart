import 'package:flutter/material.dart';
import 'package:scrumboard/services/board_service.dart';

class Home extends StatelessWidget {
  const Home({super.key});

  @override
  Widget build(BuildContext context) {
    return const MaterialApp(
      title: 'Scrum Board Demo',
      home: MultiRepositoryProvider(
        providers: [
          RepositoryProvider(
            create: (context) => BoardService(),
          ),
        ],
        child: ,
      ),
    );
  }
}