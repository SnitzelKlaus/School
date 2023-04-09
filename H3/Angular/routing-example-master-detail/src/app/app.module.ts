import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StockMasterComponent } from './components/stock/stock-master/stock-master.component';
import { StockDetailComponent } from './components/stock/stock-detail/stock-detail.component';
import { StockVisitedComponent } from './components/stock/stock-visited/stock-visited.component';

@NgModule({
  declarations: [
    AppComponent,
    StockMasterComponent,
    StockDetailComponent,
    StockVisitedComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
