import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'User managment panel';
  //страница по-умолчанию
  page : number = 0;

  switchPage(id:number){
    this.page = id;
  }
}
