import { Component, inject } from '@angular/core';
import { NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { VgBufferingModule } from '@videogular/ngx-videogular/buffering';
import { VgControlsModule } from '@videogular/ngx-videogular/controls';
import { VgApiService, VgCoreModule, VgFullscreenApiService } from '@videogular/ngx-videogular/core';
import { VgOverlayPlayModule } from '@videogular/ngx-videogular/overlay-play';

@Component({
  selector: 'app-course-view',
  imports: [VgCoreModule,
      VgControlsModule,
      VgOverlayPlayModule,
      VgBufferingModule,
      NgbNavModule
    ],
  templateUrl: './course-view.component.html',
  styleUrl: './course-view.component.css'
})
export class CourseViewComponent {





  preloadText = 'auto';
  api!: VgApiService;
  private fullscreenApi: VgFullscreenApiService = inject(
    VgFullscreenApiService
  );
  private videoElement!: HTMLVideoElement;
  videoUrl="http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4";

get videoClass(){
  return this.api.fsAPI.isFullscreen ? '' : 'px-50 ';
}
  onPlayerReady($event: VgApiService) {
    this.api = $event;
    this.api.getDefaultMedia().subscriptions.canPlay.subscribe(() => {
      this.api.play();
      //intialze fullscreen api
    });
  }

  toggleFullscreen() {
    this.api.fsAPI.toggleFullscreen();

  }

  //navbar
  active: number = 1;

   tabClass(tabeNumber: number): string {
    let baseClass="text-slate-700! tw-pb-[14px]! tw-border-b-2! hover:tw-text-slate-900! hover:tw-border-slate-300!";
    if (this.active === tabeNumber) {
      console.log("active", this.active);

      return "text-slate-900! font-semibold! pb-[14px]! border-b-2! border-slate-800!";
    } else {
      console.log("active", this.active);
      return "text-slate-700! hover:text-slate-900! pb-[14px]! border-b-2! border-transparent! hover:border-slate-300!";
    }
  }



}
