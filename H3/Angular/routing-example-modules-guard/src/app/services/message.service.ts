import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  private messages: Array<string> = [];
  private msgSub$: BehaviorSubject<string[]> = new BehaviorSubject<string[]>(this.messages);
  messages$ = this.msgSub$.asObservable();

  constructor(private router: Router) { }

  clearMessages(): void {
    this.messages.splice(0);
    this.router.navigate([{ outlets: { visited: null } }]);
  }

  addMessage(message: string): void {
    this.messages.push(message);
    this.router.navigate([{ outlets: { visited: ['messages'] } }]);
  }
}
