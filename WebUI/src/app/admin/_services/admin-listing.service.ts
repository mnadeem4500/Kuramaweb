import { HttpClient, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
//import { url } from 'inspector';
import { BaseHttpService } from 'src/app/@shared/_services/base-http.service';
import { CreateListingDto } from '../_models/listing-dto';


@Injectable({
  providedIn: 'root'
})
export class AdminListingService extends BaseHttpService {
  [x: string]: any;

  myHttp:HttpClient;
  constructor(http: HttpClient) {
    super(http)
    this.myHttp=http;
  }
  getAllListing() {
    return this.Get('Listing/GetAll');
  }
  createListing(data: any) {

    return this.myHttp.post(`${this.apiUrl}Listing/Create`, data, {
      headers: {
        // 'Content-Type': "multipart/form-data"
      },
      reportProgress: true
    }
    )
  }


}
