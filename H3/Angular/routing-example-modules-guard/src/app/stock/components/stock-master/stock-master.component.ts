import { Component } from '@angular/core';
import { Subject } from 'rxjs';
import { Stock } from 'src/app/interfaces/stock';
import { StockHandlerService } from 'src/app/services/stock-handler.service';


@Component({
  selector: 'app-stock-master',
  templateUrl: './stock-master.component.html',
  styleUrls: ['./stock-master.component.css']
})
export class StockMasterComponent {
  stockSubject$ = new Subject<Stock[]>();

  constructor(private stockHandlerService: StockHandlerService) {
    this.stockHandlerService.getAllStocks(true).subscribe((stocks: Stock[]) => {
      next: {
        this.stockSubject$.next(stocks);
      }
    });
  }
}
