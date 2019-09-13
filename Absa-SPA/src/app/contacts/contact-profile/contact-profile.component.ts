import { Component, OnInit, Input } from '@angular/core';
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

  fillContact() {
    console.log('Populating');
    this.contact.firstName = 'Stephan';
    this.contact.lastName = 'Goosen';
    this.contact.email = 'sggoosen3@gmail.com';
    this.contact.photoUrl = '../../../assets/unknown.png';
  }

}
