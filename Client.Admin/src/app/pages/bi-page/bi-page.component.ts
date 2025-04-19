import { Component, ElementRef, viewChild } from '@angular/core';
import { AfterViewInit } from '@angular/core';
@Component({
  selector: 'app-bi-page',
  imports: [],
  templateUrl: './bi-page.component.html',
  styleUrl: './bi-page.component.scss'
})
export class BiPageComponent  {
  iframe = viewChild<ElementRef<HTMLIFrameElement>>('iframe')
  // reStyle(iframe: HTMLIFrameElement) {
  //   let myScript = 'iframe.body.style.background = "blue"';
  //   console.log(eval(myScript));
  // }
  

  // ngAfterViewInit(){
  //   this.iframe()!.nativeElement.onload = () => this.reStyle(this.iframe()!.nativeElement);

  // }
}
