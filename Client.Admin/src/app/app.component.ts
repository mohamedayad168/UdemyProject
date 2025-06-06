import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SideNavComponent } from "./components/shared/side-nav/side-nav.component";
import { HeaderComponent } from "./components/shared/header/header.component";
import { LoginComponent } from "./components/shared/login/login.component";

import { ProgressSpinner } from 'primeng/progressspinner';
import { LoadingService } from './services/loading/loading.service';
import { AuthService } from './services/auth/auth.service';
import { ScrollService } from './services/scroll/scroll.service';
import { BottomNavComponent } from "./components/shared/bottom-nav/bottom-nav.component";
@Component({
  selector: 'app-root',
  imports: [RouterOutlet, SideNavComponent, HeaderComponent, LoginComponent, ProgressSpinner, BottomNavComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'Client.Admin';
  authService = inject(AuthService);
  loadingService = inject(LoadingService);
  scrollService = inject(ScrollService);

}
