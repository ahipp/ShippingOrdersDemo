import { Component } from '@angular/core';

@Component({
    template: `
        <h1>Welcome to the homepage</h1>
        <div><a [routerLink]="['/user/new']">Create new user</a></div>
        <div><a [routerLink]="['/order/new']">Create new order</a></div>
    `
})
export class HomeComponent {

}