import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  Url = "localhost";
  security: string = "hhh";
  public login(userInfo: any){
    localStorage.setItem('ACCESS_TOKEN', "access_token");
  }

  public isLoggedIn(): Observable<boolean>{
    return of(localStorage.getItem('ACCESS_TOKEN') !== null);
  } 

  public logout(){
    localStorage.removeItem('ACCESS_TOKEN');
  }

  public Send(formData): Observable<any> {
    formData.value.hash = this.security;
    console.log(formData.value)
    return this.http.post(this.Url, formData);
  } 
  public GetSecurity() {
    return this.http.get(this.Url).subscribe(r => this.security = r.toString());
  } 
}
