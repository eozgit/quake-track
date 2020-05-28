import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { State } from '../reducers';
import { createProject } from '../project/project.actions';

@Component({
  selector: 'app-projects-page',
  templateUrl: './projects-page.component.html',
  styleUrls: ['./projects-page.component.css']
})
export class ProjectsPageComponent implements OnInit {
  projectName: string;
  faPlusCircle = faPlusCircle;

  constructor(private store: Store<State>) { }

  ngOnInit() {
  }

  createProject() {
    this.store.dispatch(createProject({
      name: this.projectName
    }));
    this.projectName = '';
  }

}
