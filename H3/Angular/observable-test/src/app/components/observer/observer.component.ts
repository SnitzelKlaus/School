import { Component } from '@angular/core';
import { interval, Observable } from 'rxjs';
import { TestService } from 'src/app/services/test.service';

@Component({
  selector: 'app-observer',
  templateUrl: './observer.component.html',
  styleUrls: ['./observer.component.css']
})
export class ObserverComponent {
  _testService = new TestService();

  randomNumber$: Observable<number> | undefined;

  constructor(_testService: TestService) {
    this._testService = _testService;
  }

  onClick() {
    this.randomNumber$ = this._testService.randomNumber();
    return this.randomNumber$;
  }
}
