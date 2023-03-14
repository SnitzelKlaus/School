import { Component } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Joke } from 'src/app/interfaces/joke';
import { JokeService } from 'src/app/services/joke.service';

@Component({
  selector: 'app-jokes',
  templateUrl: './jokes.component.html',
  styleUrls: ['./jokes.component.css']
})
export class JokesComponent {
  jokeService = new JokeService();

  jokeSetup$: Observable<string> | undefined;
  jokePunchline$: Observable<string> | undefined;

  Constructor(jokeService: JokeService) {
    this.jokeService = jokeService;
  }

  // Generates a random joke from click
  onClick() {
    this.jokeSetup$ = this.jokeService.getRandomJoke().pipe(map(joke => joke.setup));
  }


}
