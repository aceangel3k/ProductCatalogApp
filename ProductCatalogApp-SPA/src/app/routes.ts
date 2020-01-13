import { Routes } from '@angular/router';
import { ProductsComponent } from './products/products.component';
import { CreateComponent } from './create/create.component';

export const appRoutes: Routes = [
    { path: '', component: ProductsComponent },
    { path: 'home', component: ProductsComponent },
    { path: 'lists', component: ProductsComponent },
    { path: 'create', component: CreateComponent },
    { path: '**', redirectTo: 'home', pathMatch: 'full' },
];
