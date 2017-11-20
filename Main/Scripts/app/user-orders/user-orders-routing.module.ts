import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { UserOrdersComponent } from './user-orders.component';
import { UserDropdownListResolve } from '../user/user-dropdown-list.resolve';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: UserOrdersComponent,
                resolve: { userDropdownList: UserDropdownListResolve }
            }
        ])
    ],
    exports: [RouterModule]
})
export class UserOrdersRoutingModule { }