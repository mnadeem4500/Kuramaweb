import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataItem } from '@progress/kendo-angular-grid';
import { Categoryitem } from 'src/app/admin/_models/category-item-dto';
import { AdminCategoryService } from 'src/app/admin/_services/admin-category.service';

@Component({
  selector: 'app-add-listing-step2',
  templateUrl: './add-listing-step2.component.html',
  styleUrl: './add-listing-step2.component.scss'
})
export class AddListingStep2Component {
  dataitem: Categoryitem[] = [];
  lastcategory:Categoryitem[] = [];
  filteredCategories: any[] = [];
  subcategoryfilterdata: any[] = [];
  parentId: any;
  selectedId:any;
  constructor(private route: ActivatedRoute, private categoryser: AdminCategoryService, private router: Router) {
    this.loadAllCategories();
    this.route.params.subscribe(p => {
      this.parentId = p["id"];
      this.filterCategories()
    });

  }
  ngOnInit() {
  }
  loadAllCategories() {
    this.categoryser.getAllCatagorye().subscribe(res => {
      this.dataitem = res;
      this.filterCategories();
      console.log(this.lastcategory)
    },
    )
  }

  filterCategories() {
    this.filteredCategories = this.dataitem.filter(subcategory => subcategory.parentId.toString() == this.parentId)
  }
  subcategoryselect(item: Categoryitem) {
    let hasSubcategories = this.dataitem.filter(x => x.parentId == item.id)
    if (hasSubcategories.length > 0) {
     this.router.navigate(['/manage/add-listing-step1', item.id])
    }
    else{
      this.router.navigate(['/manage/add-listing-step4', item.id])
    }
     this.selectedId=item.id;
    }
    
  previous() {
    this.router.navigate(['/manage/add-listing-step1'])
      // this.router.navigate(['/manage/add-listing-step1',this.selectedId])
    
  }
 
  // next(){
  //   this.router.navigate(['/manage/add-listing-step4',this.selectedId])
  // }
  }




