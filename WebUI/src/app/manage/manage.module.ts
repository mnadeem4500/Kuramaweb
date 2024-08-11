import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { MyListingComponent } from './components/my-products/my-products.component';
import { ProfileComponent } from './components/profile/profile.component';

import { ManageLayoutComponent } from './manage-layout.component';
import { SharedModule } from '../@shared/shared.module';
import { RouterModule, Routes } from '@angular/router';
import { AddListingStep1Component } from './components/add-listing-step1/add-listing-step1.component';
import { FeedbacksComponent } from './feedbacks/feedbacks.component';
import { MassagesComponent } from './massages/massages.component';
import { AddListingStep2Component } from './components/add-listing-step2/add-listing-step2.component';
import { AddListingStep3Component } from './components/add-listing-step3/add-listing-step3.component';
import { AddListingStep4Component } from './components/add-listing-step4/add-listing-step4.component';
import { AddListingManagmentComponent } from './components/add-listing-managment/add-listing-managment.component';
import { BootstrapexampleComponent } from './components/bootstrapexample/bootstrapexample.component';

const routes: Routes = [
  { path: 'mylisting', component: MyListingComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'add-listing-step1', component: AddListingStep1Component },
  { path: 'add-listing-step1/:id', component: AddListingStep2Component },
  { path: 'add-listing-step2/:id', component: AddListingStep3Component },
  { path: 'add-listing-step4/:id', component: AddListingStep4Component },
  { path: 'add-listing-managment', component: AddListingManagmentComponent },
  { path: 'feedbacks', component: FeedbacksComponent },
  { path: 'messages', component: MassagesComponent },
  { path: 'bootstrap',component:BootstrapexampleComponent},
  { path: "**", redirectTo: "mylisting" }
]

@NgModule({
  declarations: [
    ManageLayoutComponent,
    DashboardComponent,
    MyListingComponent,
    AddListingStep1Component,
    ProfileComponent,
    FeedbacksComponent,
    MassagesComponent,
    AddListingStep2Component,
    AddListingStep3Component,
    AddListingStep4Component,
    AddListingManagmentComponent,
    BootstrapexampleComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SharedModule
  ]
})
export class ManageModule { }
