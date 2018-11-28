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
    // const initialState = {
    //   list: [
    //     'Open a modal with component',
    //     'Pass your data',
    //     'Do something else',
    //     '...'
    //   ],
    //   title: 'Modal with component'
    // };
    this.bsModalRef = this.modalService.show(OfferNewComponent);
    //this.bsModalRef.content.closeBtnName = 'Close';
  }
}
