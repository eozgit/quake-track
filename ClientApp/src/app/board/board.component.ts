import { Component, OnInit } from '@angular/core';
import { TitleCasePipe } from '@angular/common';
import { CdkDragDrop } from '@angular/cdk/drag-drop';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import Project from '../models/project';
import Issue from '../models/issue';
import { State } from '../reducers';
import { dragIssue } from '../project/project.actions';
import { selectIssues, selectCurrentProject } from '../project/project.selectors';

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

  constructor(private store: Store<State>) {
  }

  ngOnInit(): void {
  }

  drop(event: CdkDragDrop<Issue[]>) {

    const issue = {
      id: event.previousContainer.data[event.previousIndex].id,
      status: new TitleCasePipe().transform(event.container.id.replace('List', '')),
      index: event.currentIndex,
      summary: null, description: null, issueType: null, assignee: null, storypoints: null, priority: null, users: null
    };

    let projectId;
    this.project$.subscribe(project => projectId = project.id);

    this.store.dispatch(dragIssue({ projectId, issue }));

  }

}
