import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { RolesService, OffersService } from 'src/app/api/services';
import { Role, NewOfferModel } from 'src/app/api/models';
import { FormBuilder, FormGroup } from '@angular/forms';


@Component({
  selector: 'app-offer-new',
  templateUrl: './offer-new.component.html',
  styleUrls: ['./offer-new.component.css']
})
export class OfferNewComponent implements OnInit {

  newOfferForm: FormGroup;
  roleList: Role[];
 
  constructor(
    public bsModalRef: BsModalRef,
    private roleService: RolesService,
    private offerService: OffersService,
    private fb: FormBuilder) {
      this.createForm();
    }
 
  async ngOnInit() {
    this.roleList = await this.roleService.GetRoles().toPromise();
  }
  saveOffer(){
    let newOffer: NewOfferModel;
    newOffer = this.newOfferForm.value;
    console.log('sub');
    this.offerService.CreateOffer(newOffer).toPromise()
    .then( () => console.log("Dodano ofertę"))
    .catch( () => console.log("Dodawanie oferty nie powiodło się"));
  }
  
  private createForm(){
    this.newOfferForm = this.fb.group({
      name: [''],
      description: [''],
      roleId: [0]
    });
  }


}
