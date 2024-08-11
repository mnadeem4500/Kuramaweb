import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Categoryitem } from 'src/app/admin/_models/category-item-dto';
import { AdminCategoryService } from 'src/app/admin/_services/admin-category.service';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';

export interface AdminCategoryModelData {
  category: Categoryitem | null,
  mode: 'New' | 'Edit' | 'Delete' | 'View'
}

@Component({
  selector: 'app-admin-category-item',
  templateUrl: './admin-category-item.component.html',
  styleUrl: './admin-category-item.component.scss'
})
export class AdminCategoryItemComponent implements OnInit {
  
  categoryForm: FormGroup;
  parentList:any;
  base64:string|null=null;
  byteArray: any;
  uploadedImages: any[] = [];
  
 

  constructor(private categoryser: AdminCategoryService, private fb: FormBuilder, private dialogRef: MatDialogRef<AdminCategoryItemComponent>, private dialog: MatDialog, @Inject(MAT_DIALOG_DATA) public data: AdminCategoryModelData,) {


    this.categoryForm = this.fb.group({
      id: [0],
      name: [,[Validators.required]],
      parentId: [0, [Validators.required]],
      icon: [null,[Validators.required]],
      maxAllowedImages: [0, [Validators.required]],
      postValidity: [0, [Validators.required]]
    });


    console.log(this.data);

    if (this.data) {
      this.categoryForm.controls['id'].setValue(this.data.category?.id);
      this.categoryForm.controls['name'].setValue(this.data.category?.name);
      this.categoryForm.controls['parentId'].setValue(this.data.category?.parentId);
       this.categoryForm.controls['icon'].setValue(this.data.category?.icon);
      this.categoryForm.controls['maxAllowedImages'].setValue(this.data.category?.maxAllowedImages);
      this.categoryForm.controls['postValidity'].setValue(this.data.category?.postValidity);
    }
    if (this.data.mode == 'Delete')
      this.categoryForm.disable();
    if (this.data.mode == 'View')
      this.categoryForm.disable();
    this.getParentList();
  }
  

  ngOnInit(): void {
    this.categoryForm.patchValue(this.data)
  }

  fileChange(event:any){

    let targetEvent=event.target ;
    let file:File=targetEvent.files[0];
    let fileReader:FileReader=new FileReader();
    fileReader.onload=(e)=>{
      this.base64=fileReader.result as string;
      this.categoryForm.controls["icon"].setValue(this.base64);
      console.log(this.base64)
    }
    fileReader.readAsDataURL(file)
   console.log(event)
   // console.log(this.byteArray);
  }  

  textboxChange(event:any){
    console.log(event)
  }


  getParentList() {
    this.categoryser.getRootCategories().subscribe(result => {
      this.parentList = result;
    })
  }

  getData() {
    console.log(this.categoryForm.value);
  }
  save() {
    if (this.categoryForm.invalid) {
      alert('Invalid form, please fill al required fields.')
      return;
      this.categoryForm.controls['name'].touched
    }
    let DataForm: Categoryitem = this.categoryForm.value;
    this.categoryser.createCategory(DataForm).subscribe(res => {
      if (res.success) {
        this.dialogRef.close(true);
      }
    }, err => { })

  }

  update() {
    let Updatedata: Categoryitem = this.categoryForm.value;
    this.categoryser.updateCategory(Updatedata).subscribe(res => {
      if (res.success) {
        this.dialogRef.close(true);
      }
    }, err => { });
  }
  delete(id: number) {
    this.categoryser.deleteCategories(id).subscribe(res => {
      if (res.success) {
        this.dialogRef.close(true);
      }
    }, error => { });
  }

}


