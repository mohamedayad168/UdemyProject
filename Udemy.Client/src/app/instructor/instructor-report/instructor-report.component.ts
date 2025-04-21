import { DomSanitizer } from '@angular/platform-browser';
import { PowerBiReportsService } from './../../lib/services/PowerBi/power-bi-reports.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-instructor-report',
  imports: [],
  templateUrl: './instructor-report.component.html',
  styleUrl: './instructor-report.component.css',
})
export class InstructorReportComponent {
  constructor(private biService: PowerBiReportsService,private sanitizer: DomSanitizer) {
    const instructorReportUrl = this.biService.getInstructorReportUrl()!;
    console.log('Instructor Report URL:', instructorReportUrl);

    const trustedUrl = this.sanitizer.bypassSecurityTrustResourceUrl(instructorReportUrl);
    this.instructorReport = trustedUrl as string;
  }
  instructorReport: string | null = null;
}
