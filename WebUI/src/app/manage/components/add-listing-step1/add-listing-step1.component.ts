import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Categoryitem } from 'src/app/admin/_models/category-item-dto';
import { AdminCategoryService } from 'src/app/admin/_services/admin-category.service';
import { AllcategoryService } from 'src/app/admin/_services/allcategory.service';
import { AdminCategoryItemComponent, AdminCategoryModelData } from 'src/app/admin/components/category-managment/admin-category-item/admin-category-item.component';
import { AdminCategoryListComponent } from 'src/app/admin/components/category-managment/admin-category-list/admin-category-list.component';


@Component({
  selector: 'app-add-listing-step1',
  templateUrl: './add-listing-step1.component.html',
  styleUrls: ['./add-listing-step1.component.scss'],
  //providers:[AllcategoryService]
})
export class AddListingStep1Component {

  CopyallCategories: Categoryitem[] = [];
currentSelectedCat=-1;

  constructor(private categoryser: AdminCategoryService, private router: Router) {
  }
  ngOnInit() {
    this.loadAll();

  }
  loadAll() {
    this.categoryser.getRootCategories().subscribe(res => {
      this.CopyallCategories = res;
      console.log(this.CopyallCategories);
    }, err => { console.log(err) })
  }
  categoryselect(categorydata: any) {
    this.currentSelectedCat=categorydata.id;
  }

  btnNext(){
    if(this.currentSelectedCat==-1)
      {
        alert('Please select a category');
        return;
      }
    this.router.navigate(['/manage/add-listing-step1', this.currentSelectedCat])
  }

}

