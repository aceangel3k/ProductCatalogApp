import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, interval, Subscription } from 'rxjs';
import { AlertifyService } from '../_services/alertify.service';
import { Product } from '../_models/product';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  baseUrl = `${environment.apiUrl}products`;
  products: Product[];
  updateProducts: Subscription;

  constructor(private http: HttpClient, private alertify: AlertifyService) { }

  ngOnInit() {
    this.getProducts();
    this.updateProducts = interval(2000).subscribe((val) => {
      this.getProducts();
    });
  }
// TODO: move to productService
  getProducts() {
    this.http.get<Product[]>(this.baseUrl)
      .subscribe(response => {
        if (this.products === undefined) {
          this.products = response;
        }
        if (this.products.length < response.length) {
          this.products = response;
        }
      }, error => {
        this.alertify.error(error);
      });
  }

}
