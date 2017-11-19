import { Component } from '@angular/core';

@Component({
    template: `
        <h1>Welcome to the homepage</h1>
        <a [routerLink]="['/user/new']">Create new user</a>
    `
})
export class HomeComponent {

}