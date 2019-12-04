import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule} from '@angular/material/button';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatTableModule} from '@angular/material/table';
import {MatListModule} from '@angular/material/list';
import {MatCardModule} from '@angular/material/card';
import {MatSortModule} from '@angular/material/sort';
import { AppComponent } from './app.component';
import { UserPageComponent } from './component/user-list-page/user-list-page.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { UserEditorComponent } from './component/user-editor/user-editor.component';
import {MatIconModule} from '@angular/material/icon';
import {MatToolbarModule} from '@angular/material/toolbar';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material';
import { RolePipe } from './pipes/role.pipe';
import { RoleListComponent } from './component/role-list/role-list.component';
import { RoleEditorComponent } from './component/role-editor/role-editor.component';
import { HttpClientModule } from '@angular/common/http'

@NgModule({
  declarations: [
    AppComponent,
    UserPageComponent,
    UserEditorComponent,
    RolePipe,
    RoleListComponent,
    RoleEditorComponent 
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatButtonModule,
    MatPaginatorModule,
    MatCardModule,
    MatIconModule,
    MatToolbarModule,
    FormsModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatSortModule,
    MatListModule,
    HttpClientModule
  ],
  entryComponents: [
    UserEditorComponent
  ],
  providers: [
    {
      provide: MatDialogRef,
      useValue: {}
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
