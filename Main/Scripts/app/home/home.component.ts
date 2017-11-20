import { Component } from '@angular/core';

@Component({
    template: `
        <h1>Adam Hipp's Assessment</h1>
        <ul class="list-group">
            <li class="list-group-item">
                <a [routerLink]="['/user/new']">Create new user</a>
            </li>
            <li class="list-group-item">
                <a [routerLink]="['/order/new']">Create new order</a>
            </li>
            <li class="list-group-item">
                <a [routerLink]="['/user-orders']">View/Edit orders</a>
            </li>
        </ul>
    `
})
export class HomeComponent { }