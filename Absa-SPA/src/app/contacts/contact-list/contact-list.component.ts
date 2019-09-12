import { environment } from '../../../environments/environment';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Contact } from 'src/app/_models/contact';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})

export class ContactListComponent implements OnInit {
  baseUrl = environment.apiUrl + 'contacts/';
  contacts: Contact[];
  newContact: Contact;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getContacts();
    console.log(this.contacts);
  }

  getContacts() {
    return this.http.get<Contact[]>(this.baseUrl)
      .subscribe(data => {
        this.contacts = data;
      });
  }

  getContact(id): Observable<Contact> {
    return this.http.get<Contact>(this.baseUrl + 'contacts/' + id);
  }

}
