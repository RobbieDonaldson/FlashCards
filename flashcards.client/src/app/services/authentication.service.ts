import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    constructor(private http: HttpClient, private jwtHelper: JwtHelperService) { }

    /* login(credentials: any): Observable<any> {
        return this.http.post<any>('https://localhost:7158/api/webadmin/login', credentials, this.generateHeaders());
    } */

    login = (credentials: any) => {
        return this.http.post('https://localhost:7158/api/webadmin/login', credentials, this.generateHeaders());
    }
    

    saveToken(token: string): void {
        localStorage.setItem('token', token);
    }

    getToken(): string | null {
        return localStorage.getItem('token');
    }

    getRoles(): string[] | null {
        const token = localStorage.getItem('token');
        if (token && !this.jwtHelper.isTokenExpired(token)) {
            const decodedToken = this.jwtHelper.decodeToken(token);
            return decodedToken.roles || null;
        }
        return null;
    }

    removeToken(): void {
        localStorage.removeItem('token');
    }

    isLoggedIn(): boolean {
        return !!this.getToken();
    }

    private generateHeaders = () => {
        return {
          headers: new HttpHeaders({
            'Content-Type': 'application/json'
          })
        }
      }
}