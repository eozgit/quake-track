import { Component, OnInit } from '@angular/core';
import { NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { Store } from '@ngrx/store';
import { clone } from "lodash";
import { faMinusCircle, faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { State } from '../reducers';
import { updateProject, addUser, removeUser } from '../project/project.actions';
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
  project: Project = {
    id: null,
    name: "",
    description: "",
    issues: [],
    users: [],
  };
  projectId: number;
  email: string;
  faMinusCircle = faMinusCircle;
  faPlusCircle = faPlusCircle;

  constructor(private store: Store<State>) { }

  ngOnInit() {
    this.project$.pipe(take(1)).toPromise().then(p => this.project = clone(p));
  }

  save() {
    this.store.dispatch(updateProject({
      project: {
        ...this.project,
        users: []
      }
    }));

  }

  addUser() {
    this.store.dispatch(addUser({
      projectId: this.projectId,
      email: this.email
    }));
  }

  removeUser(userId: string) {
    this.store.dispatch(removeUser({
      projectId: this.projectId,
      userId
    }));
  }
}
