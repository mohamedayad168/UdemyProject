import { Component, inject } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { AuthService } from '../../../services/auth/auth.service';
import { MenuModule } from 'primeng/menu';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-bottom-nav',
  standalone: true,
  imports: [RouterLink,RouterLinkActive,MenuModule],
  templateUrl: './bottom-nav.component.html',
  styleUrl: './bottom-nav.component.scss'
})
export class BottomNavComponent {
authService = inject(AuthService)
items: MenuItem[] | undefined;
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
          },
        },
      ],
    },
  ];
}
}
