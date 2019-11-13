import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('../app/views/map/map.module').then(m => m.MapModule)
  },
  {
    path: 'user',
    loadChildren: () => import('../app/views/user/user.module').then(m => m.UserModule)
  },
  {
    path: 'login',
    loadChildren: () => import('../app/views/login/login.module').then(m => m.LoginModule)
  },
  {
    path: '',
    redirectTo: '',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
