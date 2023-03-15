import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Car } from 'src/app/interfaces/car';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent {
  fossilCars$: Observable<Array<Car>> = this.carService.emitFossilCars();

  displayedColumns: string[] = ['Id', 'model', 'quantity', 'changeQuantityPercent'];
  dataSource = this.fossilCars$;
  clickedRows = new Set<Car>();

  constructor(private carService: CarService) { }

  addFossilCar(car: Car): void {
    this.carService.addFossilCar(car);
  }

  updateFossilCar(car: Car): void {
    this.carService.updateFossilCar(car);
  }
}
