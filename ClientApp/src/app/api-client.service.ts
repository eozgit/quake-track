import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import Project from './models/project';

@Injectable({
  providedIn: 'root'
})
export class ApiClientService {

  constructor(private http: HttpClient) { }

  getProjects() {
    return this.http.get('/api/projects?limit=100');
  }

  getProject(id: number) {
    return this.http.get('/api/projects/' + id);
  }

  updateProject(project: Project) {
    return this.http.patch('/api/projects/' + project.id, project);
  }

  deleteProject(id: number) {
    return this.http.delete('/api/projects/' + id);
  }
}
