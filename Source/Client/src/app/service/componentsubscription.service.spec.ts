import { TestBed, inject } from '@angular/core/testing';

import { ComponentSubscriptionService } from './componentsubscription.service';

describe('ComponentSubscriptionService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
        providers: [ComponentSubscriptionService]
    });
  });

    it('should be created', inject([ComponentSubscriptionService], (service: ComponentSubscriptionService) => {
    expect(service).toBeTruthy();
  }));
});
