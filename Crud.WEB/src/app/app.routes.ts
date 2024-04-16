import { Routes } from '@angular/router';
import { AccountModule } from './modules/account/account.module';

export const routes: Routes = [
  AccountModule,
  {
    path: '**',
    redirectTo: 'login',
    pathMatch: 'full'
  }
];
