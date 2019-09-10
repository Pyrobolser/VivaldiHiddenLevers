import { Component, OnInit, Input } from '@angular/core';
import { RiskProfileDetailModel } from '../vivaldi-hiddenlevers-api';

@Component({
  selector: 'app-client-riskprofile',
  templateUrl: './client-riskprofile.component.html',
  styles: []
})
export class ClientRiskprofileComponent implements OnInit {

  @Input() riskProfileInput: RiskProfileDetailModel;

  constructor() { }

  ngOnInit() {
  }

}
