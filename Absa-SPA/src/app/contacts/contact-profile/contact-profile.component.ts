import { Component, OnInit, Input, EventEmitter } from '@angular/core';
import { Contact } from 'src/app/_models/contact';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-contact-profile',
  templateUrl: './contact-profile.component.html',
  styleUrls: ['./contact-profile.component.css']
})
export class ContactProfileComponent implements OnInit {
  @Input() contact: Contact;

  apiUrl = environment.apiUrl + 'contacts/';
  headers = {  } as HttpHeaders;

  constructor(private http: HttpClient) { }

  ngOnInit() {

  }

  createContact() {
    console.log(this.contact);
    this.http.post(this.apiUrl + 'create', this.contact).subscribe(response => {
      console.log(response);
    });
  }

  editContact() {
    this.http.post(this.apiUrl + 'edit/' + this.contact.id, this.contact).subscribe(response => {
      console.log(response);
    });
  }

  cancel() {
    this.contact = <Contact>{};
  }

  deleteContact() {
    this.http.delete(this.apiUrl + this.contact.id)
      .subscribe(res => {
        this.contact = <Contact>{};
      });
  }
}
