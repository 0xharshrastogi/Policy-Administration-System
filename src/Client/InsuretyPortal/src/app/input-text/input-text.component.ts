import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-input-text',
  templateUrl: './input-text.component.html',
  styleUrls: ['./input-text.component.css'],
})
export class InputTextComponent implements OnInit {
  @Input() mode: 'light' | 'dark' = 'dark';
  @Input() type: 'text' | 'password' | 'email' = 'text';
  @Input() placeholder: string = '';
  @Input() name: string = '';

  constructor() {}

  ngOnInit(): void {}
}
