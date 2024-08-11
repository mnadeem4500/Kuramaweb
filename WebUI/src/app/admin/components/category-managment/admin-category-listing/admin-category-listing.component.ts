import { Component } from '@angular/core';
import { Categoryitem, CategoryitemWithSub, subcategory } from 'src/app/admin/_models/category-item-dto';
import { AdminCategoryService } from 'src/app/admin/_services/admin-category.service';
import { ListingAdminItemComponent, ListingModelData } from '../../listing-managment/listing-admin-item/listing-admin-item.component';
import { MatDialog } from '@angular/material/dialog';
import { FormBuilder, FormGroup } from '@angular/forms';


@Component({
  selector: 'app-admin-category-listing',
  templateUrl: './admin-category-listing.component.html',
  styleUrl: './admin-category-listing.component.scss'
})
export class AdminCategoryListingComponent {

  currentCategoryList: CategoryitemWithSub[] = [];
  allCategories: Categoryitem[] = [];
  categoryForm: FormGroup;

  constructor(private categoryService: AdminCategoryService, private fb: FormBuilder, private dialogRef: MatDialog) {
    this.categoryForm = this.fb.group({
    })
  }
  ngOnInit() {
    this.categoryService.getAllCatagorye().subscribe(res => {
      this.allCategories = res;
      console.log(this.currentCategoryList);
    }, err => { console.log(err) })
  }

  onCategorySelect(event: any) {
  }

  openListingDialoge() {
    // let Listingdata:ListingModelData={listing:null,mode:'New'}
    this.dialogRef.open(ListingAdminItemComponent, {
      width: '50%',
      disableClose: true,
    }).afterClosed().subscribe((res: any) => {

    })
  }



}



