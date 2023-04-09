import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { Observable, switchMap } from 'rxjs';
import { Stock } from 'src/app/interfaces/stock';
import { StockHandlerService } from 'src/app/services/stock-handler.service';

@Component({
  selector: 'app-stock-detail',
  templateUrl: './stock-detail.component.html',
  styleUrls: ['./stock-detail.component.css']
})
export class StockDetailComponent {
  stock$: Observable<Stock> | undefined;

  constructor(private route: ActivatedRoute, private router: Router, private stockService: StockHandlerService) { }
  
  ngOnInit(): void {
    this.stock$ = this.route.paramMap.pipe(
      switchMap((params: ParamMap) => this.stockService.getStock(params.get('symbol')!)));
     
    //this.stock$ = this.stockService.getStock(this.route.snapshot.params['id']);
  }
}
