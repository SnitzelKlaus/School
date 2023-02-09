import 'package:flutter/material.dart';
import 'package:scrumboard/services/models/board.dart';
import 'package:scrumboard/utils/colors.dart';
import 'package:scrumboard/utils/fonts.dart';
import 'package:intl/intl.dart';

class BoardCard extends StatelessWidget {
  final Board board;
  final Function delete;
  final Function view;

  const BoardCard(
      {Key? key, required this.board, required this.delete, required this.view})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(10.0),
      child: SizedBox(
        height: 250,
        width: 220,
        child: Card(
          child: Padding(
            padding: const EdgeInsets.all(10.0),
            child: Column(
              children: [
                Column(
                  children: [
                    const SizedBox(
                      height: 10,
                    ),
                    Text(
                      board.title,
                      style: TextStyle(
                        color: fontContainerColor,
                        fontSize: fontSubtitleSize,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                    const SizedBox(
                      height: 10,
                    ),
                    Text(
                      board.description,
                      style: TextStyle(
                        color: fontContainerColor,
                        fontSize: fontBodySize,
                      ),
                    ),
                    const SizedBox(
                      height: 10,
                    ),
                  ],
                ),
                Expanded(
                  flex: 2,
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.center,
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Column(
                        children: [
                          Text(
                            'Created:',
                            style: TextStyle(
                              color: fontContainerColorLight,
                              fontSize: fontBodySize,
                            ),
                          ),
                          Text(
                            DateFormat.yMEd()
                                .add_jms()
                                .format(board.dateCreated),
                            style: TextStyle(
                              color: fontContainerColorLight,
                              fontSize: fontBodySize,
                            ),
                          ),
                        ],
                      ),
                      const SizedBox(
                        height: 10,
                      ),
                      Column(
                        children: [
                          Text(
                            'Last modified:',
                            style: TextStyle(
                              color: fontContainerColorLight,
                              fontSize: fontBodySize,
                            ),
                          ),
                          Text(
                            DateFormat.yMEd()
                                .add_jms()
                                .format(board.dateModified),
                            style: TextStyle(
                              color: fontContainerColorLight,
                              fontSize: fontBodySize,
                            ),
                          ),
                        ],
                      ),
                    ],
                  ),
                ),
                const SizedBox(
                  height: 10,
                ),
                Expanded(
                  flex: 1,
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                    crossAxisAlignment: CrossAxisAlignment.end,
                    children: [
                      TextButton(
                        onPressed: () => view(),
                        child: Text(
                          'View',
                          style: TextStyle(
                            color: secondaryFontButtonColor,
                            fontSize: fontButtonSize,
                          ),
                        ),
                      ),
                      TextButton.icon(
                        onPressed: () => delete(),
                        style: ButtonStyle(
                          backgroundColor: MaterialStateProperty.all(
                              secondaryFontButtonColor),
                        ),
                        label: Text(
                          'delete',
                          style: TextStyle(
                            color: primaryFontButtonColor,
                            fontSize: fontButtonSize,
                          ),
                        ),
                        icon: Icon(
                          Icons.delete,
                          color: primaryFontButtonColor,
                        ),
                      ),
                    ],
                  ),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}


/*
createBoard(
                        'New board', 'Just a nice board', state.boards),
                    backgroundColor: primaryColor,
                    child: Icon(
                      Icons.add,
                      size: 40,
                      color: primaryFontButtonColor,
                    ),
                    */