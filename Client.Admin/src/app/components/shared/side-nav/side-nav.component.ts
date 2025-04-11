import { Component, inject } from '@angular/core';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { AuthService } from '../../../services/auth/auth.service';
import { NgIf } from '@angular/common';
import { PanelMenu } from 'primeng/panelmenu';
import { MenuItem, MessageService } from 'primeng/api';
import { MenuModule } from 'primeng/menu';
import { BadgeModule } from 'primeng/badge';
import { RippleModule } from 'primeng/ripple';
import { AvatarModule } from 'primeng/avatar';

@Component({
  selector: 'app-side-nav',
  standalone: true,
  templateUrl: './side-nav.component.html',
  styleUrl: './side-nav.component.css',
  imports: [
    RouterLink,
    RouterLinkActive,
    NgIf,
    PanelMenu,
    MenuModule,
    BadgeModule,
    RippleModule,
    AvatarModule,
  ],
  providers: [MessageService],
})
export class SideNavComponent {
  authService = inject(AuthService);
  router = inject(Router);

  userNavItems!: MenuItem[];

  adminNavItems!: MenuItem[];

  ngOnInit() {
    this.userNavItems = [
      {
        separator: true,
      },
      {
        label: 'Dashboard',
        items: [
          {
            label: 'Home',
            icon: 'pi pi-database',
            shortcut: '⌘+N',
            command: () => {
              this.router.navigate(['/']);
            },
          },
          {
            label: 'Stats',
            icon: 'pi pi-chart-bar',
            shortcut: '⌘+S',
          },
        ],
      },
      {
        label: 'Courses',
        items: [
          {
            label: 'All',
            icon: 'pi pi-chart-bar',
            shortcut: '⌘+N',
            command: () => {
              this.router.navigate(['/courses']);
            },
          },
          {
            label: 'Search',
            icon: 'pi pi-search',
            shortcut: '⌘+S',
          },
        ],
      },
      {
        label: 'Instructors',
        items: [
          {
            label: 'All',
            icon: 'pi pi-chart-bar',
            shortcut: '⌘+N',
            command: () => {
              this.router.navigate(['/admin/properties']);
            },
          },
          {
            label: 'Search',
            icon: 'pi pi-search',
            shortcut: '⌘+S',
          },
        ],
      },
      {
        label: 'Students',
        items: [
          {
            label: 'All',
            icon: 'pi pi-database',
            shortcut: '⌘+N',
            command: () => {
              this.router.navigate(['/admin/properties']);
            },
          },
          {
            label: 'Stats',
            icon: 'pi pi-chart-bar',
            shortcut: '⌘+S',
          },
        ],
      },
      {
        label: 'Admins',
        items: [
          {
            label: 'Accounts',
            icon: 'pi pi-cog',
            shortcut: '⌘+O',
          },
          {
            label: 'Messages',
            icon: 'pi pi-inbox',
            badge: '2',
          }
        ],
      },
      {
        separator: true,
      },
    ];

    this.adminNavItems = [
      {
        label: 'Router',
        icon: 'pi pi-palette',
        items: [
          {
            label: 'Installation',
            icon: 'pi pi-eraser',
            route: '/installation',
          },
          {
            label: 'Configuration',
            icon: 'pi pi-heart',
            route: '/configuration',
          },
        ],
      },
      {
        label: 'Programmatic',
        icon: 'pi pi-link',
        command: () => {
          this.router.navigate(['/installation']);
        },
      },
      {
        label: 'External',
        icon: 'pi pi-home',
        items: [
          {
            label: 'Angular',
            icon: 'pi pi-star',
            url: 'https://angular.io/',
          },
          {
            label: 'Vite.js',
            icon: 'pi pi-bookmark',
            url: 'https://vitejs.dev/',
          },
        ],
      },
    ];
  }
}
