import { Component, OnInit } from '@angular/core';
import { TitleCasePipe } from '@angular/common';
import { CdkDragDrop } from '@angular/cdk/drag-drop';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { Project, Issue } from '../models';
import { State } from '../reducers';
import { dragIssue } from '../project/project.actions';
import { selectIssues, selectCurrentProject } from '../project/project.selectors';
import { EditIssueDialogComponent } from '../edit-issue-dialog/edit-issue-dialog.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.css']
})
export class BoardComponent implements OnInit {
  project$: Observable<Project> = this.store.select(selectCurrentProject);
  newIssues$: Observable<Issue[]> = this.store.select(selectIssues, { status: 'New' });
  developIssues$: Observable<Issue[]> = this.store.select(selectIssues, { status: 'Develop' });
  testIssues$: Observable<Issue[]> = this.store.select(selectIssues, { status: 'Test' });
  doneIssues$: Observable<Issue[]> = this.store.select(selectIssues, { status: 'Done' });

  constructor(private store: Store<State>, private modalService: NgbModal) {
  }

  ngOnInit(): void {
  }

  drop(event: CdkDragDrop<Issue[]>) {

    const issue = {
      id: event.previousContainer.data[event.previousIndex].id,
      status: new TitleCasePipe().transform(event.container.id.replace('List', '')),
      index: event.currentIndex,
      summary: null, description: null, issueType: null, assigneeId: null, storypoints: null, priority: null, users: null
    };

    let projectId;
    this.project$.subscribe(project => projectId = project.id);

    this.store.dispatch(dragIssue({ projectId, issue }));

  }

  editIssue(issue: Issue) {
    const modalRef = this.modalService.open(EditIssueDialogComponent);
    const dialog = modalRef.componentInstance as EditIssueDialogComponent;
    dialog.modalRef = modalRef;
    dialog.issue.id = issue.id;
    dialog.issue.summary = issue.summary;
    dialog.issue.description = issue.description;
    dialog.issue.issueType = issue.issueType;
    dialog.issue.assigneeId = issue.assigneeId;
    dialog.issue.storypoints = issue.storypoints;
    dialog.issue.priority = issue.priority;
  }

}
