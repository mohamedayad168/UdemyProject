import { PowerBiReportsService } from './../../lib/services/PowerBi/power-bi-reports.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-instructor-report',
  imports: [],
  templateUrl: './instructor-report.component.html',
  styleUrl: './instructor-report.component.css',
})
export class InstructorReportComponent {
  constructor(private biService: PowerBiReportsService) {
    this.instructorReport = this.biService.getInstructorReportUrl();
  }
  instructorReport: string | null = null;
}
