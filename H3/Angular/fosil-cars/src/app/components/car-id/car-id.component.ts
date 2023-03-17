import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-car-id',
  templateUrl: './car-id.component.html',
  styleUrls: ['./car-id.component.css']
})
export class CarIdComponent {

  private routeSub!: Subscription;
  constructor(private route: ActivatedRoute) { }

  ngOninit() {
    this.routeSub = this.route.params.subscribe(params => {
      console.log(params['id']);
    });
  }

  ngOnDestroy() {
    this.routeSub.unsubscribe();
  }
}
