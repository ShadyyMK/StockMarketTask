import { Component, OnInit } from '@angular/core';
import { StockMarketService } from '../stock-market.service';
import { RefreshService } from '../refresh.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  orders: any[] = [];

  constructor(
    private stockMarketService: StockMarketService,
    private refreshService: RefreshService
  ) { }

  ngOnInit(): void {
    this.getOrders();
    this.refreshService.refreshOrdersObservable.subscribe(() => {
      this.getOrders();
    });
  }

  getOrders(): void {
    this.stockMarketService.getOrders().subscribe(
      data => this.orders = data,
      error => console.error('There was an error fetching orders!', error)
    );
  }
}
