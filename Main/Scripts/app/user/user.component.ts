import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

import { User } from '../models/user.model';
import { UserService } from './user.service';

@Component({
    templateUrl: 'Scripts/app/user/user.component.html'
})
export class UserComponent implements OnInit {

    user: User
    newUser = false;
    submitted = false;
    processing = false;
    notification = '';
    @ViewChild('userForm') form: FormControl;

    constructor(private route: ActivatedRoute, private userService: UserService) { }

    ngOnInit() {
        this.user = this.route.snapshot.data['user'];
        if (!this.user) {
            this.user = new User();
            this.newUser = true;
        }
    }

    onSubmit() {
        this.submitted = true;
        if (this.form.valid) {
            this.processing = true;

            if (this.newUser) this.userService.create(this.user).subscribe(
                response => {
                    this.submitted = false;
                    this.user = new User();
                    this.notification = 'User ' + response.FirstName + ' ' + response.LastName + ' created.';
                },
                error => this.notification = 'Error creating user',
                () => this.processing = false
            );

            else this.userService.edit(this.user).subscribe(
                response => {
                    this.submitted = false;
                    this.user = response,
                    this.notification = 'User ' + response.FirstName + ' ' + response.LastName + ' updated.'
                },
                error => this.notification = 'Error submitting data',
                () => this.processing = false
            );
        }
    }
}