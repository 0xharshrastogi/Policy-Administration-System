import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ConsumerService } from 'src/service/consumer-service.service';

@Component({
  selector: 'app-customer-input',
  templateUrl: './customer-input.component.html',
  styleUrls: ['./customer-input.component.css'],
})
export class CustomerInputComponent implements OnInit {
  createCustomerForm: FormGroup;
  constructor(private _cuservice: ConsumerService, private _router: Router) {
    this.createCustomerForm = new FormGroup({
      customerName: new FormControl(''),
      dateOfBirth: new FormControl('', [
        Validators.required,
        // Validators.pattern(/^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/),
      ]),
      email: new FormControl('', [Validators.required, Validators.email]),
      pan: new FormControl('', Validators.required),
    });
  }
  get isSubmitDisabled(): boolean {
    if (!this.createCustomerForm.touched) return false;
    return this.createCustomerForm.invalid;
  }

  ngOnInit(): void {}
  async addnewcustomer() {
    if (this.createCustomerForm.valid) {
      await this._cuservice.addcustomer(this.createCustomerForm.value);
      this._router.navigate(['/customer']);
    } else alert('form is invalid');

    console.log(this.createCustomerForm.value);
  }
}
