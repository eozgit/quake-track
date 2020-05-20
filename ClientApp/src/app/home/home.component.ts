import { Component } from '@angular/core';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { Router } from '@angular/router';
import { take } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  constructor(private authorize: AuthorizeService, private router: Router) {

  }

  async ngOnInit() {
    const isAuthenticated = await this.authorize.isAuthenticated().pipe(
      take(1)
    ).toPromise();

    if (isAuthenticated) {
      this.router.navigate(['/projects']);
    }
  }
}
