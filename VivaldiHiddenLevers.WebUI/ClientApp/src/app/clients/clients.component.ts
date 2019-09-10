import { Component, OnInit, OnChanges } from '@angular/core';
import { ClientsListViewModel, ClientsClient, ClientDetailModel, StressTestDetailModel,
        RiskProfileDetailModel, StressTestsClient, RiskProfilesClient } from '../vivaldi-hiddenlevers-api';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styles: []
})
export class ClientsComponent implements OnInit {

  public vm: ClientsListViewModel = new ClientsListViewModel();
  public vmDetails: ClientDetailModel = new ClientDetailModel();
  public vmStressTest: StressTestDetailModel = new StressTestDetailModel();
  public vmRiskProfile: RiskProfileDetailModel = new RiskProfileDetailModel();
  public idOutput = -1;
  public clientMailTo: string;

  constructor(public fb: FormBuilder, private client: ClientsClient,
              private sclient: StressTestsClient, private rclient: RiskProfilesClient) {
    this.client.getAll().subscribe(result => {
      this.vm = result;
    }, error => console.error(error));
  }

  clientsForm = this.fb.group({
    name: ['']
  });

  onSelect(e: number) {
    this.clientsForm.get('name').setValue(e);
    this.idOutput = e;

    if (this.idOutput > 0) {
      this.client.get(this.idOutput).subscribe(result => {
        this.vmDetails = result;
        this.updateMailTo(result);
      }, error => console.error(error));
      this.sclient.getForClient(this.idOutput).subscribe(result => {
        this.vmStressTest = result;
      }, error => console.error(error));
      this.rclient.getForClient(this.idOutput).subscribe(result => {
        this.vmRiskProfile = result;
      });
    }
  }

  updateMailTo(result: ClientDetailModel) {
    this.clientMailTo = 'mailto:' + result.email + '?Subject=Risk%20Tolerance%20Questionnaire&body=Hello%20'
    + result.name + ',%0A%0APlease%20click%20on%20the%20below%20link%20to%20walk%20throug'
    + 'h%20our%20risk%20tolerance%20questionnaire.%20This%20quick%20and%20easy%20survey%20will%20giv'
    + 'e%20us%20a%20better%20idea%20of%20what%20your%20appetite%20for%20risk%20is.%0A%0A'
    + result.url + '%0D%0A%0AKinds%20regards,';
  }

  ngOnInit() {
  }
}
