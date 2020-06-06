import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { NgbModalRef, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Issue, Project } from '../models';
import { State } from '../reducers';
import { selectCurrentProject } from '../project/project.selectors';
import { updateIssue, deleteIssue } from '../project/project.actions';

@Component({
  selector: 'app-edit-issue-dialog',
  templateUrl: './edit-issue-dialog.component.html',
  styleUrls: ['./edit-issue-dialog.component.css']
})
export class EditIssueDialogComponent implements OnInit {
  modalRef: NgbModalRef;
  confirmModalRef: NgbModalRef;
  project$: Observable<Project> = this.store.select(selectCurrentProject);
  issue: Issue = {
    id: null,
    summary: null,
    description: null,
    issueType: null,
    assigneeId: null,
    storypoints: null,
    status: null,
    priority: null,
    index: null
  };
  issueTypes = ['Task', 'Bugfix', 'Refactor'];
  storypoints = [1, 2, 3, 5, 8, 13, 21];
  priority = ['Lowest', 'Low', 'Medium', 'High', 'Highest'];

  constructor(private store: Store<State>, private modalService: NgbModal) { }

  ngOnInit(): void {
  }

  save() {
    let projectId;
    this.project$.subscribe(project => projectId = project.id).unsubscribe();
    this.store.dispatch(updateIssue({ projectId, issue: this.issue }));
  }

  deleteDialog(content: NgbModalRef) {
    this.confirmModalRef = this.modalService.open(content);
  }

  delete() {
    let projectId;
    this.project$.subscribe(project => projectId = project.id).unsubscribe();
    this.store.dispatch(deleteIssue({ projectId, issueId: this.issue.id }));
  }

}
