import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import * as ProjectActions from '../project/project.actions';
import Project from '../models/project';
import { State } from '../reducers';

@Component({
  selector: 'app-projects-table',
  templateUrl: './projects-table.component.html',
  styleUrls: ['./projects-table.component.css']
})
export class ProjectsTableComponent implements OnInit {
  projects$: Observable<Project[]> = this.store.select(state => state.project.projects);

  constructor(private store: Store<State>) { }

  ngOnInit() {
    this.store.dispatch(ProjectActions.loadProjects());
  }

}
