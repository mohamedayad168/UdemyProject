import { Component, inject } from '@angular/core';
import { Router, RouterLink, RouterLinkActive, RouterModule } from '@angular/router';
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
        label: 'Reports',
        icon: 'pi pi-chart-bar',
        expanded: true,
        items: [
          {
            label: 'Custom',
            icon: 'pi pi-book',
            route: '/',
          },
          {
            label: 'BI',
            icon: 'pi pi-book',
            route: 'bi',
          },
        ],
      },
      {
        label: 'Courses',
        icon: 'pi pi-video',
        items: [
          {
            label: 'all courses',
            icon: 'pi pi-database',
            route: '/courses',
            routerLinkActiveOptions: { exact: true },
          },
        ],
      },
      {
        label: 'Instructors',
        icon: 'pi pi-video',
        items: [
          {
            label: 'all courses',
            icon: 'pi pi-database',
            route: '/courses',
            routerLinkActiveOptions: { exact: true },
          },
        ],
      },
      {
        label: 'Students',
        icon: 'pi pi-video',
        items: [
          {
            label: 'all courses',
            icon: 'pi pi-database',
            route: '/courses',
            routerLinkActiveOptions: { exact: true },
          },
        ],
      },
    ];
  }
}
