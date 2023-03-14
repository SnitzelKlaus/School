import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TestService {
  
  // Random number generator
  public randomNumber(): Observable<number> {
    return of(Math.random());
  }
}