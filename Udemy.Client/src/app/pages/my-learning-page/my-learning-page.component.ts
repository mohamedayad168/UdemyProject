import { Component, inject } from '@angular/core';
import { NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { PowerBiReportsService } from '../../lib/services/PowerBi/power-bi-reports.service';
import { DomSanitizer } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-my-learning-page',
  imports: [NgbNavModule, CommonModule],

  templateUrl: './my-learning-page.component.html',
  styleUrl: './my-learning-page.component.css'
})
export class MyLearningPageComponent {
  powerBiService = inject(PowerBiReportsService);
  private santaizer = inject(DomSanitizer);
  powerBiUrl: string | null = null;

  activeTab = 1;

  ngOnInit() {
    // Initialize the component and set the active tab to 1
    this.activeTab = 1;
    const url = this.powerBiService.getCurrentUserReportUrl();
    //add the url to the trusted url list
    if (url) {
      const trustedUrl = this.santaizer.bypassSecurityTrustResourceUrl(url);
      console.log('Power BI URL:', url);
      this.powerBiUrl = trustedUrl as string;
    } else {
      console.error('Power BI URL is null or undefined.');
    }
  }
}
