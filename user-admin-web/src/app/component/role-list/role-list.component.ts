import { Component, OnInit, ViewChild } from '@angular/core';
import { RolesService } from 'src/app/services/roles.service';
import { Role } from 'src/app/models/role';

@Component({
  selector: 'app-role-list',
  templateUrl: './role-list.component.html',
  styleUrls: ['./role-list.component.scss']
})
export class RoleListComponent implements OnInit {

  roles: Role[]

  constructor(private rolesService : RolesService) { }

  ngOnInit(){
    this.rolesService.roles
    .subscribe(roles => {
      this.roles = roles;
    })
  }

  /**delete role */
  delete(id: number){
    this.rolesService.delete(id);
  }
}
