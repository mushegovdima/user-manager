import { HttpHeaders } from '@angular/common/http';

export const environment = {
  production: true
};

export const ApiInfo = 
{
  headers : new HttpHeaders()
    .append("Content-Type", "application/json")
    .append("access-control-allow-origin", "*"),
  url : 'https://localhost:44380/api/'
}