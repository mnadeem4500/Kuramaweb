import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseHttpService } from 'src/app/@shared/_services/base-http.service';
import { Categoryitem } from '../_models/category-item-dto';


@Injectable({
  providedIn: 'root'
})
export class AdminCategoryService extends BaseHttpService {

 constructor(http: HttpClient) {
   super(http)
   }
   getAllCatagorye() {
    return this.Get('Category/GetAll');
  }
  createCategory(datacategory:Categoryitem){
    return this.Post('Category/Create',datacategory)
  }
  getById(id:number){
    return this.Get('Category/GetById/'+id)
  }  
  
  updateCategory(datacategory:Categoryitem){
    return this.Put('Category/Update',datacategory)
  }  
  getRootCategories(){
    return this.Get('Category/GetRootCatgories')
  }
  deleteCategories(id:number){
    return this.Post('Category/Delete',{"id": id})
  } 
   

}
