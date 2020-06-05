import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import Project from '../models/project';
import { State } from '../reducers';
import { selectCurrentProject } from '../project/project.selectors';
import { CreateIssueDialogComponent } from '../create-issue-dialog/create-issue-dialog.component';

@Component({
  selector: 'app-board-page',
  templateUrl: './board-page.component.html',
  styleUrls: ['./board-page.component.css']
})
export class BoardPageComponent implements OnInit {
  project$: Observable<Project> = this.store.select(selectCurrentProject);
  faPlus = faPlus;

  constructor(private store: Store<State>, private modalService: NgbModal) { }

  ngOnInit() { }

  openCreateIssue() {
    const modalRef = this.modalService.open(CreateIssueDialogComponent);
    const dialog = modalRef.componentInstance as CreateIssueDialogComponent;
    dialog.modalRef = modalRef;
    // dialog.projectId = projectId;
  }
}
