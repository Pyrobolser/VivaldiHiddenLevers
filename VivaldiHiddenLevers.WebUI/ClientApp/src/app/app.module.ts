import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClientDetailsComponent } from './client-details/client-details.component';
import { ClientsComponent } from './clients/clients.component';
import { NavbarTopComponent } from './navbar-top/navbar-top.component';
import { ClientStresstestComponent } from './client-stresstest/client-stresstest.component';
import { ClientRiskprofileComponent } from './client-riskprofile/client-riskprofile.component';
import { ClientsClient, RiskProfilesClient, StressTestsClient } from './vivaldi-hiddenlevers-api';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    ClientDetailsComponent,
    ClientsComponent,
    NavbarTopComponent,
    ClientStresstestComponent,
    ClientRiskprofileComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [ClientsClient, RiskProfilesClient, StressTestsClient],
  bootstrap: [AppComponent]
})
export class AppModule { }
