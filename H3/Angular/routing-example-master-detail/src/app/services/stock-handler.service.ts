import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Stock } from '../interfaces/stock';
import { map, Observable } from 'rxjs';
import { MessageService } from './message.service';

@Injectable({
  providedIn: 'root'
})
export class StockHandlerService {

  url: string = "http://localhost:3000";
  endpointAllStocks: string = "/stocks";
  endpointStock: string = "/stock";

  constructor(private http: HttpClient, private messageService: MessageService) { }

  getAllStocks(init: boolean): Observable<Stock[]> {
    const stocks$ = this.http.get<Stock[]>(this.url + this.endpointAllStocks);
    if (stocks$ && init) {
      this.messageService.addMessage("Fetched all stocks");
    }
    return stocks$;
  }

  getStock(symbol: string): Observable<Stock> {
    const stock$ = this.getAllStocks(false).pipe(map((stocks: Stock[]) => stocks.find(stock => stock.symbol === symbol)!));
    if (stock$) {
      this.messageService.addMessage("Fetched stock " + symbol);
    }

    return stock$;
  }
}
