import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'my-app',
  template: 'My First Angular App - Demo' }) 
export class AppComponent implements OnInit { 
    ngOnInit() { console.log('AppInit!'); }
}