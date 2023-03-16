import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { MorseCodePipe } from '../../pipes/morse-code.pipe';

@Component({
  selector: 'app-morse-code',
  templateUrl: './morse-code.component.html',
  styleUrls: ['./morse-code.component.css']
})
export class MorseCodeComponent {
  // Morse code
  morseCode: string = '';

  // Form
  morseForm: FormGroup = new FormGroup({
    text: new FormControl('', [Validators.required])
  });

  // Submit form
  onSubmit() {
    this.convertToMorseCode(this.morseForm.value.text);
  }

  // Convert text to morse code
  convertToMorseCode(text: string) {
    this.morseCode = new MorseCodePipe().transform(text);
  }

  constructor() { }
}
