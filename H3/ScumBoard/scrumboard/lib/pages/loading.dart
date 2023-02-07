import 'package:flutter/material.dart';
import 'package:testscrumboard/services/domain/board.dart';
import 'package:flutter_spinkit/flutter_spinkit.dart';

class Loading extends StatefulWidget {
  const Loading({super.key});

  @override
  State<Loading> createState() => _LoadingState();
}

class _LoadingState extends State<Loading> {
  Future<void> setupBoard() async {


    /*
    try {
      // Get data from API
      http.Response response = await http.get(
          Uri.parse('https://localhost:7131/api/ScrumBoard/board?id=$boardId'));

      // Decode data
      Map data = jsonDecode(response.body);

      // Get properties from data
      id = data['id'];
      title = data['title'];
      description = data['description'];
      posts = List<Post>.from(data['posts'].map((x) => Post.fromJson(x)));
      dateCreated = DateTime.parse(data['dateCreated']);
      dateModified = DateTime.parse(data['dateModified']);
    } catch (e) {
      title = 'Board does not exist';
    }
    */
  }

  @override
  void initState() {
    super.initState();
    setupBoard();
  }

  @override
  Widget build(BuildContext context) {
    return const Scaffold(
      backgroundColor: Color.fromARGB(255, 13, 71, 161),
      body: Center(
        child: SpinKitSquareCircle(
          color: Colors.white,
          size: 80.0,
        ),
      ),
    );
  }
}
