import { Component } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { ActivatedRoute, NavigationEnd, Router, RouterModule, RouterOutlet } from '@angular/router';

import { CommonModule } from '@angular/common';
import { HeaderComponent } from './lib/components/shared/header/header.component';
import { FooterComponent } from './lib/components/shared/footer/footer.component';
import { ButtonModule } from 'primeng/button';
import { filter } from 'rxjs';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    CommonModule,
    HeaderComponent,
    RouterModule,
    FooterComponent,ButtonModule
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'Udemy.Client';
  showHeader: boolean = false;

constructor(private router: Router,private activatedRoute: ActivatedRoute) {
}
ngOnInit(): void {
  this.router.events.pipe(
    filter(event => event instanceof NavigationEnd)
  ).subscribe(() => {
    const currentRoute = this.router.routerState.snapshot.root.firstChild;
    this.showHeader = !currentRoute?.data?.['hideHeader'] || false;
  });
}


}
