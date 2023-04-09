import { Component } from '@angular/core';
import { MessageService } from 'src/app/services/message.service';

@Component({
  selector: 'app-stock-visited',
  templateUrl: './stock-visited.component.html',
  styleUrls: ['./stock-visited.component.css']
})
export class StockVisitedComponent {
  constructor(public messageService: MessageService) { }
}
