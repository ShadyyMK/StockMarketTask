import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class StockMarketService {
  private apiUrl = 'https://localhost:7040';
  private hubConnection!: signalR.HubConnection;
  private stockUpdateSubject = new Subject<any[]>();

  constructor(private http: HttpClient) {
    this.startConnection();
  }

  getStocks(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/stock`);
  }

  getOrders(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/order`);
  }

  placeOrder(orderData: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/order`, orderData);
  }

  stockUpdateListener(): Observable<any[]> {
    return this.stockUpdateSubject.asObservable();
  }

  private startConnection() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(`${this.apiUrl}/stockPriceHub`)
      .withAutomaticReconnect()
      .build();

    this.hubConnection.start().catch(err => console.error('Error while starting SignalR connection: ', err));

    this.hubConnection.on('ReceiveStockPriceUpdate', (stocks) => {
      this.stockUpdateSubject.next(stocks);
    });
  }
}
