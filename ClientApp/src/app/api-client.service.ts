import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import Project from './models/project';
import Email from './models/email';

@Injectable({
  providedIn: 'root'
})
export class ApiClientService {

  constructor(private http: HttpClient) { }

  getProjects() {
    return this.http.get('/api/projects');
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

  addUser(id: number, email: Email) {
    return this.http.patch(`/api/projects/${id}/users`, email);
  }

  removeUser(projectId: number, userId: string) {
    return this.http.delete(`/api/projects/${projectId}/users/${userId}`);
  }

  createProject(name: string) {
    return this.http.post('/api/projects', { name });
  }
}
