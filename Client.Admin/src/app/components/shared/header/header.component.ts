import { Component, inject, OnInit } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
// import { LoginService } from '../../services/popups/login/login.service';
import { ButtonModule } from 'primeng/button';
import { AuthService } from '../../../services/auth/auth.service';
// import { SearchComponent } from '../search/search.component';
import { MenuModule } from 'primeng/menu';
import { MenuItem } from 'primeng/api';
import { FormsModule } from '@angular/forms';
import { FloatLabel } from 'primeng/floatlabel';
import { InputGroupModule } from 'primeng/inputgroup';
import { InputGroupAddonModule } from 'primeng/inputgroupaddon';
import { InputTextModule } from 'primeng/inputtext';
// import { SearchService } from '../../services/search/search.service';

@Component({
  selector: 'app-header',
  standalone: true,
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
  imports: [
    RouterLink,
    RouterLinkActive,
    ButtonModule,
    MenuModule,
    FormsModule,
    FloatLabel,
    InputGroupModule,
    InputGroupAddonModule,
    InputTextModule,
  ],
})
export class HeaderComponent implements OnInit {
  isDiscount: boolean = false;
  items: MenuItem[] | undefined;
  // searchInput: string = '';

  // loginService = inject(LoginService);
  authService = inject(AuthService);
  // searchService = inject(SearchService);

  ngOnInit() {
    console.log('from header');
    this.items = [
      {
        label: 'Options',
        items: [
          {
            label: 'account',
            icon: 'pi pi-cog',
            routerLink: '/account',
          },
          {
            label: 'logout',
            icon: 'pi pi-sign-out',
            command: () => {
              this.authService.logout();
            }
          },
        ],
      },
    ];
  }
}
