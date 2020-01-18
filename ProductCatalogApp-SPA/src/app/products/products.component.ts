import { Component, OnInit, DoCheck } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AlertifyService } from '../_services/alertify.service';
import { Product } from '../_models/product';
import { environment } from 'src/environments/environment';
import { SignalRService } from '../_services/signal-r.service';

@Component({
    selector: 'app-products',
    templateUrl: './products.component.html',
    styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit, DoCheck {
    baseUrl = `${environment.apiUrl}products`;
    products: Product[];

    constructor(
        private http: HttpClient,
        public signalRService: SignalRService,
        private alertify: AlertifyService
    ) {}

    ngOnInit() {
        this.signalRService.startConnection();
        this.signalRService.addTransferProductDataListener();
        this.startHttpRequest();
        this.getProducts();
    }

    ngDoCheck() {
        if (this.products === undefined && this.signalRService.products !== undefined) {
            this.products = this.signalRService.products;
        } else if (this.signalRService.products !== undefined) {
            if (this.products.length < this.signalRService.products.length) {
                this.products = this.signalRService.products;
            }
        }
    }

    private startHttpRequest = () => {
        this.http.get(`${environment.apiUrl}producthub`).subscribe(res => {
            console.log(res);
        });
    };

    // TODO: move to productService
    getProducts() {
        this.http.get<Product[]>(this.baseUrl).subscribe(
            response => {
                if (this.products === undefined) {
                    this.products = response;
                } else {
                    if (this.products.length < response.length) {
                        this.products = response;
                    }
                }
            },
            error => {
                this.alertify.error(error);
            }
        );
    }
}
