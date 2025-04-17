import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ScrollService {
  mainScroll = window.scrollY;
  isDown = signal(false);

  onScroll(currentScrollTop: number) {
    //if scroll direction change
    if (currentScrollTop > this.mainScroll + 60) {
      this.isDown.set(true);
      this.mainScroll = currentScrollTop;
    } else if (currentScrollTop < this.mainScroll - 60) {
      this.isDown.set(false);
      this.mainScroll = currentScrollTop;
    }
  }
}
