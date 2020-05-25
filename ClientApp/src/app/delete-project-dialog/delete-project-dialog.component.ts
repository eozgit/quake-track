import { Component, OnInit, Input } from '@angular/core';
import { NgbModalRef } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-delete-project-dialog',
  templateUrl: './delete-project-dialog.component.html',
  styleUrls: ['./delete-project-dialog.component.css']
})
export class DeleteProjectDialogComponent implements OnInit {
  modalRef: NgbModalRef;

  constructor() { }

  ngOnInit() {
  }

}
