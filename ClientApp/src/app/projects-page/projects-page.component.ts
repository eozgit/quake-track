import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { State } from '../reducers';
import { createProject } from '../project/project.actions';
import { ToastService } from '../toast.service';

@Component({
  selector: 'app-projects-page',
  templateUrl: './projects-page.component.html',
  styleUrls: ['./projects-page.component.css']
})
export class ProjectsPageComponent implements OnInit {
  projectName: string;
  faPlusCircle = faPlusCircle;

  constructor(private store: Store<State>, private toastService: ToastService) { }

  ngOnInit() {
  }

  createProject() {
    this.store.dispatch(createProject({
      name: this.projectName
    }));
    this.toastService.show(`Project: ${this.projectName} created.`, { classname: 'bg-success text-light' })
    this.projectName = '';
  }

}
