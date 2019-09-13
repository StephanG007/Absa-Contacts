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
  selectedContact = {} as Contact;
  searchQuery: string;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getContacts();
   }

  getContacts() {
    return this.http.get<Contact[]>(this.baseUrl)
      .subscribe(data => {
        this.contacts = data;
      });
  }

  searchChange() {
    if (this.searchQuery.length === 0) {
      this.getContacts();
    }

    if (this.searchQuery.length > 0) {
      this.http.get<Contact[]>(this.baseUrl + 'search/' + this.searchQuery)
        .subscribe(data => {
          this.contacts = data;
        });
    }
  }

  getContact(id) {
    this.http.get<Contact>(this.baseUrl + id)
      .subscribe(res => {
        console.log(res);
        this.selectedContact = res;
      });
  }

}
