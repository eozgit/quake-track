import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import Issue from '../models/issue';
import { State } from '../reducers';
import { selectIssue } from '../project/project.selectors';

@Component({
  selector: 'app-issue-card',
  templateUrl: './issue-card.component.html',
  styleUrls: ['./issue-card.component.css']
})
export class IssueCardComponent implements OnInit {

  @Input() issueId: number;

  issue$: Observable<Issue>;

  constructor(private store: Store<State>) { }

  ngOnInit() {
    this.issue$ = this.store.select(selectIssue, { issueId: this.issueId });
  }

}
