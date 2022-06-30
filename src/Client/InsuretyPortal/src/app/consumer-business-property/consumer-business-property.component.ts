import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-consumer-business-property',
  templateUrl: './consumer-business-property.component.html',
  styleUrls: ['./consumer-business-property.component.css'],
})
export class ConsumerBusinessPropertyComponent implements OnInit {
  @Input() customerID: string;
  constructor() {}

  ngOnInit(): void {}
}
