import { environment } from '../../../environments/environment';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Contact } from 'src/app/_models/contact';
import { HttpClient } from '@angular/common/http';
import { ContactService } from 'src/app/_services/contact.service';


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

  constructor(private service: ContactService) { }

  ngOnInit() {
    this.getContacts();
   }

  getContacts() {
    this.service.getAll().subscribe(data => {
      this.contacts = data;
    });
  }

  searchChange() {
    if (this.searchQuery.length === 0) {
      this.getContacts();
    }

    if (this.searchQuery.length > 0) {
      this.service.search(this.searchQuery)
        .subscribe(data => {
          this.contacts = data;
        });
    }
  }

  getContact(id) {
    this.service.getContact(id)
      .subscribe(data => {
        this.selectedContact = data;
      });
  }

}
