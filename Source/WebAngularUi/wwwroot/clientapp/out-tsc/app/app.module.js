var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
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
var routes = [
    { path: '', component: HomeComponent },
    { path: "home", component: HomeComponent },
    { path: "products", component: ProductsComponent },
    { path: "login", component: LoginComponent }
];
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        NgModule({
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
    ], AppModule);
    return AppModule;
}());
export { AppModule };
//# sourceMappingURL=app.module.js.map