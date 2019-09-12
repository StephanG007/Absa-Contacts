import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  baseUrl = environment.apiUrl + 'contacts/';

  constructor(private http: HttpClient) { }

  getUsers() {
    return this.http.get(this.baseUrl);
  }

  getUser(id) {
    return this.http.get(this.baseUrl + id);
  }

  getSearchUsers(query) {
    return this.http.post(this.baseUrl, query);
  }
}
