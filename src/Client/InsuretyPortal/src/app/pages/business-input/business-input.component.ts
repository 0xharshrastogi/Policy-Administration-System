import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ConsumerService } from 'src/service/consumer-service.service';

@Component({
  selector: 'app-business-input',
  templateUrl: './business-input.component.html',
  styleUrls: ['./business-input.component.css'],
})
export class BusinessInputComponent implements OnInit {
  customerID: string;
  createBusinessForm: FormGroup;
  private readonly _router: ActivatedRoute;

  constructor(
    activedRoute: ActivatedRoute,
    private route: Router,
    private cservice: ConsumerService
  ) {
    this._router = activedRoute;
    this.createBusinessForm = new FormGroup({
      customerID: new FormControl(
        this._router.snapshot.paramMap.get('id'),
        Validators.required
      ),
      businessName: new FormControl('', Validators.required),
      businessType: new FormControl('', Validators.required),
      totalEmployees: new FormControl('', Validators.required),
      annualTurnover: new FormControl('', Validators.required),
      businessValue: new FormControl('', Validators.required),
    });
  }
  get isSubmitDisabled(): boolean {
    if (!this.createBusinessForm.touched) return false;
    return this.createBusinessForm.invalid;
  }

  ngOnInit(): void {
    this.customerID = this._router.snapshot.paramMap.get('id')!;
  }
  async addnewbusiness() {
    if (this.createBusinessForm.valid) {
      var response = await this.cservice.addBusiness(
        this.createBusinessForm.value
      );
      console.log(response);
      // this.route.navigate(['/customer']);
    } else alert('form is invalid');

    console.log(this.createBusinessForm.value);
  }
}
