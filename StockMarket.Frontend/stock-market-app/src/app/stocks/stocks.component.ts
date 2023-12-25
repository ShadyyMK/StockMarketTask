import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { StockMarketService } from '../stock-market.service';
import { RefreshService } from '../refresh.service';
import { PlaceOrderModalComponent } from '../place-order-modal/place-order-modal.component';

@Component({
  selector: 'app-stocks',
  templateUrl: './stocks.component.html',
  styleUrls: ['./stocks.component.css']
})
export class StocksComponent implements OnInit {
  stocks: any[] = [];

  constructor(
    private stockMarketService: StockMarketService, 
    public dialog: MatDialog,
    private refreshService: RefreshService,
    private changeDetectorRef: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.getStocks();
    this.stockMarketService.stockUpdateListener().subscribe(updatedStocks => {
      this.stocks = updatedStocks;
      this.changeDetectorRef.detectChanges();
    });
  }

  getStocks(): void {
    this.stockMarketService.getStocks().subscribe(
      data => this.stocks = data,
      error => console.error('There was an error fetching stocks!', error)
    );
  }

  openOrderModal(stock: any): void {
    const dialogRef = this.dialog.open(PlaceOrderModalComponent, {
      width: '250px',
      data: { stock }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.refreshService.refreshOrders();
      }
    });
  }
}
