import { Injectable } from '@angular/core';
import { Categoryitem } from '../_models/category-item-dto';

@Injectable({
  providedIn: 'root'
})
export class AllcategoryService {
 

  allCategories: Categoryitem[] = [];
  constructor() { }
  getdata(){
    return this.allCategories;
  }
}
