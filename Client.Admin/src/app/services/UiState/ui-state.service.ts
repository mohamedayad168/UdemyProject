import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UiStateService {
  sideNavOpen = signal(false)
  



  toggleSideNav() {
    this.sideNavOpen.update(value => !value)
  }

  closeSideNav() {
    this.sideNavOpen.set(false)
  }

}
