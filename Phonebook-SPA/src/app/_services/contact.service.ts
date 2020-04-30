import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Contact } from '../_models/contact';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  baseUrl = environment.apiUrl + 'contacts/';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Contact[]> {
    return this.http.get<Contact[]>(this.baseUrl);
  }

  getContact(id: string): Observable<Contact> {
    return this.http.get<Contact>(this.baseUrl + id);
  }

  create(contact: Contact): Observable<Contact> {
    return this.http.post<Contact>(`${this.baseUrl}create`, contact);
  }

  edit(contact: Contact): Observable<Contact> {
    return this.http.post<Contact>(`${this.baseUrl}edit/${contact.instanceId}`, contact);
  }

  delete(id: string) {
    return this.http.delete(`${this.baseUrl}delete/${id}`);
  }

  search(query): Observable<Contact[]> {
    return this.http.get<Contact[]>(`${this.baseUrl}search/${query}`);
  }
}
