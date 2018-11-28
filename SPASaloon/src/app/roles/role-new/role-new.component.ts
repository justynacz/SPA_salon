import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RolesService } from 'src/app/api/services';
import { ToastrService } from 'ngx-toastr';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { NewRoleModel, Role } from 'src/app/api/models';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-role-new',
  templateUrl: './role-new.component.html',
  styleUrls: ['./role-new.component.css']
})
export class RoleNewComponent implements OnInit {

  editedRole: boolean = false;
  roleToEdit: Role;
  newRoleForm: FormGroup;
  roleFormValue: NewRoleModel;
  constructor(
    public bsModalRef: BsModalRef,
    private roleService: RolesService,
    private fb: FormBuilder,
    private toastr: ToastrService) {
    this.createForm();
   }
  
  ngOnInit(){
    if(!this.editedRole) return;
    this.newRoleForm.patchValue(this.roleToEdit);
  }

  saveRole(){
    this.roleFormValue = this.newRoleForm.value;
    if(this.editedRole)
      this.saveEditedRole();
    else
      this.saveNewRole();
  }
  saveNewRole(){
    this.roleService.CreateRole(this.roleFormValue).toPromise()
    .then( () =>{ 
      this.toastr.success('Dodano nową rolę');
      this.bsModalRef.hide();
    })
    .catch( () => this.toastr.error('Nie udało się dodać roli')
    );
  }

  saveEditedRole(){
    this.roleToEdit.name = this.roleFormValue.name;
    this.roleToEdit.description = this.roleFormValue.description;
    let updateParams: RolesService.UpdateRoleParams;
    updateParams = { 
      id: this.roleToEdit.roleId, 
      role: this.roleToEdit
    }
    this.roleService.UpdateRole(updateParams).toPromise()
    .then( () =>{ 
      this.toastr.success('Zaktualizowano rolę');
      this.bsModalRef.hide();
    })
    .catch( () => this.toastr.error('Nie udało się zaktualizować roli')
    );
  }
  
  private createForm(){
    this.newRoleForm = this.fb.group({
      name: [null, Validators.required],
      description: [null]
    });
  }

}
