import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ContactListComponent } from './contacts/contact-list/contact-list.component';
import { ContactProfileComponent } from './contacts/contact-profile/contact-profile.component';
import { ContactService } from './_services/contact.service';
import { ContactCardComponent } from './contacts/contact-card/contact-card.component';

@NgModule({
   declarations: [
      AppComponent,
      ContactListComponent,
      ContactCardComponent,
      ContactProfileComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule
   ],
   providers: [
      ContactService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
