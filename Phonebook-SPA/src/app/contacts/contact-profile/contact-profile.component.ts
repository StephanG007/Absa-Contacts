import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Contact } from 'src/app/_models/contact';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ContactService } from 'src/app/_services/contact.service';

@Component({
  selector: 'app-contact-profile',
  templateUrl: './contact-profile.component.html',
  styleUrls: ['./contact-profile.component.css']
})
export class ContactProfileComponent {
  @Input() contact: Contact;
  @Output() refresh = new EventEmitter();

  apiUrl = environment.apiUrl + 'contacts/';
  headers = {  } as HttpHeaders;

  constructor(private contactService: ContactService) { }

  createContact() {
    this.contactService.create(this.contact).subscribe(data => {
      this.contact = data;
      this.refresh.emit();
    });
  }

  editContact() {
    this.contactService.edit(this.contact).subscribe(data => {
      this.contact = data;
      this.refresh.emit();
    });
  }

  cancel() {
    this.contact = <Contact>{};
  }

  deleteContact() {
    this.contactService.delete(this.contact.instanceId)
      .subscribe(res => {
        this.contact = <Contact>{};
        this.refresh.emit();
      });
  }
}
