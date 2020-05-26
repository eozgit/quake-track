import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

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

  deleteProject(id: number) {
    return this.http.delete('/api/projects/' + id);
  }
}
