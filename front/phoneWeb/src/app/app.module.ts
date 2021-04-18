import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import { PhoneComponent } from './pages/phone/phone.component';
import { PhoneService } from './services/phone.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    PhoneComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [PhoneService, HttpClientModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
