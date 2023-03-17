import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatTableModule } from '@angular/material/table'
import { FormsModule, NgForm, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CarComponent } from './components/car/car.component';
import { CarModule } from './car/car.module';
import { CarIdComponent } from './components/car-id/car-id.component';

@NgModule({
  declarations: [
    AppComponent,
    CarComponent,
    CarIdComponent
  ],
  imports: [
    BrowserModule,
    MatTableModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CarModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
