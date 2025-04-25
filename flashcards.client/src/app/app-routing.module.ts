import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';
import { LoginComponent } from './components/web-admin/login/login.component';
import { WebAdminComponent } from './components/web-admin/web-admin.component';
import { FlashcardComponent } from './components/flashcard/flashcard.component';

const routes: Routes = [
  { path: '', component: FlashcardComponent },
  { path: 'login', component: LoginComponent },
  { path: 'webadmin', component: WebAdminComponent, canActivate: [AuthGuard], data: { roles: ['Admin'] } },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
