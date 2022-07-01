import { Component, OnInit } from '@angular/core';
import { PaymentStatus } from 'src/@types/Policy';

@Component({
  selector: 'app-issue-policy-form',
  templateUrl: './issue-policy-form.component.html',
  styleUrls: ['./issue-policy-form.component.css'],
})
export class IssuePolicyFormComponent implements OnInit {
  constructor() {}

  get paymentStatus(): string[] {
    return Object.getOwnPropertyNames(PaymentStatus).filter((val) =>
      Number.isNaN(parseInt(val))
    );
  }

  static convertToFormat(date: Date) {
    const YYYY = date.getFullYear();
    const month = date.getMonth() + 1;
    const datenum = date.getDate();

    const dd = datenum <= 9 ? '0' + datenum.toString() : datenum.toString();
    const MM = month <= 9 ? '0' + month.toString() : month.toString();

    return `${YYYY}-${MM}-${dd}`;
  }

  get minimumdate(): string {
    return IssuePolicyFormComponent.convertToFormat(
      new Date(new Date().getTime() + 24 * 60 * 60 * 1000)
    );
  }

  ngOnInit(): void {
    const value = PaymentStatus;
  }
}
