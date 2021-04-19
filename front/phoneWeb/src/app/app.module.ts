import { NgModule } from "@angular/core";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatTooltipModule } from "@angular/material/tooltip";
import { MatToolbarModule } from "@angular/material/toolbar";

import { AppComponent } from "./app.component";

import { PhoneComponent } from "./pages/phone/phone.component";
import { PhoneService } from "./services/phone.service";
import { HttpClientModule } from "@angular/common/http";
import { FlexLayoutModule } from "@angular/flex-layout";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MatButtonModule, MatCardModule, MatIconModule, MatMenuModule, MatRadioModule, MatSidenavModule } from "@angular/material";

@NgModule({
  declarations: [AppComponent, PhoneComponent],
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatButtonModule,
    MatMenuModule,
    MatIconModule,
    MatCardModule,
    MatSidenavModule,
    MatFormFieldModule,
    MatInputModule,
    MatTooltipModule,
    MatToolbarModule,
    MatRadioModule,
    FlexLayoutModule,
  ],
  providers: [PhoneService, HttpClientModule, MatIconModule],
  bootstrap: [AppComponent],
})
export class AppModule {}
