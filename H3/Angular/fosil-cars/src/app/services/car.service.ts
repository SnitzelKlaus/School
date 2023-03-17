import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of, Subject } from 'rxjs';
import { Car } from '../interfaces/car';

@Injectable({
  providedIn: 'root'
})
export class CarService {
  private subjectFossilCars: Subject<Array<Car>> = new BehaviorSubject<Car[]>([]);

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

  // Adds a car object to fossilCars array
  addFossilCar(car: Car): void {
    this.fossilCars.push(car);
  }

  // Updates a car object in fossilCars array
  updateFossilCar(car: Car): void {
    const index = this.fossilCars.findIndex((c) => c.id === car.id);
    this.fossilCars[index] = car;
  }

  // Checks car id to see if it exists in fossilCars array
  // Returns true or false
  carExistById(id: number | null): boolean {
    if (id === null) {
      return false;
    }
    return this.fossilCars.some((car) => car.id === id);
  }

  // Deletes a car object from fossilCars array
  deleteFossilCar(id: number): void {
    this.fossilCars = this.fossilCars.filter((car) => car.id !== id);
    this.subjectFossilCars.next(this.fossilCars);
  }

  // Returns a car object from fossilCars array
  getFossilCarById(id: number): Car | undefined {
    return this.fossilCars.find((car) => car.id === id);
  }

  // Sorts fossilCars array by id
  sortFossilCarsById(): Array<Car> {
    return this.fossilCars.sort((a, b) => a.id - b.id);
  }

  // Returns fossilCars array as an Observable
  emitFossilCars(): Observable<Array<Car>> {
    this.subjectFossilCars.next(this.fossilCars);
    return this.subjectFossilCars.asObservable();
  }

  ngOnInit(): void {
    this.subjectFossilCars.next(this.fossilCars);
  }
}
