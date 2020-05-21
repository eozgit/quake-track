import { Component, OnInit, Input } from '@angular/core';
import Project from '../models/project';

@Component({
  selector: 'app-projects-row',
  templateUrl: './projects-row.component.html',
  styleUrls: ['./projects-row.component.css']
})
export class ProjectsRowComponent implements OnInit {
  @Input() project: Project;

  constructor() { }

  ngOnInit() {
  }

}
