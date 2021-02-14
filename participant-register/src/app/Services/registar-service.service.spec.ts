import { TestBed } from '@angular/core/testing';

import { RegistarServiceService } from './registar-service.service';

describe('RegistarServiceService', () => {
  let service: RegistarServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RegistarServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
