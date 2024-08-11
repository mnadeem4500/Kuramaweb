import { Component} from '@angular/core';
import { AdminCategoryService } from 'src/app/admin/_services/admin-category.service';
import { MatDialog } from '@angular/material/dialog';
import { AdminCategoryItemComponent, AdminCategoryModelData } from '../admin-category-item/admin-category-item.component';
import { Categoryitem } from 'src/app/admin/_models/category-item-dto';
import { AdminCategoryListingComponent } from '../admin-category-listing/admin-category-listing.component';




@Component({
  selector: 'app-admin-category-list',
  templateUrl: './admin-category-list.component.html',
  styleUrl: './admin-category-list.component.scss'
})
export class AdminCategoryListComponent {

  allCategories: Categoryitem[] = [];

  constructor(private categoryser: AdminCategoryService, private dialogRef: MatDialog) {
  }
  ngOnInit() {
    this.loadAll();
  }
  loadAll() {
    this.categoryser.getAllCatagorye().subscribe(res => {
      this.allCategories = res;
    }, err => { console.log(err) })
  }

  getParentName(parentId: any) {
    if (parentId == 0)
      return "Root";
    let parent = this.allCategories.find(x => x.id == parentId)
    if (parent) {
      return parent.name;
    }
    return
  }
  openDialog() {
    let myData: AdminCategoryModelData = { category: null, mode: 'New' }
    this.dialogRef.open(AdminCategoryItemComponent, {
      width: '50%',
      disableClose: true,
      data: myData
    }).afterClosed().subscribe(res => {
      if (res) {
        this.loadAll();
      }
    })
  }
  openEditDialog(data: any) {
    let myData: AdminCategoryModelData = { category: data, mode: 'Edit' }
    this.dialogRef.open(AdminCategoryItemComponent, {
      data: myData,
      width: '50%',
      disableClose: true,
    }).afterClosed().subscribe(res => {
      if (res) {
        this.loadAll();
      }
    })

  }
  openDeleteDialog(data: any) {
    let myData: AdminCategoryModelData = { category: data, mode: 'Delete' }
    this.dialogRef.open(AdminCategoryItemComponent, {
      data: myData,
      width: '50%',
      disableClose: true,
    }).afterClosed().subscribe(res => {
      if (res) {
        this.loadAll();
      }
    })
  }
  openViewDialog(data: any) {
    let myData: AdminCategoryModelData = { category: data, mode: 'View' }
    this.dialogRef.open(AdminCategoryItemComponent, {
      data: myData,
      width: '50%',
      disableClose: true,
    }).afterClosed().subscribe(res => {
      if (res) {
        this.loadAll();
      }
    })

  }
  openCategoryListing(){
    this.dialogRef.open(AdminCategoryListingComponent, {
      width: '50%',
      disableClose: true,
  })
}}
