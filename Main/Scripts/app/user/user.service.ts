import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';
import 'rxjs/add/operator/map';

@Injectable()
export class UserService {
    userID: number

    constructor(private http: Http) { }

    getById(id: number): Observable<User> {
        return this.http.get('user/getbyid/' + id).map(res => res.json());
    }

    create(user: User): Observable<User> {
        return this.http.post('user/create', user).map(res => res.json());
    }

    edit(user: User): Observable<User> {
        return this.http.post('user/edit', user).map(res => res.json());
    }
}