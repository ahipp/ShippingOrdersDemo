import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'my-app',
  template: `
    <nav class="navbar navbar-default">
        <div class="container-fluid">
            <div class="navbar-header">
                <a class="navbar-brand" [routerLink]="['/home']">Adam Hipp's Assessment</a>
            </div>
            <ul class="nav navbar-nav">
                <li><a [routerLink]="['/user/new']">Create new user</a></li>
                <li><a [routerLink]="['/order/new']">Create new order</a></li>
                <li><a [routerLink]="['/user-orders']">View/Edit Orders</a></li>
            </ul>
        </div>
    </nav>
    <router-outlet></router-outlet>
  ` }) 
export class AppComponent { }
