import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { CreateListingDto } from 'src/app/admin/_models/listing-dto';
import { AdminListingService } from 'src/app/admin/_services/admin-listing.service';

export interface ListingModelData{
  listing:CreateListingDto|null;
  mode:'New'|'Edit'|'Delete'|'View'

}
@Component({
  selector: 'app-listing-admin-item',
  templateUrl: './listing-admin-item.component.html',
  styleUrl: './listing-admin-item.component.scss'
})
export class ListingAdminItemComponent {
listingForm:FormGroup;
rootCategories: any;

constructor(private listingser: AdminListingService,private dialogRef: MatDialogRef<ListingAdminItemComponent>,private fb :FormBuilder,private dialog: MatDialog,@Inject(MAT_DIALOG_DATA) public data:ListingModelData,){
this.listingForm=this.fb.group({
  id:[0],
  sku: [],
  title: [],
  shortDescription: [],
  longDescription: [],
  thumbImage: [],
  price: [0],
  isPriceNegotiable: [],
  categoryId: [0]
});
console.log(data);
}
saveListing(){
  let datalisting:CreateListingDto=this.listingForm.value;
  this.listingser.createListing(datalisting).subscribe(res=>{
    // if (res.success) {
    //   this.dialogRef.close(true);
    // }
  }, err => { });
  }
}

