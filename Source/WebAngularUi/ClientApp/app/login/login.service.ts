import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";

@Injectable()
export class LoginService {
    constructor(private http: HttpClient) { }

    public get loginRequired(): boolean {
        let tokenInfo = JSON.parse(localStorage.getItem('tokenInfo'));

        return tokenInfo === null || tokenInfo.token.length == 0 || tokenInfo.tokenExpiration > new Date();
    }

    login(creds): Observable<boolean> {
        return this.http
            .post("http://localhost:8888/account/createtoken", creds)
            .pipe(
                map((data: any) => {
                    localStorage.setItem('tokenInfo', JSON.stringify({ token: data.token, tokenExpiration: data.expiration }));

                    return true;
                })
            );
    }

    logout() {
        localStorage.removeItem('tokenInfo');
    }
}