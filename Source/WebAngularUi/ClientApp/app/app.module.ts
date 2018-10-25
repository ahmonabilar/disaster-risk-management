import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './component1/app.component';
import { ProductList } from './product/productList.component';
import { DataService } from './services/dataService';

@NgModule({
    declarations: [
        AppComponent,
        ProductList
    ],
    imports: [
        BrowserModule,
        HttpClientModule
    ],
    providers: [
        DataService
    ],
    bootstrap: [
        AppComponent
    ]
})

export class AppModule { }
