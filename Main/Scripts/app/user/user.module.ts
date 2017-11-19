import { NgModule } from '@angular/core';
import { SharedModule } from '../shared.module';

import { UserRoutingModule } from './user-routing.module';
import { UserComponent } from './user.component';
import { UserService } from './user.service';
import { UserResolve } from './user.resolve';

@NgModule({
    imports: [
        SharedModule,
        UserRoutingModule
    ],
    declarations: [
        UserComponent
    ],
    providers: [
        UserService,
        UserResolve
    ]
})
export class UserModule { }