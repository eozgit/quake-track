import { Component, OnInit } from '@angular/core';
import { NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import Issue from '../models/issue';

@Component({
  selector: 'app-create-issue-dialog',
  templateUrl: './create-issue-dialog.component.html',
  styleUrls: ['./create-issue-dialog.component.css']
})
export class CreateIssueDialogComponent implements OnInit {
  modalRef: NgbModalRef;
  issue: Issue = {
    id: null,
    summary: null,
    description: null,
    issueType: null,
    assignee: null,
    storypoints: null,
    status: null,
    priority: null,
    users: [],
    index: null
  };


  constructor() { }

  ngOnInit(): void {
  }

  save() {
    console.log('Issue saved!');
  }

}
