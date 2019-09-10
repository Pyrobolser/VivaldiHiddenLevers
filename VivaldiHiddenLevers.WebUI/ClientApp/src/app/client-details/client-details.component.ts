import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { ClientDetailModel } from '../vivaldi-hiddenlevers-api';
import { SafeUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-client-details',
  templateUrl: './client-details.component.html',
  styles: []
})
export class ClientDetailsComponent implements OnInit {

  @Input() detailsInput: ClientDetailModel;
  @Input() mailTo: string;

  constructor() { }

  ngOnInit() {
  }
}
