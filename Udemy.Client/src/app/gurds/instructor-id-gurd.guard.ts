import { CanActivateFn } from '@angular/router';

export const instructorIdGurdGuard: CanActivateFn = (route, state) => {
  return true;
};
