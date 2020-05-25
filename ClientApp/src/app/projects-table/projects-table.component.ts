import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { faEdit, faTrash, faColumns } from '@fortawesome/free-solid-svg-icons';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { loadProjects } from '../project/project.actions';
import Project from '../models/project';
import { State } from '../reducers';
import { DeleteProjectDialogComponent } from '../delete-project-dialog/delete-project-dialog.component';

@Component({
  selector: 'app-projects-table',
  templateUrl: './projects-table.component.html',
  styleUrls: ['./projects-table.component.css']
})
export class ProjectsTableComponent implements OnInit {
  projects$: Observable<Project[]> = this.store.select(state => state.project.projects);
  faEdit = faEdit;
  faTrash = faTrash;
  faColumns = faColumns;

  constructor(private store: Store<State>, private modalService: NgbModal) { }

  ngOnInit() {
    this.store.dispatch(loadProjects());
  }

  openDeleteModal(projectId: number) {
    const modalRef = this.modalService.open(DeleteProjectDialogComponent);
    const dialog = modalRef.componentInstance as DeleteProjectDialogComponent;
    dialog.modalRef = modalRef;
    dialog.projectId = projectId;
  }

}
