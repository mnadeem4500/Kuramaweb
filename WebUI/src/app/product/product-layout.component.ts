import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-layout',
  template: `
      <app-main-navbar></app-main-navbar>
    <router-outlet></router-outlet>
    <app-main-footer></app-main-footer>
  `,
  styles: [``]
})
export class ProductLayoutComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
