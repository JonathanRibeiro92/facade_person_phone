import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { Phone } from "../models/phone";
import {environment} from "../../environments/environment";
import { PhoneResponse } from "../models/phoneResponse";
import { PhoneListResponse } from "../models/phoneListResponse";

var httpOptions = {
  headers: new HttpHeaders({ "Content-Type": "application/json" }),
};
@Injectable()
export class PhoneService {
  url = environment.apiUrl;
  private phoneList: Phone[];

  constructor(private http: HttpClient) {}

  getAllPhones(): Observable<PhoneListResponse>{
    return this.http.get<PhoneListResponse>(this.url);
  }

  getPhone(phoneId: number): Observable<PhoneResponse>{
    const apiurl = `${this.url}/${phoneId}`;
    return this.http.get<PhoneResponse>(apiurl);
  }

  createPhone(phone: Phone): Observable<PhoneResponse>{
    return this.http.post<PhoneResponse>(this.url, phone, httpOptions);
  }

  updatePhone(phoneId: number, phone: Phone): Observable<PhoneResponse>{
    const apiurl = `${this.url}/${phoneId}`;
    return this.http.put<PhoneResponse>(apiurl, phone, httpOptions);
  }

  deletePhone(phoneId: number): Observable<PhoneResponse> {
    const apiurl = `${this.url}/${phoneId}`;
    return this.http.delete<PhoneResponse>(apiurl, httpOptions);
  }

}
