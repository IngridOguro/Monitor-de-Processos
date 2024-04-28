import { TestBed } from '@angular/core/testing';

import { ProcessesServiceService } from './processes.service.service';

describe('ProcessesServiceService', () => {
  let service: ProcessesServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProcessesServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
