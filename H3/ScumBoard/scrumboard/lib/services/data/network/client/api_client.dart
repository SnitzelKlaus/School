import 'package:testscrumboard/services/data/network/entity/board_entity.dart';

class CustomException implements Exception {
  final String message;
  final int code;

  CustomException(this.message, this.code);

  @override
  String toString() {
    return 'KoException{message: $message, code: $code}';
  }
}

class ApiClient {
  final String baseUrl;

  ApiClient(this.baseUrl);
}

Future<BoardListResponse> getBoards() async {
  try {
    var response = await Dio().get(baseUrl + '/boards');
    return BoardListResponse.fromJson(response.data);
  } on DioError catch (e) {
    if (e.response != null && e.response!.statusCode != null) {
      throw CustomException(e.response!.statusMessage!, e.response!.statusCode!);
    }
    else{
      throw CustomException(e.message, 0);
    }
  }
}
