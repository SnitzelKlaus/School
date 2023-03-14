import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Car } from 'src/app/interfaces/car';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent {
  eCars$: Observable<Array<Car>> = this.carService.emitCars();
  constructor(private carService: CarService) { }  
}
