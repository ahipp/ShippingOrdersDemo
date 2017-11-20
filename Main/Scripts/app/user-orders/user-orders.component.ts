import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

import { User } from '../models/user.model';
import { OrderSelection } from '../models/order-selection.model';
import { DropdownItem } from '../models/dropdown-item.model';
import { OrderService } from '../order/order.service';

@Component({
    templateUrl: 'Scripts/app/user-orders/user-orders.component.html'
})
export class UserOrdersComponent implements OnInit {

    userID: number;
    userDropdownList: DropdownItem[] = [];
    orders: OrderSelection[] = [];

    constructor(private route: ActivatedRoute, private orderService: OrderService) { }

    ngOnInit() {
        this.userDropdownList = this.route.snapshot.data['userDropdownList'];
    }

    onUserChange() {
        this.orderService.getListByUserId(this.userID).subscribe(orders => {
            this.orders = orders;
        });
    }

}