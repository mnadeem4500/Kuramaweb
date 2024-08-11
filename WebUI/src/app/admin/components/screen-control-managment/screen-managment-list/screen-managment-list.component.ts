import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ScreenDto } from 'src/app/admin/_models/screen-dto';
import { ScreenMangmentService } from 'src/app/admin/_services/screen-mangment.service';
import { ScreenManagmentItemComponent, ScreenModelDto } from '../screen-managment-item/screen-managment-item.component';

@Component({
  selector: 'app-screen-managment-list',
  templateUrl: './screen-managment-list.component.html',
  styleUrl: './screen-managment-list.component.scss'
})
export class ScreenManagmentListComponent {
  screenControllist:ScreenDto[]=[];
  constructor(private screencontrolser:ScreenMangmentService ,private dialogRef:MatDialog ) {
  }

  ngOnInit(){
this.loadscreenlist();
  }
  loadscreenlist(){
    this.screencontrolser.getAllScreenControl().subscribe(res=>{
      this.screenControllist=res;
      console.log(this.screenControllist);
    },err => { console.log(err) });
  }
  openScreenDialoge(){
 let myData: ScreenModelDto={screen:null,mode:'New'}
 this.dialogRef.open(ScreenManagmentItemComponent,{
  width: '50%',
  disableClose: true,
  data: myData
}).afterClosed().subscribe(res => {
  if (res) {
    this.loadscreenlist();
  }
})
}
openScreenEdit(){
  let myData:ScreenModelDto={screen:null,mode:'Edit'}
  this.dialogRef.open(ScreenManagmentItemComponent,{
    width:'50%',
    disableClose:true,
    data:myData
  }).afterClosed().subscribe(res=>{
    if(res){
      this.loadscreenlist();
    }
  })
}
}
