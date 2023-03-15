import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
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

  carForm: FormGroup = new FormGroup({
    id: new FormControl(''),
    model: new FormControl(''),
    quantity: new FormControl(''),
    changeQuantityPercent: new FormControl(''),
  });

  onSubmit(): void {
    const car: Car = {
      id: this.carForm.value.id,
      model: this.carForm.value.model,
      quantity: this.carForm.value.quantity,
      changeQuantityPercent: this.carForm.value.changeQuantityPercent,
    };

    if (!this.carService.carExistById(car.id)) {
      this.carService.addFossilCar(car);
    } else {
      this.carService.updateFossilCar(car);
    }
  }

  constructor(private carService: CarService) { }
}
