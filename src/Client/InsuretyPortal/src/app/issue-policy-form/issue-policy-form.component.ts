import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { PaymentStatus } from 'src/@types/Policy';
import { PolicyService } from 'src/service/policy-service.service';

@Component({
  selector: 'app-issue-policy-form',
  templateUrl: './issue-policy-form.component.html',
  styleUrls: ['./issue-policy-form.component.css'],
})
export class IssuePolicyFormComponent implements OnInit {
  issueForm: FormGroup;

  issueSuccess:
    | {
        description: string;
      }
    | null
    | undefined;

  constructor(
    private readonly policyService: PolicyService,
    private readonly activateRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.issueForm = new FormGroup({
      paymentStatus: new FormControl('', [Validators.required]),
      durationInDays: new FormControl(0, [Validators.required]),
      PaymentEffectiveDate: new FormControl(new Date()),
      coveredSum: new FormControl(0, Validators.required),
    });
  }

  get paymentStatus(): string[] {
    return Object.getOwnPropertyNames(PaymentStatus).filter((val) =>
      Number.isNaN(parseInt(val))
    );
  }

  static calculateNumberOfDays(dateA: Date, dateB: Date): number {
    const NO_OF_MS_IN_A_DAY = 24 * 60 * 60 * 1000;
    const msRange = Math.abs(dateA.getTime() - dateB.getTime());

    return msRange / NO_OF_MS_IN_A_DAY;
  }

  static convertToFormat(date: Date) {
    const YYYY = date.getFullYear();
    const month = date.getMonth() + 1;
    const datenum = date.getDate();

    const dd = datenum <= 9 ? '0' + datenum.toString() : datenum.toString();
    const MM = month <= 9 ? '0' + month.toString() : month.toString();

    return `${YYYY}-${MM}-${dd}`;
  }

  onDurationChange(event: Event): void {
    const e = <Event & { target: { value: string; valueAsDate: Date } }>event;
    console.log(e);
    IssuePolicyFormComponent.convertToFormat(new Date(e.target.value));

    const durationInDays = IssuePolicyFormComponent.calculateNumberOfDays(
      e.target.valueAsDate,
      new Date()
    );

    this.issueForm.controls['durationInDays'].setValue(
      Math.ceil(durationInDays)
    );

    console.log(this.issueForm);
  }

  async onSubmit() {
    const policyId = this.activateRoute.snapshot.paramMap.get('policyId');
    if (this.issueForm.invalid) return;

    this.issueSuccess = await this.policyService.issuePolicy(
      policyId!,
      this.issueForm.value
    );
  }
}
