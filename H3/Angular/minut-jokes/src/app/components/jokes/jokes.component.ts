import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Joke } from 'app/interfaces/joke';
import { JokeService } from 'app/services/joke.service';

@Component({
  selector: 'app-jokes',
  templateUrl: './jokes.component.html',
  styleUrls: ['./jokes.component.css']
})
export class JokesComponent {

  Constructor(jokeService: JokeService) {
    this.jokeService = jokeService;
  }

  jokeService = new JokeService();

  //jokeSetup$: Observable<Joke> | undefined;

  jokeSetup$: Observable<string> | undefined;
  jokePunchline$: Observable<string> | undefined;

  onClick() {
    const index = this.jokeService.getRandomJoke();
    this.jokeSetup$ = this.jokeService.getJoke(index);
    setTimeout(() => {
      this.jokePunchline$ = this.jokeService.getPunchline(index);
    }, 3000);
  }
}
