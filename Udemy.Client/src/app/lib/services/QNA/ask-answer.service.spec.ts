import { TestBed } from '@angular/core/testing';

import { AskAnswerService } from './ask-answer.service';

describe('AskAnswerService', () => {
  let service: AskAnswerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AskAnswerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
