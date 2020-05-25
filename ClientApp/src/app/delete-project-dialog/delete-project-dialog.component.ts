import { Component, OnInit, Input } from '@angular/core';
import { NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { Store } from '@ngrx/store';
import { State } from '../reducers';
import { deleteProject } from '../project/project.actions';

@Component({
  selector: 'app-delete-project-dialog',
  templateUrl: './delete-project-dialog.component.html',
  styleUrls: ['./delete-project-dialog.component.css']
})
export class DeleteProjectDialogComponent implements OnInit {
  modalRef: NgbModalRef;
  projectId: number;

  constructor(private store: Store<State>) { }

  ngOnInit() {
    this.modalRef.result.then(confirmed => {
      if (confirmed) {
        this.store.dispatch(deleteProject({ projectId: this.projectId }));
      }
    });
  }

}
