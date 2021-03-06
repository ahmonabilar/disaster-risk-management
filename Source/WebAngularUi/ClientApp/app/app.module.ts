import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ProductsComponent } from './product/products.component';

import { MenuComponent } from './shared/menu.component';

import { ProductList } from './product/productList.component';

import { DataService } from './services/dataService';
import { LoginService } from './login/login.service';

import { RouterModule } from '@angular/router';

let routes = [
    { path: '', component: HomeComponent },
    { path: "home", component: HomeComponent },
    { path: "products", component: ProductsComponent },
    { path: "login", component: LoginComponent }
];

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        LoginComponent,
        MenuComponent,
        ProductsComponent,
        ProductList
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot(routes, {
            useHash: false,
            enableTracing: false //for debugging
        })
    ],
    providers: [
        DataService,
        LoginService
    ],
    bootstrap: [
        AppComponent
    ]
})

export class AppModule { }
