import { Component, OnInit, Input } from '@angular/core';
import { Contact } from 'src/app/_models/contact';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-contact-profile',
  templateUrl: './contact-profile.component.html',
  styleUrls: ['./contact-profile.component.css']
})
export class ContactProfileComponent implements OnInit {
  @Input() contact: Contact;

  constructor(private http: HttpClient) { }

  ngOnInit() {

  }

  createContact() {
    alert(this.contact.firstName);
  }

  fillContact() {
    console.log('Populating');
    this.contact.firstName = 'Stephan';
    this.contact.lastName = 'Goosen';
    this.contact.email = 'sggoosen3@gmail.com';
    this.contact.photoUrl = '../../../assets/unknown.png';
  }

}
