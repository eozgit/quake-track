import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import Issue from '../models/issue';
import { State } from '../reducers';
import { selectIssues } from '../project/project.selectors';

@Component({
  selector: 'app-board-column',
  templateUrl: './board-column.component.html',
  styleUrls: ['./board-column.component.css']
})
export class BoardColumnComponent implements OnInit {

  @Input() status: string;

  issues$: Observable<Issue[]>;

  constructor(private store: Store<State>) {
  }

  ngOnInit() {
    this.issues$ = this.store.select(selectIssues, { status: this.status });
  }

}
