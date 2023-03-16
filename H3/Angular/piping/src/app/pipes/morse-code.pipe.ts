import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'morseCode'
})
export class MorseCodePipe implements PipeTransform {
  transform(text: string): string {
    // Morse Code Dictionary
    const morseDictionary = {
      'A': '.-',
      'B': '-...',
      'C': '-.-.',
      'D': '-..',
      'E': '.',
      'F': '..-.',
      'G': '--.',
      'H': '....',
      'I': '..',
      'J': '.---',
      'K': '-.-',
      'L': '.-..',
      'M': '--',
      'N': '-.',
      'O': '---',
      'P': '.--.',
      'Q': '--.-',
      'R': '.-.',
      'S': '...',
      'T': '-',
      'U': '..-',
      'V': '...-',
      'W': '.--',
      'X': '-..-',
      'Y': '-.--',
      'Z': '--..',
      '1': '.----',
      '2': '..---',
      '3': '...--',
      '4': '....-',
      '5': '.....',
      '6': '-....',
      '7': '--...',
      '8': '---..',
      '9': '----.',
      '0': '-----',
      ',': '--..--',
      '.': '.-.-.-',
      '?': '..--..',
      '"': '.-..-.',
      ':': '---...',
      '-': '-....-',
      '/': '-..-.',
      '(': '-.--.',
      ')': '-.--.-',
    };

    // Map morse code dictionary to Map object
    let map = new Map(Object.entries(morseDictionary));

    // Convert string to uppercase
    text = text.toUpperCase();

    // Split string into array of characters
    const textArray = text.split('');

    // Convert each character to morse code and return string
    return textArray.map((char) => map.get(char)).join(' ');
  }

}
