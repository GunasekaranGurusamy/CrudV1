import { Route } from '@angular/router';
export const AccountModule: Route = {
  path: 'login',
  children: [
    {
      path: '',
      loadComponent:()=> import('./login/login.component').then(m => m.LoginComponent),
      data: { Title: 'Login' }
    },
    {
      path: 'add-user',
      loadComponent: () => import('./register/register.component').then(m => m.RegisterComponent),
      data: { Title: 'Register' }
    }
  ]
}
