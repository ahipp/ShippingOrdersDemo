import { NgModule } from '@angular/core';
import { SharedModule } from '../shared.module';

import { UserOrdersRoutingModule } from './user-orders-routing.module';
import { UserOrdersComponent } from './user-orders.component';
import { OrderService } from '../order/order.service';
import { UserService } from '../user/user.service';
import { UserDropdownListResolve } from '../user/user-dropdown-list.resolve';

@NgModule({
    imports: [
        SharedModule,
        UserOrdersRoutingModule
    ],
    declarations: [
        UserOrdersComponent
    ],
    providers: [
        OrderService,
        UserService,
        UserDropdownListResolve
    ]
})
export class UserOrdersModule { }