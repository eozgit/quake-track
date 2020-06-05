import { Component, OnInit } from '@angular/core';
import { ToastService } from '../toast.service';
import { ApiClientService } from '../api-client.service';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css']
})
export class ContactUsComponent implements OnInit {
  sendMe = false;
  message = '';

  constructor(private toastService: ToastService, private apiClient: ApiClientService) { }

  ngOnInit() {
  }

  send() {
    if (this.message) {
      this.apiClient.sendEmail({ sendMeACopy: this.sendMe, message: this.message }).subscribe(
        response => this.toastService.show('Email sent. Thank you!', { classname: 'bg-info text-white' }),
        err => this.toastService.show('Email was not sent. Please try again!', { classname: 'bg-danger text-white' })
      );
      this.message = '';
    } else {
      this.toastService.show('Please enter your message.', { classname: 'bg-warning' });
    }
  }

}
