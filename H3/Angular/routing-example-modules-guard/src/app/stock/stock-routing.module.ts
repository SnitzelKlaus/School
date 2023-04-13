import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StockDetailComponent } from './components/stock-detail/stock-detail.component';
import { StockMasterComponent } from './components/stock-master/stock-master.component';
import { StockVisitedComponent } from './components/stock-visited/stock-visited.component';
import { StockComponent } from './stock.component';

const routes: Routes = [
  {
    path: 'stock', component: StockComponent, children: [
      {
        path: '', children: [
          { path: '', component: StockMasterComponent },
          { path: ':symbol', outlet: 'detail', component: StockDetailComponent },
          { path: 'messages', outlet: 'visited', component: StockVisitedComponent },
        ]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StockRoutingModule { }
