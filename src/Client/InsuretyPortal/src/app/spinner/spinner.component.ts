import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.css'],
})
export class SpinnerComponent implements OnInit {
  message: string = 'hiiii';
  @Input() wheelColor?: string = '';
  @Input() innerColor?: string = '';

  constructor() {
    console.log(this);
  }

  ngOnInit(): void {}
}
