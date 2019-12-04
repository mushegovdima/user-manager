import { Injectable, OnInit } from '@angular/core';
import { RolesService } from './roles.service';
import { User } from '../models/user';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { ApiInfo } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  public users = new BehaviorSubject<User[]>([]);
  private url = ApiInfo.url + 'User';

  constructor(private rolesService: RolesService,
    private http: HttpClient) {
    this.loadUsers()
  }

  private loadUsers() {
    return this.http
      .get<User[]>(this.url, { headers: ApiInfo.headers })
      .subscribe(res => {
        this.users.next(res);
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
        this.loadUsers();
      },
        (err) => console.error(err)
      )
  }

  update(entity: User) {
    this.http.post(this.url, entity, { headers: ApiInfo.headers })
      .subscribe(res => {
        this.loadUsers();
      },
        (err) => console.error(err)
      );
  }
}
