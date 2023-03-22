import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Stock } from '../interfaces/stock';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HandleStockService {

  url: string = "http://localhost:3000";
  endpointAllStocks: string = "/stocks";
  endpointAddStock: string = "/add/stock";
  endpointDeleteStock: string = "/delete/stock";
  endpointUpdateStock: string = "/update/stock";

  private _dirty = true;

  get dirty() { return this._dirty; }
  set dirty(value) { this._dirty = value; }

  constructor(private http: HttpClient) { }

  getAllStocks(): Observable<Stock[]> {
    return this.http.get<Stock[]>(this.url + this.endpointAllStocks);
  }

  addCountry(stock: Stock): Observable<Stock> {
    return this.http.post<Stock>(this.url + this.endpointAddStock, stock);
  }

  deleteCountry(stock: Stock): Observable<Stock> {
    return this.http.post<Stock>(this.url + this.endpointDeleteStock, stock);
  }

  updateCountry(stock: Stock): Observable<Stock> {
    return this.http.post<Stock>(this.url + this.endpointUpdateStock, stock);
  }
}
