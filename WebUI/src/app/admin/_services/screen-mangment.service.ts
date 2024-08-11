import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseHttpService } from 'src/app/@shared/_services/base-http.service';
import { ScreenDto } from '../_models/screen-dto';


@Injectable({
  providedIn: 'root'
})
export class ScreenMangmentService extends BaseHttpService{

  constructor(http:HttpClient) 
  {
    super(http);
   }
getAllScreenControl(){
  return this.Get('PortalControls/GetAll')
}
createScreenControl(screendata:ScreenDto){
  return this.Post('PortalControls/Create',screendata)
}
updateScreenControl(screendata:ScreenDto){
  return this.Post('PortalControls/Update',screendata)

}
}
