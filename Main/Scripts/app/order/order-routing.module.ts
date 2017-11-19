import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { OrderComponent } from './order.component';
import { OrderResolve } from './order.resolve';
import { UserDropdownListResolve } from '../user/user-dropdown-list.resolve';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [
                    {
                        path: 'new',
                        component: OrderComponent,
                        resolve: { userDropdownList: UserDropdownListResolve }
                    },
                    {
                        path: ':id',
                        component: OrderComponent,
                        resolve: { order: OrderResolve, userDropdownList: UserDropdownListResolve }
                    }
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class OrderRoutingModule { }