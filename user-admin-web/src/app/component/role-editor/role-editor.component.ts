import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RolesService } from 'src/app/services/roles.service';

@Component({
  selector: 'app-role-editor',
  templateUrl: './role-editor.component.html',
  styleUrls: ['./role-editor.component.scss']
})
export class RoleEditorComponent implements OnInit {
  roleForm: FormGroup;
  constructor(private formBuilder: FormBuilder,
    private roleService: RolesService) { }

  ngOnInit() {
    this.roleForm = this.formBuilder.group({
      name: ['', [Validators.required]]
    });
  }

  /** add role on submit */
  onSubmit() {
    if (this.roleForm.valid) {
        this.roleService.update(this.roleForm.value);
      }
   }
}
