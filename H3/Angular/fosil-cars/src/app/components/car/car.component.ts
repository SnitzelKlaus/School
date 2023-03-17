import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { Car } from 'src/app/interfaces/car';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent {
  // Observable array
  fossilCars$: Observable<Array<Car>>;

  // Creates a new FormGroup with FormControl objects
  // The FormControl objects are used to validate the form and to bind the form to the model
  carForm: FormGroup = new FormGroup({
    id: new FormControl('', [Validators.required, Validators.min(1)]),
    model: new FormControl('', [Validators.required, Validators.minLength(1)]),
    quantity: new FormControl('', [Validators.required, Validators.min(1)]),
    changeQuantityPercent: new FormControl('', [Validators.required, Validators.min(1)]),
  });

  // This method is called when the user clicks the "Submit" button
  onSubmit(): void {
    // Create a new car object
    const car: Car = {
      id: this.carForm.value.id,
      model: this.carForm.value.model,
      quantity: this.carForm.value.quantity,
      changeQuantityPercent: this.carForm.value.changeQuantityPercent,
    };

    // If carForm is invalid, do nothing
    if (this.carForm.invalid) {
      return;
    }

    // If carForm is valid, add or update car
    if (!this.carService.carExistById(car.id)) {
      this.carService.addFossilCar(car);
      this.carService.sortFossilCarsById();
    } else {
      this.carService.updateFossilCar(car);
    }
  }

  // This method is called when the user clicks the "Delete" button
  onDelete(id: number): void {
    this.carService.deleteFossilCar(id);
  }

  constructor(private carService: CarService) {
    this.fossilCars$ = this.carService.emitFossilCars();
    console.log(this.fossilCars$);
  }
}
