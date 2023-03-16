import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, NgForm, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MorseCodePipe } from './pipes/morse-code.pipe';
import { MorseCodeComponent } from './components/morse-code/morse-code.component';

@NgModule({
  declarations: [
    AppComponent,
    MorseCodePipe,
    MorseCodeComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
