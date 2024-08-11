


import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';

interface PeriodicElement {
  image: string;
  name: string;
  description: string;
  slug: string;
  count: number;
}

const ELEMENT_DATA: PeriodicElement[] = [
  { image: 'assets/images/c-1.jpg', name: 'Cars', description: 'Description 1', slug: 'hydrogen-slug', count: 5 },
  { image: 'assets/images/c-2.jpeg', name: 'Motors', description: 'Description 2', slug: 'helium-slug', count: 10 },
  { image: 'assets/images/car3.webp', name: 'Uncategorized', description: 'Description 3', slug: 'lithium-slug', count: 8 },
  // Add more dynamic data as needed
];

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.scss'],
})
export class FeedbackComponent implements OnInit {
  categoryForm: FormGroup;
  categories: { name: string }[] = [{ name: 'Layout' }, { name: 'Cars' }, { name: 'Motors' }];
  searchText: string = '';
  dataSource: MatTableDataSource<PeriodicElement>;

  displayedColumns: string[] = ['image', 'name', 'description', 'slug', 'count'];

  constructor(private formBuilder: FormBuilder) {
    this.categoryForm = this.formBuilder.group({
      name: ['', [Validators.required]],
      parentId: [''],
      icon: ['', [Validators.required]],
      maxAllowedImages: [''],
      postValidity: [''],
    });

    // Initialize dataSource with dynamic data
    this.dataSource = new MatTableDataSource(ELEMENT_DATA);
  }

  ngOnInit() {
    this.dataSource.filterPredicate = (data, filter) => {
      return data.name.toLowerCase().includes(filter.toLowerCase());
    };
  }

  onSubmit() {
    if (this.categoryForm.valid) {
      const formData = this.categoryForm.value;
      this.categories.push(formData);
      this.dataSource.data = ELEMENT_DATA; // Update data with the dynamic data
      this.categoryForm.reset();
    }
  }

  onSearch() {
    this.dataSource.filter = this.searchText.trim().toLowerCase();
  }
}
