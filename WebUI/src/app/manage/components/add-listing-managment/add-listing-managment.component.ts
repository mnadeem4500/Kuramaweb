import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { CreateListingDto } from 'src/app/admin/_models/listing-dto';
import { AdminCategoryService } from 'src/app/admin/_services/admin-category.service';
import { AdminListingService } from 'src/app/admin/_services/admin-listing.service';
export interface ListingModelData{
  listing:CreateListingDto|null;
  // mode:'New'|'Edit'|'Delete'|'View'
}

@Component({
  selector: 'app-add-listing-managment',
  templateUrl: './add-listing-managment.component.html',
  styleUrl: './add-listing-managment.component.scss'
})
export class AddListingManagmentComponent {
  listingForm:FormGroup;
  rootCategories: any;
  parentList:any;
  
constructor(private listingser: AdminListingService,private dialogRef: MatDialogRef<AddListingManagmentComponent>,private fb :FormBuilder,private dialog: MatDialog,@Inject(MAT_DIALOG_DATA) public data:ListingModelData,private categoryser: AdminCategoryService){
  this.listingForm=this.fb.group({
    id:[0],
    sku: [],
    title: [],
    shortDescription: [],
    longDescription: [],
    thumbImage: [],
    price: [0],
    isPriceNegotiable: [true],
    categoryId: [0]
  });
  console.log(data);
    this.getselectedCategory();
  }

  saveListing(){
    let datalisting:CreateListingDto=this.listingForm.value;
    this.listingser.createListing(datalisting).subscribe(res=>{
      // if (res.success) {
      //   this.dialogRef.close(true);
      // }
    }, err => { });
    }
    getselectedCategory() {
      this.categoryser.getRootCategories().subscribe(result => {
        this.parentList = result;
        console.log(this.parentList);
      })
    }
  }
  

