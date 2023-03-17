import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { CarRoutingModule } from './car-routing.module';
import { CarComponent } from '../components/car/car.component';
import { CarIdComponent } from '../components/car-id/car-id.component';

const appRoutes: Routes = [
  { path: 'car', component: CarComponent },
  { path: 'car/:id', component: CarIdComponent },
  { path: '', redirectTo: '/car', pathMatch: 'full' }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    CarRoutingModule,
    RouterModule.forRoot(appRoutes)
  ]
})
export class CarModule { }
