import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { Categoryitem } from 'src/app/admin/_models/category-item-dto';
import { AdminCategoryService } from 'src/app/admin/_services/admin-category.service';
import { AddListingManagmentComponent } from '../add-listing-managment/add-listing-managment.component';

@Component({
  selector: 'app-add-listing-step3',
  templateUrl: './add-listing-step3.component.html',
  styleUrl: './add-listing-step3.component.scss'
})
export class AddListingStep3Component {
dataitem: Categoryitem[]=[];
  subcategoryfilterdata: any[] = [];
  currentSelectedCat=-1;
  previousSelectedCat=0;
constructor(private route:ActivatedRoute,private categoryser:AdminCategoryService,private router:Router,private dialogRef: MatDialog){

}
ngOnInit(){
  const id =this.route.snapshot.paramMap.get('id');
  this.categoryser.getAllCatagorye().subscribe(res=>{
    this.dataitem=res;
  })
}
btnNext(){

  this.router.navigate(['/manage/add-listing-step3'])
  this.previousSelectedCat=this.currentSelectedCat;
}
previous(){
  this.router.navigate(['/manage/add-listing-step2', this.previousSelectedCat])

}
//   openCategoryListing(){
//     this.dialogRef.open(AddListingManagmentComponent, {
//       width: '50%',
//       disableClose: true,
//   })
// }

}

