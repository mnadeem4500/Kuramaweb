import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ScreenDto } from 'src/app/admin/_models/screen-dto';
import { ScreenMangmentService } from 'src/app/admin/_services/screen-mangment.service';

export interface ScreenModelDto{
  screen:ScreenDto|null;
  mode: 'New' | 'Edit' | 'Delete' | 'View'

}

@Component({
  selector: 'app-screen-managment-item',
  templateUrl: './screen-managment-item.component.html',
  styleUrl: './screen-managment-item.component.scss'
})
export class ScreenManagmentItemComponent {
  screenForm: FormGroup;
  dialogRef: any;
  base64:any;
constructor(private fb:FormBuilder, @Inject(MAT_DIALOG_DATA) public data:ScreenModelDto,private screencontrolser:ScreenMangmentService){
this.screenForm=this.fb.group({
  id:[0],
  name:[],
});
console.log(this.data);
if(this.data){
  this.screenForm.controls['id'].setValue(this.data.screen?.id);
  this.screenForm.controls['name'].setValue(this.data.screen?.name);
}
}
ngOnInit(): void {
  this.screenForm.patchValue(this.data)
}
onInputChang(event:any){
  
    let targetEvent=event.target ;
    let file:File=targetEvent.files[0];
    let fileReader:FileReader=new FileReader();
    fileReader.onload=(e)=>{
      this.base64=fileReader.result;
    }
    fileReader.readAsDataURL(file)
    console.log(event)
  }

saveScreenControl(){
  let DataForm: ScreenDto=this.screenForm.value;
  this.screencontrolser.createScreenControl(DataForm).subscribe(res => {
    if (res.success) {
      this.dialogRef.close(true);
    }
  }, err => {})
}
updateScreenControl(){
  let Updatedata : ScreenDto=this.screenForm.value;
  this.screencontrolser.updateScreenControl(Updatedata).subscribe(res=>{
    if(res.success){
      this.dialogRef.close(true);
    }
  }, err=>{});

}
}
