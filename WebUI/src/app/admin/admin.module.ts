import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { FeedbackComponent } from './components/feedback/feedback.component';
// import { CatalogueListComponent } from './components/listing/listing.component';
import { UserComponent } from './components/user/user.component';
import { SharedModule } from '../@shared/shared.module';
import { AllNgMaterialModule } from '../all-ng-material';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ListingAdminComponent } from './components/listing-managment/listing-admin/listing-admin.component';
import { AdminCategoryListComponent } from './components/category-managment/admin-category-list/admin-category-list.component';
import { AdminCategoryItemComponent } from './components/category-managment/admin-category-item/admin-category-item.component';
import { MatDialogModule } from '@angular/material/dialog';
import { AdminCatalogueItemComponent } from './components/catalogue-managment/admin-catalogue-item/admin-catalogue-item.component';
import { AdminCatalogueListComponent } from './components/catalogue-managment/admin-catalogue-list/admin-catalogue-list.component';
import { MatRadioButton, MatRadioGroup, MatRadioModule } from '@angular/material/radio';
import { AllKendoModule } from '../all-kendo.module';
import { ScreenManagmentItemComponent } from './components/screen-control-managment/screen-managment-item/screen-managment-item.component';
import { ScreenManagmentListComponent } from './components/screen-control-managment/screen-managment-list/screen-managment-list.component';
import { AdminCategoryListingComponent } from './components/category-managment/admin-category-listing/admin-category-listing.component';
import { MatMenuModule } from '@angular/material/menu';
import { ListingAdminItemComponent } from './components/listing-managment/listing-admin-item/listing-admin-item.component';







const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'listing-admin', component: ListingAdminComponent },
  { path: 'feedback', component: FeedbackComponent },
  { path: 'user', component: UserComponent },
  { path: 'category-item', component: AdminCategoryItemComponent },
  { path: 'category-list', component: AdminCategoryListComponent },
  { path: 'catalogue-item', component: AdminCatalogueItemComponent },
  { path: 'catalogue-list', component: AdminCatalogueListComponent },
  {path: 'screen-item', component:ScreenManagmentItemComponent},
  {path:'screen-list',component:ScreenManagmentListComponent},
  {path:'category-listing',component:AdminCategoryListingComponent},
  {path:'listing-item',component:ListingAdminItemComponent},
  { path: "**", component: DashboardComponent }


]



@NgModule({
  declarations: [
    AdminLayoutComponent,
    DashboardComponent,
    ListingAdminComponent,
    FeedbackComponent,
    UserComponent,
    AdminCategoryItemComponent,
    AdminCategoryListComponent,
    AdminCatalogueListComponent,
    AdminCatalogueItemComponent,
    ScreenManagmentItemComponent,
    ScreenManagmentListComponent,
    AdminCategoryListingComponent,
    ListingAdminItemComponent,
  ],
  imports: [
    ReactiveFormsModule,
    CommonModule,
    SharedModule,
    AllNgMaterialModule,
    FormsModule,
    RouterModule.forChild(routes),
    MatDialogModule,
    MatRadioButton,
    MatRadioGroup,
    MatRadioModule,
    AllKendoModule,
    MatMenuModule,
  ]
})
export class AdminModule { }
