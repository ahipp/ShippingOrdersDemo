import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';

@NgModule({
    imports: [
        RouterModule.forRoot([
            {
                path: 'user',
                loadChildren: 'app/app/user/user.module#UserModule'
            },
            {
                path: 'order',
                loadChildren: 'app/app/order/order.module#OrderModule'
            },
            {
                path: 'user-orders',
                loadChildren: 'app/app/user-orders/user-orders.module#UserOrdersModule'
            },
            {
                path: 'home',
                component: HomeComponent
            },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }