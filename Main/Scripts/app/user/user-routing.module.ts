import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { UserComponent } from './user.component';
import { UserResolve } from './user.resolve';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [
                    {
                        path: 'new',
                        component: UserComponent
                    },
                    {
                        path: ':id',
                        component: UserComponent,
                        resolve: { user: UserResolve }
                    }
                ]
            } 
        ])
    ],
    exports: [ RouterModule ]
})
export class UserRoutingModule { }