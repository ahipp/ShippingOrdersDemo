import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

import { Order } from '../models/order.model';
import { DropdownItem } from '../models/dropdown-item.model';
import { OrderService } from './order.service';


@Component({
    templateUrl: 'Scripts/app/order/order.component.html'
})
export class OrderComponent implements OnInit {

    order: Order
    newOrder = false;
    submitted = false;
    processing = false;
    notification = '';
    userDropdownList: DropdownItem[] = [];
    @ViewChild('orderForm') form: FormControl;

    constructor(private route: ActivatedRoute, private orderService: OrderService) { }

    ngOnInit() {
        this.userDropdownList = this.route.snapshot.data['userDropdownList'];
        this.order = this.route.snapshot.data['order'];
        if (!this.order) {
            this.order = new Order();
            this.newOrder = true;
        }
    }

    onSubmit() {
        this.submitted = true;
        console.log(this.form);
        if (this.form.valid && this.form.value['userID']) {
            this.processing = true;

            if (this.newOrder) this.orderService.create(this.order).subscribe(
                response => {
                    this.submitted = false;
                    this.order = new Order();
                    this.notification = 'Order with trackingID ' + response.TrackingID + ' created.';
                },
                error => this.notification = 'Error creating order',
                () => this.processing = false
            );

            else this.orderService.edit(this.order).subscribe(
                response => {
                    this.submitted = false;
                    this.order = response;
                    this.notification = 'Order with trackingID  ' + response.TrackingID + ' updated.'
                },
                error => this.notification = 'Error submitting data',
                () => this.processing = false
            );
        }
    }
}
