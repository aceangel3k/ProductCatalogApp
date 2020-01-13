import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ProductsComponent } from './products/products.component';
import { NavComponent } from './nav/nav.component';
import { CreateComponent } from './create/create.component';
import { AlertifyService } from './_services/alertify.service';
import { ProductService } from './_services/product.service';
import { appRoutes } from './routes';
import { ProductCardComponent } from './product-card/product-card.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';


@NgModule({
   declarations: [
      AppComponent,
      ProductsComponent,
      NavComponent,
      CreateComponent,
      ProductCardComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
      AlertifyService,
      ProductService,
      ErrorInterceptorProvider
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
