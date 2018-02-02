import { TestBed, inject } from '@angular/core/testing';

import { BootstrapmodalService } from './bootstrapmodal.service';

describe('BootstrapmodalService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BootstrapmodalService]
    });
  });

  it('should be created', inject([BootstrapmodalService], (service: BootstrapmodalService) => {
    expect(service).toBeTruthy();
  }));
});
