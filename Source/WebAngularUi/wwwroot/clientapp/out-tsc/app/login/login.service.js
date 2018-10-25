var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs/operators";
var LoginService = /** @class */ (function () {
    function LoginService(http) {
        this.http = http;
    }
    Object.defineProperty(LoginService.prototype, "loginRequired", {
        get: function () {
            var tokenInfo = JSON.parse(localStorage.getItem('tokenInfo'));
            return tokenInfo === null || tokenInfo.token.length == 0 || tokenInfo.tokenExpiration > new Date();
        },
        enumerable: true,
        configurable: true
    });
    LoginService.prototype.login = function (creds) {
        return this.http
            .post("http://localhost:8888/account/createtoken", creds)
            .pipe(map(function (data) {
            localStorage.setItem('tokenInfo', JSON.stringify({ token: data.token, tokenExpiration: data.expiration }));
            return true;
        }));
    };
    LoginService.prototype.logout = function () {
        localStorage.removeItem('tokenInfo');
    };
    LoginService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], LoginService);
    return LoginService;
}());
export { LoginService };
//# sourceMappingURL=login.service.js.map