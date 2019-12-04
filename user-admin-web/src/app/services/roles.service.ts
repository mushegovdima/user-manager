import { Injectable } from '@angular/core';
import { Role } from '../models/role';
import { BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ApiInfo } from 'src/environments/environment.prod';
@Injectable({
  providedIn: 'root'
})
export class RolesService {

  public roles = new BehaviorSubject<Role[]>([]);
  private url = ApiInfo.url + 'Role';
  
  constructor(private http: HttpClient) {
    this.loadRoles()
  }

  private loadRoles(){
    this.http.get<Role[]>(this.url, { headers: ApiInfo.headers })
      .subscribe(res => {
        this.roles.next(res);
      },
        (err) => console.error(err)
      )
  }

  delete(id: number) {
    return this.http.delete(this.url + '/' + id,
      {
        headers: ApiInfo.headers
      })
      .subscribe(res => {
        this.loadRoles();
      },
        (err) => console.error(err)
      )
  }
   
   update(entity: Role){
    this.http.post(this.url, entity, { headers: ApiInfo.headers })
    .subscribe(res => {
      this.loadRoles();
    },
      (err) => console.error(err)
    );
   }

}
