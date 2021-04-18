import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { Phone } from "../models/phone";
import {environment} from "../../environments/environment";

var httpOptions = {
  headers: new HttpHeaders({ "Content-Type": "application/json" }),
};
@Injectable()
export class PhoneService {
  url = environment.apiUrl;
  private phoneList: Phone[];

  constructor(private http: HttpClient) {}

  getAllPhones(): Observable<Phone[]>{
    return this.http.get<Phone[]>(this.url);
  }

  getPhone(phoneId: number): Observable<Phone>{
    const apiurl = `${this.url}/${phoneId}`;
    return this.http.get<Phone[]>(apiurl);
  }

  createPhone(phone: Phone): Observable<Phone>{
    return this.http.post<Phone>(this.url, phone, httpOptions);
  }

  updatePhone(phoneId: number, phone: Phone): Observable<Phone>{
    const apiurl = `${this.url}/${phoneId}`;
    return this.http.put<Phone>(apiurl, phone, httpOptions);
  }

  deletePhone(phoneId: number): Observable<Phone> {
    const apiurl = `${this.url}/${phoneId}`;
    return this.http.delete<number>(apiurl, httpOptions);
  }

}
