import { Component, OnInit, Inject, Optional } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { UserService } from 'src/app/services/user.service';
import { RolesService } from 'src/app/services/roles.service';
import { Entity } from 'src/app/models/Entity';
import { Role } from 'src/app/models/role';

@Component({
  selector: 'app-user-editor',
  templateUrl: './user-editor.component.html',
  styleUrls: ['./user-editor.component.scss']
})
export class UserEditorComponent implements OnInit {

  public userForm: FormGroup;
  public rolesControl: FormControl;
  roles: Role[];

  constructor(private formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<UserEditorComponent>,
    private userService: UserService,
    private rolesService: RolesService,
    @Optional() @Inject(MAT_DIALOG_DATA) public data?: any) { }

  ngOnInit() {
    
    this.rolesService.roles
    .subscribe(roles => {
      this.roles = roles;
    })

    this.rolesControl = new FormControl(this.data.roles);
    this.userForm = this.formBuilder.group({
      id: [this.data.id],
      login: [ this.data.login, [Validators.required]],
      name: [this.data.name, [Validators.required]],
      roles: [this.data.roles],
      password: [this.data.password, [Validators.required]],
      email: [this.data.email, [Validators.required, Validators.email]],
    });
  }

  /**save data and close window */
  onSubmit() {
    if (this.userForm.valid) {
      this.userForm.value.roles = this.rolesControl.value;
      this.userService.update(this.userForm.value);
      this.dialogRef.close();
    }
  }

  /**on close popup action */
  onNoClick(): void {
    this.dialogRef.close();
  }

  /**popup title */
  getTitle(){
    return this.data.id > 0 ? ("Editing \"" + this.data.login + "\"")  : "Creating user";
  }

  /**Entity Comparer */
  compareIds(a: Entity, b: Entity): boolean {
    return a && b && a.id === b.id;
  }
}
