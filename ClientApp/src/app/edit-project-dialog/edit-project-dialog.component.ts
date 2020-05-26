import { Component, OnInit } from '@angular/core';
import { NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { State } from '../reducers';
import { getProject } from '../project/project.actions';
import { selectCurrentProject } from '../project/project.selectors';
import Project from '../models/project';

@Component({
  selector: 'app-edit-project-dialog',
  templateUrl: './edit-project-dialog.component.html',
  styleUrls: ['./edit-project-dialog.component.css']
})
export class EditProjectDialogComponent implements OnInit {
  project$: Observable<Project> = this.store.select(selectCurrentProject);
  modalRef: NgbModalRef;
  projectId: number;

  constructor(private store: Store<State>) { }

  ngOnInit() {
    this.store.dispatch(getProject({ projectId: this.projectId }));
  }

}
