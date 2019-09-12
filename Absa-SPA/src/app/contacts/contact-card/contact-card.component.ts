import { Component, OnInit, Input } from '@angular/core';
import { Contact } from 'src/app/_models/contact';

@Component({
  selector: 'app-contact-card',
  templateUrl: './contact-card.component.html',
  styleUrls: ['./contact-card.component.css']
})
export class ContactCardComponent implements OnInit {
  @Input() contact: Contact;

  constructor() { }

  ngOnInit() {
  }

}
