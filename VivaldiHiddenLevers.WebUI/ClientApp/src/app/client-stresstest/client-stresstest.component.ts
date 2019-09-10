import { Component, OnInit, Input } from '@angular/core';
import { StressTestDetailModel } from '../vivaldi-hiddenlevers-api';

@Component({
  selector: 'app-client-stresstest',
  templateUrl: './client-stresstest.component.html',
  styles: []
})
export class ClientStresstestComponent implements OnInit {

  @Input() stressTestInput: StressTestDetailModel;

  constructor() { }

  ngOnInit() {
  }

}
