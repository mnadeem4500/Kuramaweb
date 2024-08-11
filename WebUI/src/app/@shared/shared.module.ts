import { MainNavbarComponent } from './components/main-navbar/main-navbar.component';
import { RouterModule } from '@angular/router';
import { MainFooterComponent } from './components/main-footer/main-footer.component';
import { VImageSliderComponent } from './components/v-image-slider/v-image-slider.component';
// import { GalleryModule } from "@ngx-gallery/core";
import { AllNgMaterialModule } from '../all-ng-material';
import { ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';




@NgModule({
  declarations: [
    MainNavbarComponent,
    MainFooterComponent,
    VImageSliderComponent
  ],
  imports: [
    RouterModule,
    AllNgMaterialModule,
  ],
  exports: [
    MainNavbarComponent, MainFooterComponent, VImageSliderComponent, AllNgMaterialModule,
    ReactiveFormsModule,

  ]
})
export class SharedModule { }
