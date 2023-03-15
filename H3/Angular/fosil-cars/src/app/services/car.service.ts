import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Car } from '../interfaces/car';

@Injectable({
  providedIn: 'root'
})
export class CarService {
  fossilCars: Array<Car>;

  constructor() {
    this.fossilCars = [
      { id: 1, model: 'BMW', quantity: 100, changeQuantityPercent: 10 },
      { id: 2, model: 'Mercedes', quantity: 200, changeQuantityPercent: 20 },
      { id: 3, model: 'Audi', quantity: 300, changeQuantityPercent: 30 },
      { id: 4, model: 'Volkswagen', quantity: 400, changeQuantityPercent: 40 },
      { id: 5, model: 'Porsche', quantity: 500, changeQuantityPercent: 50 },
      { id: 6, model: 'Ferrari', quantity: 600, changeQuantityPercent: 60 },
      { id: 7, model: 'Lamborghini', quantity: 700, changeQuantityPercent: 70 },
      { id: 8, model: 'Maserati', quantity: 800, changeQuantityPercent: 80 },
      { id: 9, model: 'Bugatti', quantity: 900, changeQuantityPercent: 90 },
      { id: 10, model: 'Rolls-Royce', quantity: 1000, changeQuantityPercent: 100 },
    ];
  }

  addFossilCar(car: Car): void {
    this.fossilCars.push(car);
  }

  updateFossilCar(car: Car): void {
    const index = this.fossilCars.findIndex((c) => c.id === car.id);
    this.fossilCars[index] = car;
  }

  emitFossilCars(): Observable<Array<Car>> {
    return of(this.fossilCars);
  }
}
