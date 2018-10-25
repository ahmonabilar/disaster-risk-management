import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs/operators";

@Injectable()
export class DataService {

    constructor(private http: HttpClient) { }

    loadProducts() {
        return this.http.get("http://localhost:8888/api/test")
            .pipe(
            map((data: any[]) => {
                this.products = data;
                return true;
            }));
    }

    public products = [];
}