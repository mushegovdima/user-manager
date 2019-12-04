import { Pipe, PipeTransform } from '@angular/core';
import { Role } from '../models/role';

@Pipe({
  name: 'role'
})
export class RolePipe implements PipeTransform {

  transform(value: Role[]): any {
    return value ? value.map((role) => role.name).join(', ') : '';
  }

}
