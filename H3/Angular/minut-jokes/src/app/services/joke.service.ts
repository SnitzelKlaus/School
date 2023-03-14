import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Joke } from '../interfaces/joke';

@Injectable({
  providedIn: 'root'
})
export class JokeService {

  joke: Joke[] = [
    {
      id: 1,
      setup: 'What did the cheese say when it looked in the mirror?',
      punchline: 'Hello-Me (Halloumi)'
    },
    {
      id: 2,
      setup: 'What kind of cheese do you use to disguise a small horse?',
      punchline: 'Mask-a-pony (Mascarpone)'
    },
    {
      id: 3,
      setup: 'A kid threw a lump of cheddar at me',
      punchline: 'I thought ‘That’s not very mature’'
    },
    {
      id: 4,
      setup: 'What is the most musical cheese?',
      punchline: 'Treb-le Gouda'
    },
    {
      id: 5,
      setup: 'What do you call cheese that isn’t yours?',
      punchline: 'Nacho Cheese'
    },
    {
      id: 6,
      setup: 'What do you call a fake noodle?',
      punchline: 'An Impasta'
    }];

  // Gets a random joke
  public getRandomJoke(): Observable<Joke> {
    const randomIndex = Math.floor(Math.random() * this.joke.length);
    return of(this.joke[randomIndex]);
  }
}
