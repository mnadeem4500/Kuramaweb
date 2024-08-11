import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseHttpService } from 'src/app/@shared/_services/base-http.service';
import { CatalogueMasterDto } from '../_models/catalogue-dto';

@Injectable({
  providedIn: 'root'
})
export class AdminCatalogueService extends BaseHttpService {

  constructor(http:HttpClient) {
    super(http);
   }
   getAllCatalogue() {
    return this.Get('Catalogue/GetAll');
    
  }
  createCatalogue(datacatalogue:CatalogueMasterDto){
    return this.Post('Catalogue/Create',datacatalogue)
  }
  updateCatalogue(datacatalogue:CatalogueMasterDto){
    return this.Post('Catalogue/Update',datacatalogue)
  }
  deleteCatalogue(masterId:any){
  return this.Post('Catalogue/Delete/'+masterId,null)
  } 

  
}
