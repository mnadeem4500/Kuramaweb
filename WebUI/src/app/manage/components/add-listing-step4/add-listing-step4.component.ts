import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Categoryitem } from 'src/app/admin/_models/category-item-dto';
import { CreateListingDto } from 'src/app/admin/_models/listing-dto';
import { AdminCategoryService } from 'src/app/admin/_services/admin-category.service';
import { AdminListingService } from 'src/app/admin/_services/admin-listing.service';
import { AddListingStep2Component } from '../add-listing-step2/add-listing-step2.component';
import { ActivatedRoute } from '@angular/router';
export interface ListingModelData {
  listing: CreateListingDto | null;
  // mode:'New'|'Edit'|'Delete'|'View'
}

@Component({
  selector: 'app-add-listing-step4',
  templateUrl: './add-listing-step4.component.html',
  styleUrl: './add-listing-step4.component.scss'
})
export class AddListingStep4Component {
  listingForm: FormGroup;
  parentList: Categoryitem[] = [];
  base64: string | null = null;
  categoryForm: any;
  subcategoryId: any;
  uploadedFiles: File[] = [];

  constructor(private listingser: AdminListingService, private fb: FormBuilder, private categoryser: AdminCategoryService, private route: ActivatedRoute) {
    this.listingForm = this.fb.group({
      id: [0],
      sku: [],
      title: [],
      shortDescription: [],
      longDescription: [],
      thumbImage: [],
      price: [0],
      isPriceNegotiable: [true],
      categoryId: [0]
    });

    this.getselectedCategory();
  }
  ngOnInit() {
    this.subcategoryId = this.route.snapshot.paramMap.get('id')
    console.log(this.subcategoryId);
    this.listingForm.controls["categoryId"].setValue(this.subcategoryId);
  }
  saveListing() {
    let datalisting: CreateListingDto = this.listingForm.value;
    var formData: FormData = new FormData();
    this.uploadedFiles.forEach(f => {
      formData.append(f.name, f)
    });
   // formData.append("ListingData", JSON.stringify( datalisting))
    this.listingser.createListing(formData).subscribe(res => { });
  }
  // save all an
  getselectedCategory() {
    this.categoryser.getRootCategories().subscribe(result => {
      this.parentList = result;
      console.log(this.parentList);
    })
  }
  fileChange(event: any) {
    let targetEvent = event.target;
    let filesList =(targetEvent.files as FileList);
    for (let index = 0; index < filesList.length; index++) {
      const element = filesList[index];
      this.uploadedFiles.push(element)
    }
    // let fileReader: FileReader = new FileReader();
    // fileReader.onload = (e) => {
    //   this.base64 = fileReader.result as string;
    //   this.listingForm.controls["thumbImage"].setValue(this.base64);
    //   console.log(this.base64)
    // }
    // if (file) {
    //   fileReader.readAsDataURL(file)
    // }
    // console.log(event)
  }
}

