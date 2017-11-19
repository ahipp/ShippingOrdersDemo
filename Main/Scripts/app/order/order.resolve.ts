import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Rx';
import { OrderService } from './order.service';

@Injectable()
export class OrderResolve implements Resolve<any> {
    constructor(
        private orderService: OrderService
    ) { }

    resolve(route: ActivatedRouteSnapshot): Observable<any> {
        this.orderService.orderID = route.params.id;
        return this.orderService.getById();
    }
}
