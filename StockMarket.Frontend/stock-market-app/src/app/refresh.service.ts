import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RefreshService {
  private refreshOrdersSubject = new Subject<void>();

  refreshOrdersObservable = this.refreshOrdersSubject.asObservable();

  refreshOrders() {
    this.refreshOrdersSubject.next();
  }
}
