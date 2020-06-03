import { Component, OnInit } from '@angular/core';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import Issue from '../models/issue';
import { State } from '../reducers';
import { selectIssues } from '../project/project.selectors';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.css']
})
export class BoardComponent implements OnInit {
  newIssues$: Observable<Issue[]>;
  developIssues$: Observable<Issue[]>;
  testIssues$: Observable<Issue[]>;
  doneIssues$: Observable<Issue[]>;

  constructor(private store: Store<State>) { }

  ngOnInit(): void {
    this.newIssues$ = this.store.select(selectIssues, { status: 'New' });
    this.developIssues$ = this.store.select(selectIssues, { status: 'Develop' });
    this.testIssues$ = this.store.select(selectIssues, { status: 'Test' });
    this.doneIssues$ = this.store.select(selectIssues, { status: 'Done' });
  }

  drop(event: CdkDragDrop<string[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex);
    }
  }
}
