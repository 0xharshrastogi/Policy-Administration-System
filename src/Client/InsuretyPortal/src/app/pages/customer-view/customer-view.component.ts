import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';



type Customer ={
  customerID: string;
  customerName: string;
  dateOfBirth: string;
  email: string;
  pan: string;
}
@Component({
  selector: 'app-customer-view',
  templateUrl: './customer-view.component.html',
  styleUrls: ['./customer-view.component.css']
})
export class CustomerViewComponent implements OnInit {

  customer:Customer|null=null;
  isLoading: boolean =true;
  constructor(private router: ActivatedRoute) { }

  async ngOnInit( ): Promise<void> {
    const customerId=this.router.snapshot.paramMap.get("id");
  console.log(customerId);
    const uri = `http://localhost:5114/Consumer?id=${customerId}`;
    this.isLoading=true;
    const result = await fetch(uri, {
      method: 'GET',
      credentials: 'same-origin',
      headers: {
        'Content-Type': 'application/json',
        accept: '*/*',
      },
    });

    this.customer = await result.json();
    this.isLoading = false;
    console.log(this.customer);
  }

  toDate():string{
    const dob=new Date(this.customer!.dateOfBirth);
    const date = dob;
    const YYYY = date.getFullYear();
    const month = date.getMonth() + 1;
    const datenum = date.getDate();

    const dd = datenum <= 9 ? "0"+datenum.toString(): datenum.toString();
    const MM = month <= 9 ? "0"+month.toString() : month.toString();

    return `${YYYY}-${MM}-${dd}`;

  }

}
