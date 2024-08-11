import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BaseHttpService {

  protected headers = new HttpHeaders();
  protected apiUrl = 'http://localhost:5176/';
  constructor(protected http: HttpClient) {
    this.headers.set('Content-Type', 'application/json');
  }

  protected Get(url: string): Observable<any> {
    return this.http.get(this.apiUrl + url, { headers: this.headers });
  }

  protected Post(url: string, data: any, hds?: HttpHeaders): Observable<any> {
    return this.http.post(this.apiUrl + url, data, { headers: this.headers })
  }

  // protected Put(url: string, data: any,id:number, hds?: HttpHeaders): Observable<any> {
  //   return this.http.put(this.apiUrl + url, id+data,{ headers: this.headers })
  // }
  protected Put(url: string, data: any, hds?: HttpHeaders): Observable<any> {
    return this.http.put(this.apiUrl + url, data,{ headers: this.headers })
  }
  // protected Post(url: string, data: any, hds?: HttpHeaders): Observable<any> {
  //   return this.http.put(this.apiUrl + url, data, { headers: this.headers })
  // }
}
