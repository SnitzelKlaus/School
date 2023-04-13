import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StockRoutingModule } from './stock-routing.module';
import { StockMasterComponent } from './components/stock-master/stock-master.component';
import { StockDetailComponent } from './components/stock-detail/stock-detail.component';
import { StockVisitedComponent } from './components/stock-visited/stock-visited.component';
import { StockComponent } from './stock.component';


@NgModule({
  declarations: [
    StockMasterComponent,
    StockDetailComponent,
    StockVisitedComponent,
    StockComponent
  ],
  imports: [
    CommonModule,
    StockRoutingModule
  ]
})
export class StockModule { }
