import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import Project from '../models/project';
import { State } from '../reducers';
import { selectCurrentProject } from '../project/project.selectors';

@Component({
  selector: 'app-board-page',
  templateUrl: './board-page.component.html',
  styleUrls: ['./board-page.component.css']
})
export class BoardPageComponent implements OnInit {
  project$: Observable<Project> = this.store.select(selectCurrentProject);

  constructor(private store: Store<State>) { }

  ngOnInit() {
  }
}
