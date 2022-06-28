import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css'],
})
export class CustomerComponent implements OnInit {
  loading = true;
  todos: { title: string; id: number }[] = [];

  constructor() {}

  async ngOnInit(): Promise<Promise<void>> {
    this.loading = true;
    const response = await fetch('https://jsonplaceholder.typicode.com/todos');
    const data = await response.json();
    this.todos = data;
    this.loading = false;
  }
}
