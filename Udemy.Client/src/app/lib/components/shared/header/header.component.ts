import {
  Component,
  ElementRef,
  inject,
  OnInit,
  ViewChild,
} from '@angular/core';
import { CategoryService } from '../../../services/category.service';
import { CommonModule } from '@angular/common';
import {
  Router,
  RouterLink,
  RouterLinkActive,
  RouterModule,
} from '@angular/router';
import { AccountService } from '../../../services/account.service';
import { MatIcon } from '@angular/material/icon';
import { MatButton } from '@angular/material/button';
import { MatBadge } from '@angular/material/badge';
import { MatProgressBar } from '@angular/material/progress-bar';
import { MatMenu, MatMenuItem, MatMenuTrigger } from '@angular/material/menu';
import { MatDivider } from '@angular/material/divider';
import { FormsModule } from '@angular/forms';
import { BusyService } from '../../../services/busy.service';
import { CartService } from '../../../services/cart/cart.service';
import { CourseService } from '../../../services/course.service';

@Component({
  selector: 'app-header',
  imports: [
    CommonModule,
    RouterModule,
    RouterLink,
    MatIcon,
    MatButton,
    MatBadge,
    RouterLinkActive,
    MatProgressBar,
    MatMenuTrigger,
    MatMenu,
    MatDivider,
    MatMenuItem,
    FormsModule,
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
})
export class HeaderComponent {
  busyService = inject(BusyService);
  accountService = inject(AccountService);
  private router = inject(Router);
  cartService = inject(CartService);
  courseService = inject(CourseService);
  @ViewChild('searchInput') searchInput!: ElementRef;

  onSearchChange() {
    this.courseService.getCourseWithParameters().subscribe({
      next: () => {
        this.courseService.courseParams.update((params) => {
          params.pageNumber = 1;

          return params;
        });
        this.searchInput.nativeElement.value = '';
      },
    });
  }

  logout() {
    this.accountService.logout().subscribe({
      next: () => {
        this.accountService.currentUser.set(null);
        this.router.navigateByUrl('/');
      },
    });
  }
}
