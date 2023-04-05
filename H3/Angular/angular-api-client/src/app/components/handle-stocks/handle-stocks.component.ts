import { Component, OnInit } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Stock } from 'src/app/interfaces/stock';
import { HandleStockService } from 'src/app/services/handle-stock.service';
import { MatSnackBar } from '@angular/material/snack-bar';


/* FormGroup factory */
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-handle-stocks',
  templateUrl: './handle-stocks.component.html',
  styleUrls: ['./handle-stocks.component.css']
})

// Reminder for future Benjamin:
// Command for running the app: ng serve --open

export class HandleStocksComponent implements OnInit {
  private stocksSubjects$: BehaviorSubject<Stock[]> = new BehaviorSubject<Stock[]>([]);
  stocks$: Observable<Stock[]> | undefined;

  /* Add stock */
  addStockForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    symbol: new FormControl('', [Validators.required]),
    price: new FormControl(null, [Validators.required]),
  });

  constructor(private apiService: HandleStockService, private snackBar: MatSnackBar) { }

  getAllStocks(): void {
    this.apiService.getAllStocks().subscribe((stocks: Stock[]) => {
      next: {
        if (this.apiService.dirty) {
          this.stocksSubjects$.next(stocks);
          this.stocks$ = this.stocksSubjects$.asObservable();
          this.apiService.dirty = false;

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

  /* Form validation*/
  private regValid(): boolean | undefined {
    return this.addStockForm.get('name')?.valid &&
      this.addStockForm.get('symbol')?.valid &&
      this.addStockForm.get('price')?.valid;
  }

  // Error messages
  getErrorMessageName(): string {
    if (this.addStockForm.get('name')?.hasError('required')) {
      return 'You must enter a value';
    }
    return '';
  }

  getErrorMessageSymbol(): string | void {
    if (this.addStockForm.get('symbol')?.hasError('required')) {
      return 'You must enter a value';
    }
  }

  getErrorMessagePrice(): string | void {
    if (this.addStockForm.get('price')?.hasError('required')) {
      return 'You must enter a value';
    }
  }

  onSubmit(): void {
    if (this.regValid()) {
      const stock = {} as Stock;
      stock.name = this.addStockForm.get('name')?.value!;
      stock.symbol = this.addStockForm.get('symbol')?.value!;
      stock.price = this.addStockForm.get('price')?.value!;

      this.apiService.addStock(stock).subscribe((stuff) => {
        next: {
          console.log(stuff);
          this.apiService.dirty = true;
          this.snackBar.open("Stock added!")._dismissAfter(2000);
          this.getAllStocks();
        }
      });
    }
  }

  ngOnInit(): void {
    this.getAllStocks();
  }
}
