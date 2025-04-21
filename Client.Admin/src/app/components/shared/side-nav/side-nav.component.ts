import {
  Component,
  effect,
  inject,
  Signal,
  signal,
  WritableSignal,
} from '@angular/core';
import {
  Router,
  RouterLink,
  RouterLinkActive,
  RouterModule,
} from '@angular/router';
import { AuthService } from '../../../services/auth/auth.service';
import { NgIf } from '@angular/common';
import { PanelMenu } from 'primeng/panelmenu';
import { MenuItem, MessageService } from 'primeng/api';
import { MenuModule } from 'primeng/menu';
import { BadgeModule } from 'primeng/badge';
import { RippleModule } from 'primeng/ripple';
import { AvatarModule } from 'primeng/avatar';
import { UiStateService } from '../../../services/UiState/ui-state.service';

@Component({
  selector: 'app-side-nav',
  standalone: true,
  templateUrl: './side-nav.component.html',
  styleUrl: './side-nav.component.scss',
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
  // authService = inject(AuthService);
  UiStateService = inject(UiStateService);

  router = inject(Router);

  userNavItems!: MenuItem[];

  adminNavItems!: MenuItem[];

  /**
   *
   */
  constructor(public authService: AuthService) {
    effect(() => {
      // this.isOwner.set(this.authService.isOwner);
      console.log('isOwner', this.authService.isOwner());
      this.buildNavItems(this.authService.isOwner());
    });
  }

  // ngOnInit() {
  //   this.buildNavItems(this.authService.isOwner());
  // }

  buildNavItems(isOwner: boolean = false) {
    this.userNavItems = [
      {
        separator: true,
        styleClass: 'mt-2',
      },
      {
        label: 'Dashboard',
        items: [
          {
            label: 'BI',
            icon: 'pi pi-book',
             command: () => {
              this.UiStateService.closeSideNav();
              this.router.navigate(['/']);
              console.log(this.UiStateService.sideNavOpen());
            },
          },
          {
            label: 'Custom',
            icon: 'pi pi-book',
             command: () => {
              this.UiStateService.closeSideNav();
              this.router.navigate(['/custom']);
            },
          },
        ],
      },

      {
        label: 'Table',
        items: [
          {
            label: 'Courses',
            icon: 'pi pi-video',
             command: () => {
              this.UiStateService.closeSideNav();
              this.router.navigate(['/courses']);
            },
            routerLinkActiveOptions: { exact: true },
          },

          {
            label: 'Students',
            icon: 'pi pi-users',
             command: () => {
              this.UiStateService.closeSideNav();
              this.router.navigate(['/students']);
            },
            routerLinkActiveOptions: { exact: true },
          },
          {
            label: 'Instructors',
            icon: 'pi pi-user',
             command: () => {
              this.UiStateService.closeSideNav();
              this.router.navigate(['/instructors']);
            },
            routerLinkActiveOptions: { exact: true },
          },
          // {
          //   label: 'Issues',
          //   icon: 'pi pi-exclamation-triangle',
          //   routerLink: ['/courses'],
          //   routerLinkActiveOptions: { exact: true },
          // },
          {
            label: 'Admins',
            icon: 'pi pi-cog',
            visible: isOwner,
             command: () => {
              this.UiStateService.closeSideNav();
              this.router.navigate(['/admins']);
            },
            routerLinkActiveOptions: { exact: true },
          },
        ],
      },
    ];

    this.adminNavItems = [
      {
        separator: true,
        label: 'Dashboard',
        icon: 'pi pi-chart-bar',
        // expanded: true,
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
