import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { StockMarketService } from '../stock-market.service';
import { RefreshService } from '../refresh.service';

@Component({
  selector: 'app-place-order-modal',
  templateUrl: './place-order-modal.component.html',
  styleUrls: ['./place-order-modal.component.css']
})
export class PlaceOrderModalComponent {
  orderForm: FormGroup;

  constructor(
    private stockMarketService: StockMarketService,
    private refreshService: RefreshService,
    public dialogRef: MatDialogRef<PlaceOrderModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private formBuilder: FormBuilder
  ) {
    this.orderForm = this.formBuilder.group({
      personName: ['', Validators.required],
      quantity: [1, [Validators.required, Validators.min(1)]]
    });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  placeOrder(): void {
    if (this.orderForm.valid) {
      const orderData = {
        stockId: this.data.stock.id,
        personName: this.orderForm.value.personName,
        quantity: this.orderForm.value.quantity,
        price: this.data.stock.price
      };
      this.stockMarketService.placeOrder(orderData).subscribe({
        next: (response) => {
          console.log('Order placed successfully', response);
          this.dialogRef.close();
          this.refreshService.refreshOrders();
        },
        error: (error) => {
          console.error('Error placing order', error);
        }
      });
    }
  }

  
}
