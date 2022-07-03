import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.css'],
})
export class ButtonComponent implements OnInit {
  @Input() as: 'link' | 'button' = 'button';
  @Input() path: typeof this.as extends 'link' ? never : string;
  @Input() value: string;
  @Input() type: 'submit' | 'reset' | 'button';
  @Input() disabled: boolean = false;
  @Input() loading: boolean;

  constructor() {}

  ngOnInit(): void {
    console.log(this);
  }
}
