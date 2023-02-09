import 'package:flutter/material.dart';
import 'package:drag_and_drop_lists/drag_and_drop_lists.dart';
import 'package:scrumboard/utils/colors.dart';
import 'package:scrumboard/utils/fonts.dart';
import 'package:scrumboard/services/models/board.dart';

class BoardView extends StatelessWidget {
  const BoardView({super.key});

  @override
  Widget build(BuildContext context) {
    final board = ModalRoute.of(context)!.settings.arguments as Board;

    return Scaffold(
      backgroundColor: backgroundColor,
      appBar: AppBar(
        title: Text('Board View:',
            style: TextStyle(
              color: fontColor,
              fontSize: fontTitleSize,
            )),
        backgroundColor: primaryColor,
      ),
      body: Column(
        children: [
          Column(
            children: [
              Text(
                board.title,
                style: TextStyle(
                  color: fontColor,
                  fontSize: fontTitleSize,
                ),
              ),
              Text(
                board.description,
                style: TextStyle(
                  color: fontColor,
                  fontSize: fontTitleSize,
                ),
              ),
            ],
          ),
        ],
      ),
    );
  }
}

/*
class BoardView extends StatefulWidget {
  const BoardView({super.key});

  @override
  State<BoardView> createState() => _BoardViewState();
}


class _BoardViewState extends State<BoardView> {
  late List<DragAndDropList> _contents;

  @override
  Widget build(BuildContext context) {
    final board = ModalRoute.of(context)!.settings.arguments as Board;

    return Scaffold(
      backgroundColor: backgroundColor,
      appBar: AppBar(
        title: Text('Board View:',
            style: TextStyle(
              color: fontColor,
              fontSize: fontTitleSize,
            )),
        backgroundColor: primaryColor,
      ),
      body: Column(
        children: [
          Column(
            children: [
              Text(
                board.title,
                style: TextStyle(
                  color: fontColor,
                  fontSize: fontTitleSize,
                ),
              ),
              Text(
                board.description,
                style: TextStyle(
                  color: fontColor,
                  fontSize: fontTitleSize,
                ),
              ),
            ],
          ),
        ],
      ),
    );
  }
}
*/
