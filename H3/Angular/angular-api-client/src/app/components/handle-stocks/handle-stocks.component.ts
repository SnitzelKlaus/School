import { Component } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Stock } from 'src/app/interfaces/stock';
import { HandleStockService } from 'src/app/services/handle-stock.service';

@Component({
  selector: 'app-handle-stocks',
  templateUrl: './handle-stocks.component.html',
  styleUrls: ['./handle-stocks.component.css']
})

export class HandleStocksComponent {
  private stocksSubjects$: BehaviorSubject<Stock[]> = new BehaviorSubject<Stock[]>([]);
  stocks$: Observable<Stock[]> | undefined;

  constructor(private apiService: HandleStockService) {
    this.apiService.getAllStocks().subscribe((stocks: Stock[]) => {
      next: {
        if (!this.stocks$) {
          this.stocksSubjects$.next(stocks);
          this.stocks$ = this.stocksSubjects$.asObservable();

          if (this.stocks$) {
            this.stocks$.subscribe((stocks: Stock[]) => {
              next: { console.log(stocks); }
            });
          }
        }
      }
      complete: { () => console.log("complete"); }
      error: { (err: any) => console.error(err); }
    });
  }

  
}
