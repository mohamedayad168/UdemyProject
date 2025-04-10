import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SideNavComponent } from "./components/shared/side-nav/side-nav.component";
import { HeaderComponent } from "./components/shared/header/header.component";
import { LoginComponent } from "./components/shared/login/login.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, SideNavComponent, HeaderComponent, LoginComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'Client.Admin';
}
