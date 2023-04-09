import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StockDetailComponent } from './components/stock/stock-detail/stock-detail.component';
import { StockVisitedComponent } from './components/stock/stock-visited/stock-visited.component';


const routes: Routes = [
  { path: 'stock/:symbol', component: StockDetailComponent },
  { path: 'messages', outlet: 'visited', component: StockVisitedComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
