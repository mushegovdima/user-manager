import { Component, OnInit, ViewChild } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { User } from 'src/app/models/user';
import { MatDialog } from '@angular/material';
import { UserEditorComponent } from '../user-editor/user-editor.component';
import {MatSort} from '@angular/material/sort';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-list-page.component.html',
  styleUrls: ['./user-list-page.component.scss']
})
export class UserPageComponent implements OnInit {

  displayedColumns: string[] = ['login', 'name', 'roles', 'actions'];
  dataSource : MatTableDataSource<User>;
  popupOpened = false;

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) matSort: MatSort;

  constructor(private userService : UserService,
    private dialog?: MatDialog) { }

  ngOnInit() {
    this.userService.users
    .subscribe( users => 
      {
        this.dataSource = new MatTableDataSource<User>(users);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.matSort;
      },
      (error) => console.error(error));
  }

  /**Create new user */
  add() {
    let user = { id : 0, login : '', name : '' };
    this.edit(user);
  }

  /**Edit user */
  edit(user? : User)
  {
    this.popupOpened = true;
    const dialogRef = this.dialog.open(UserEditorComponent, {
      data: user
    });
  
    dialogRef.afterClosed().subscribe(result => {
      this.popupOpened = false;
    });
  }

  /**Delete user */
  delete(id : number){
    this.userService.delete(id);
  }
}
