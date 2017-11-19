import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module'
import { HomeComponent } from './home/home.component';

@NgModule({
    imports: [
        BrowserModule,
        RouterModule,
        HttpModule,
        FormsModule,
        AppRoutingModule
    ],
    declarations: [ AppComponent, HomeComponent ],
    bootstrap: [AppComponent],
})
export class AppModule { }