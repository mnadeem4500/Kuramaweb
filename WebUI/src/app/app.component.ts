import { Component } from '@angular/core';
import { MatDialogModule } from '@angular/material/dialog';

import { AdminCategoryItemComponent } from './admin/components/category-managment/admin-category-item/admin-category-item.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'CommerceUI';
}
