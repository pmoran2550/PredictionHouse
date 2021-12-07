import { TestBed } from '@angular/core/testing';

import { RespondentsService } from './respondents-service.service';

describe('RespondentsService', () => {
  let service: RespondentsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RespondentsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
