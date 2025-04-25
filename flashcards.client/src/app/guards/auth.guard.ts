import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from "@angular/router";
import { AuthService } from "../services/authentication.service";

@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate {
    constructor(private authService: AuthService, private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        if (this.authService.isLoggedIn()) {
            // Check if route requires specific roles
            const roles = route.data['roles'] as Array<string>;
            if (roles) {
                // Assuming you have a method to decode the token and get user roles
                const userRoles = this.authService.getRoles();
                if (!roles.some(role => userRoles?.includes(role))) {
                    this.router.navigate(['/unauthorized']);
                    return false;
                }
            }
            return true;
        } else {
            this.router.navigate(['/login']);
            return false;
        }
    }
}