import { NgModule } from '@angular/core';
import { SharedModule } from '../shared.module';

import { OrderRoutingModule } from './order-routing.module';
import { OrderComponent } from './order.component';
import { OrderService } from './order.service';
import { OrderResolve } from './order.resolve';
import { UserService } from '../user/user.service';
import { UserDropdownListResolve } from '../user/user-dropdown-list.resolve';

@NgModule({
    imports: [
        SharedModule,
        OrderRoutingModule
    ],
    declarations: [
        OrderComponent
    ],
    providers: [
        OrderService,
        UserService,
        OrderResolve,
        UserDropdownListResolve
    ]
})
export class OrderModule { }