import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { RolesService, OffersService } from 'src/app/api/services';
import { Role, NewOfferModel, Offer } from 'src/app/api/models';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-offer-new',
  templateUrl: './offer-new.component.html',
  styleUrls: ['./offer-new.component.css']
})
export class OfferNewComponent implements OnInit {

  newOfferForm: FormGroup;
  roleList: Role[];
  editedOffer: boolean = false;
  offerToEdit: Offer;
  offerFormValue: NewOfferModel;

  constructor(
    public bsModalRef: BsModalRef,
    private roleService: RolesService,
    private offerService: OffersService,
    private fb: FormBuilder,
    private toastr: ToastrService) {
      this.createForm();
    }
 
  async ngOnInit() {
    this.roleList = await this.roleService.GetRoles().toPromise();
    if(!this.editedOffer) return;
    this.newOfferForm.patchValue(this.offerToEdit);
  }
  saveOffer(){
    this.offerFormValue = this.newOfferForm.value;
    if(this.editedOffer)
      this.saveEditedOffer();
    else
      this.saveNewOffer();
  }

  saveNewOffer(){
    this.offerService.CreateOffer(this.offerFormValue).toPromise()
    .then( () =>{ 
      this.toastr.success('Dodano nową ofertę');
      this.bsModalRef.hide();
    })
    .catch( () => this.toastr.error('Nie udało się dodać oferty')
    );
  }

  saveEditedOffer(){
    this.offerToEdit.name = this.offerFormValue.name;
    this.offerToEdit.description = this.offerFormValue.description;
    let updateParams: OffersService.UpdateOfferParams;
    updateParams = { 
      id: this.offerToEdit.offerId, 
      offer: this.offerToEdit
    }
    this.offerService.UpdateOffer(updateParams).toPromise()
    .then( () =>{ 
      this.toastr.success('Zaktualizowano ofertę');
      this.bsModalRef.hide();
    })
    .catch( () => this.toastr.error('Nie udało się zaktualizować oferty')
    );
  }
  
  private createForm(){
    this.newOfferForm = this.fb.group({
      name: [null, Validators.required],
      description: [null],
      roleId: [null, Validators.required]
    });
  }
}
