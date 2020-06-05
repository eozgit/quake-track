import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { Issue, Project } from '../models';
import { State } from '../reducers';
import { createIssue } from '../project/project.actions';
import { selectCurrentProject } from '../project/project.selectors';

@Component({
  selector: 'app-create-issue-dialog',
  templateUrl: './create-issue-dialog.component.html',
  styleUrls: ['./create-issue-dialog.component.css']
})
export class CreateIssueDialogComponent implements OnInit {
  modalRef: NgbModalRef;
  project$: Observable<Project> = this.store.select(selectCurrentProject);
  issue: Issue = {
    id: null,
    summary: null,
    description: null,
    issueType: 'Task',
    assigneeId: null,
    storypoints: 1,
    status: 'New',
    priority: 'Medium',
    index: null
  };
  issueTypes = ['Task', 'Bugfix', 'Refactor'];
  storypoints = [1, 2, 3, 5, 8, 13, 21];
  priority = ['Lowest', 'Low', 'Medium', 'High', 'Highest'];


  constructor(private store: Store<State>) {
  }

  ngOnInit(): void {
  }

  save() {
    let projectId;
    this.project$.subscribe(project => projectId = project.id).unsubscribe();
    this.store.dispatch(createIssue({ projectId, issue: this.issue }));
  }

}
