import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarIdComponent } from './components/car-id/car-id.component';
import { CarComponent } from './components/car/car.component';

const routes: Routes = [
  { path: 'car', component: CarComponent },
  { path: 'car/:id', component: CarIdComponent },
  { path: '', redirectTo: '/car', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
