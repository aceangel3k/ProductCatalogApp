import { Component, OnInit } from '@angular/core';
import { ProductService } from '../_services/product.service';
import { Product } from '../_models/product';
import { AlertifyService } from '../_services/alertify.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
    selector: 'app-create',
    templateUrl: './create.component.html',
    styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {
    product: Product;
    createForm: FormGroup;

    constructor(private productService: ProductService,
                private alertify: AlertifyService, private fb: FormBuilder, private router: Router) {}

    ngOnInit() {
        this.createCreateForm();
    }

    createCreateForm() {
        this.createForm = this.fb.group({
            name: ['', Validators.required],
            description: [''],
            photoUrl: ['', Validators.pattern(/\b(https?|ftp|file):\/\/[\-A-Za-z0-9+&@#\/%?=~_|!:,.;]*[\-A-Za-z0-9+&@#\/%=~_|]/)],
            quantity: ['', Validators.required]
        });
    }

    create() {
        if (this.createForm.valid) {
            this.product = Object.assign({}, this.createForm.value);
            this.productService.create(this.product).subscribe(() => {
                this.alertify.success('Product created successfully.');
            }, error => {
                this.alertify.error(error);
            });
        }
    }

    cancel() {
        this.router.navigate(['/list']);
    }
}
