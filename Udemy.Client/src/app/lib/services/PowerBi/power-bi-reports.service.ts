import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { AccountService } from '../account.service';

@Injectable({
  providedIn: 'root',
})
export class PowerBiReportsService {
  // Define the base URL for the Power BI API
  private powerBiApiUrl = environment.powerbiReportUrl;
  private accoutService: AccountService;
  constructor(accountService: AccountService) {
    this.accoutService = accountService;
  }

  getCurrentUserReportUrl(): string | null {
    // Get the current user's report URL from the environment variables
    const currentUser = this.accoutService.currentUser;
    console.log('Current user:', currentUser());
    const reportUrl =
      this.powerBiApiUrl +
      "&$filter=DIMStudents/StudentsId eq '" +
      currentUser()?.id +
      "'";
    return reportUrl;
  }
  getInstructorReportUrl(): string | null {
    // Get the current user's report URL from the environment variables
    const powerBiApiUrl = environment.instructorReportUrl;
    const currentUser = this.accoutService.currentUser;
    console.log('Current user:', currentUser());
    const reportUrl =
    powerBiApiUrl +
      "&$filter=DimInstructor/Id eq '" +
      currentUser()?.id +
      "'";
    return reportUrl;
  }



}
