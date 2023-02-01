import 'package:flutter/material.dart';

void main() => runApp(
      const MaterialApp(
        home: Home(),
      ),
    );

class Home extends StatelessWidget {
  const Home({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Nice App'),
        backgroundColor: Colors.blueGrey[900],
        centerTitle: true,
      ),
      backgroundColor: Colors.blueGrey,
      body: Column(
        mainAxisAlignment: MainAxisAlignment.end,
        crossAxisAlignment: CrossAxisAlignment.end,
        children: <Widget>[
          Row(
            children: const <Widget>[
              Text('Hello'),
              Text('World'),
            ],
          ),
          Container(
            padding: const EdgeInsets.all(30.0),
            color: Colors.blue,
            child: const Text('Two'),
          ),
          Container(
            padding: const EdgeInsets.all(40.0),
            color: Colors.green,
            child: const Text('Three'),
          ),
          Container(
            padding: const EdgeInsets.all(20.0),
            color: Colors.amber,
            child: const Text('One'),
          ),
        ],
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () {},
        backgroundColor: Colors.blueGrey[900],
        child: const Text('Click'),
      ),
    );
  }
}
