import { Component, OnInit } from '@angular/core';
import { OffersService } from '../api/services';
import { Offer } from '../api/models';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { OfferNewComponent } from './offer-new/offer-new.component';

@Component({
  selector: 'app-offers',
  templateUrl: './offers.component.html',
  styleUrls: ['./offers.component.css']
})
export class OffersComponent implements OnInit {

  offerList: Offer[]=[];
  bsModalRef: BsModalRef;
  constructor(
    private offerService: OffersService,
    private modalService: BsModalService) { }

  async ngOnInit() {
    this.offerList = await this.offerService.GetOffers().toPromise();
  }

  openNewOfferModal() {
    this.bsModalRef = this.modalService.show(OfferNewComponent);
  }
}
