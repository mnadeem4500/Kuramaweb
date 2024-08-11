import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AdminCatalogueService } from 'src/app/admin/_services/admin-catalogue.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ApiResponseModel } from 'src/app/@shared/_models/api-response-model';
import { CatalogueMasterDto } from 'src/app/admin/_models/catalogue-dto';


export interface AdminCatalogueModelData {
  catalogue: CatalogueMasterDto | null;
  mode: 'New' | 'Edit' | 'Delete' | 'View'

}

@Component({
  selector: 'app-admin-catalogue-item',
  templateUrl: './admin-catalogue-item.component.html',
  styleUrl: './admin-catalogue-item.component.scss'
})
export class AdminCatalogueItemComponent {
  catalogueForm: FormGroup;
  constructor(private dialogRef: MatDialogRef<AdminCatalogueItemComponent>, private catalogueser: AdminCatalogueService, private fb: FormBuilder, private _snackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public editdata: any, @Inject(MAT_DIALOG_DATA) public data: AdminCatalogueModelData,) {

    this.catalogueForm = this.fb.group({
      masterId: [],
      catalogueName: [, Validators.required],
      description: [, Validators.required],
      catalogueDetails: this.fb.array([])
    });
    if (this.data.mode != 'New') {
      this.catalogueForm.controls['catalogueName'].setValue(this.data.catalogue?.catalogueName);
      this.catalogueForm.controls['description'].setValue(this.data.catalogue?.description);
      this.catalogueForm.controls['masterId'].setValue(this.data.catalogue?.masterId);
      this.data.catalogue?.catalogueDetails.forEach(d => {
        let newCata = this.fb.group({
          detailId: [d.detailId,Validators.required],
          name: [d.name,Validators.required],
          masterId: [d.masterId,Validators.required]
        })
        this.cataloguedetails.push(newCata);
      });

    }
    if (this.data.mode == 'Delete')
      this.catalogueForm.disable();
    if (this.data.mode == 'View')
      this.catalogueForm.disable();

  }
  ngOnInit(): void {
    this.catalogueForm.patchValue(this.data)
  }

  get cataloguedetails(): FormArray {
    return this.catalogueForm.controls['catalogueDetails'] as FormArray
  }

  addCatalogueDetail() {
    let newCata = this.fb.group({
      detailId: [''],
      name: [],
      masterId: ['']
    })
    this.cataloguedetails.push(newCata);
  }
  onSubmit() {
    console.log(this.catalogueForm.value);
  }
  removeSkill(i: number) {
    this.cataloguedetails.removeAt(i);
  }

  save() {
    if (this.catalogueForm.invalid) {
      alert('Please fill all required fields')
      return;
    }
    let Dataform: CatalogueMasterDto = this.catalogueForm.value;
    this.catalogueser.createCatalogue(Dataform).subscribe((res: ApiResponseModel) => {
      if (res.success) {
        this.dialogRef.close(true);
      }
      else {
        alert(res.message);
      }
    }, err => { })
  }
  update() {
    if (this.catalogueForm.invalid) {
      alert('Please fill all required fields')
      return;
    }
    let Dataform: CatalogueMasterDto = this.catalogueForm.value;
    this.catalogueser.updateCatalogue(Dataform).subscribe((res: ApiResponseModel) => {
      if (res.success) {
        this.dialogRef.close(true);
      }
      else {
        alert(res.message);
      }
    },err => { }
  )
  }

  deleteItem() {
    let Dataform: CatalogueMasterDto = this.catalogueForm.getRawValue();
    this.catalogueser.deleteCatalogue(Dataform.masterId).subscribe(res => {
    if (res.success) {
      console.log(res);
      this.dialogRef.close(true);
    }
  }, error => { });
  }

}



