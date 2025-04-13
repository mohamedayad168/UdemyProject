import { Component, ElementRef, inject, input, ViewChild } from '@angular/core';
import { CourseSearch } from '../../lib/models/course-search';
import { CurrencyPipe } from '@angular/common';
import {
  NgbPopover,
  NgbPopoverModule,
  NgbRatingModule,
} from '@ng-bootstrap/ng-bootstrap';
import { Router, RouterLink } from '@angular/router';
import { MatButton } from '@angular/material/button';
import { CartService } from '../../lib/services/cart/cart.service';
import { SnackbarService } from '../../lib/interceptors/snackbar.service';
import { AccountService } from '../../lib/services/account.service';
// import { CourseSearchItemPopoverComponent } from '../course-search-item-popover/course-search-item-popover.component';

@Component({
  selector: 'app-course-search-item',
  imports: [
    CurrencyPipe,
    NgbRatingModule,
    NgbPopoverModule,
    RouterLink,
    MatButton,
  ],
  templateUrl: './course-search-item.component.html',
  styleUrl: './course-search-item.component.css',
})
export class CourseSearchItemComponent {
  private cartService = inject(CartService);
  private accountService = inject(AccountService);
  course = input.required<CourseSearch>();
  router = inject(Router);
  @ViewChild('popover') popover!: NgbPopover;
  @ViewChild('popoverContainer') popoverContainer!: ElementRef;

  private closeTimer: any;

  onClick() {
    this.router.navigateByUrl(`courses/${this.course().id}`);
  }

  addCourseToCart() {
    if (this.accountService.currentUser()) {
      this.cartService.addCourseToStudentCart(this.course().id);
    } else {
      this.router.navigateByUrl('login');
    }
  }

  openPopover() {
    this.cancelClose();
    if (!this.popover.isOpen()) {
      this.popover.open();
    }
  }

  startCloseTimer() {
    this.cancelClose();
    this.closeTimer = setTimeout(() => {
      if (this.popover.isOpen()) {
        this.popover.close();
      }
    }, 50); // Minimal delay for smooth transition
  }

  cancelClose() {
    if (this.closeTimer) {
      clearTimeout(this.closeTimer);
    }
  }

  onContainerLeave() {
    // Only close if mouse isn't over popover content
    if (!document.querySelector('.popover')?.contains(event?.target as Node)) {
      this.startCloseTimer();
    }
  }
}
