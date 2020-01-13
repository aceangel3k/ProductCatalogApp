import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Product } from '../_models/product';

@Injectable({
    providedIn: 'root'
})
export class ProductService {
    baseUrl = `${environment.apiUrl}products/`;

    constructor(private http: HttpClient) {}

    create(product: Product) {
        return this.http.post(`${this.baseUrl}create`, product);
    }
}
