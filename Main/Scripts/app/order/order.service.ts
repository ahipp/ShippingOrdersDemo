import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs';
import { Order } from '../models/order.model';
import { DropdownItem } from '../models/dropdown-item.model';
import { OrderSelection } from '../models/order-selection.model';
import 'rxjs/add/operator/map';

@Injectable()
export class OrderService {
    orderID: number

    constructor(private http: Http) { }

    getById(): Observable<Order> {
        return this.http.get('order/getbyid/' + this.orderID).map(res => res.json());
    }

    create(order: Order): Observable<Order> {
        return this.http.post('order/create', order).map(res => res.json());
    }

    edit(order: Order): Observable<Order> {
        return this.http.post('order/edit/' + this.orderID, order).map(res => res.json());
    }

    getListByUserId(userID: number): Observable<OrderSelection[]> {
        return this.http.get('order/getlistbyuserid/' + userID).map(res => res.json());
    }
}