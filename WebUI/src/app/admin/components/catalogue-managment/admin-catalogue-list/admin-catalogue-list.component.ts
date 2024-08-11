import { Component } from '@angular/core';
import { AdminCatalogueService } from 'src/app/admin/_services/admin-catalogue.service';
import { AdminCatalogueItemComponent,AdminCatalogueModelData} from '../admin-catalogue-item/admin-catalogue-item.component';
import { MatDialog, } from '@angular/material/dialog';
import { CatalogueMasterDto } from 'src/app/admin/_models/catalogue-dto';

@Component({
  selector: 'app-admin-catalogue-list',
  templateUrl: './admin-catalogue-list.component.html',
  styleUrl: './admin-catalogue-list.component.scss'
})
export class AdminCatalogueListComponent {

  cataloguelist:CatalogueMasterDto[]=[];
  constructor(private catalogueser:AdminCatalogueService,private dialogRef: MatDialog) {
    
  }
  ngOnInit(){
this.loadItems();
  }
loadItems(){
  this.catalogueser.getAllCatalogue().subscribe(res=>{
    this.cataloguelist=res;
    console.log(this.cataloguelist);
  },err => { console.log(err) });
}
  openDialog() {
    let mydata:AdminCatalogueModelData={ catalogue : null, mode: 'New' }
    this.dialogRef.open(AdminCatalogueItemComponent, {
      data: mydata,
      width: '50%',
      disableClose: true
    }).afterClosed().subscribe(res=>{
      if(res){
        this.loadItems();
      }
    });
  }
  openEditDialog(data:any) {
    let mydata:AdminCatalogueModelData={catalogue:data, mode:"Edit"}
    this.dialogRef.open(AdminCatalogueItemComponent, {
      data: mydata,
      width: '50%',
      disableClose: true
    }).afterClosed().subscribe(res=>{
      if(res){
        this.loadItems();
      }
    });
  }
  OpenDeleteDialog(data:any){
    let mydata:AdminCatalogueModelData={catalogue:data, mode:"Delete"}
    this.dialogRef.open(AdminCatalogueItemComponent,{
      data:mydata,
      width: '50%',
      disableClose: true
    }).afterClosed().subscribe(res=>{
      if(res){
        this.loadItems();
      }
    });
  }
  openViewDialog(data: any) {
    let myData: AdminCatalogueModelData = { catalogue: data, mode: 'View' }
    this.dialogRef.open(AdminCatalogueItemComponent, {
      data: myData,
      width: '50%',
      disableClose: true
     }).afterClosed().subscribe(res=>{
      if(res){
        this.loadItems();
      }
    }); 
}

}
