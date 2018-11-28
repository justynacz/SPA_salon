import { Component, OnInit } from '@angular/core';
import { RolesService } from '../api/services';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Role } from '../api/models';
import { RoleNewComponent } from './role-new/role-new.component';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.css']
})
export class RolesComponent implements OnInit {

  roleList: Role[]=[];
  bsModalRef: BsModalRef;
  constructor(
    private roleService: RolesService,
    private modalService: BsModalService
  ) { }

  async ngOnInit() {
    this.roleList = await this.roleService.GetRoles().toPromise();
  }

  openNewRoleModal() {
    this.bsModalRef = this.modalService.show(RoleNewComponent);
    this.bsModalRef.content.editedRole = false;
  }

  async editRole(id: number){
    let roleToEdit: Role;
    roleToEdit = await this.roleService.GetRole(id).toPromise();
    const initialState = {
      roleToEdit:roleToEdit,
      editedRole: true
    };
    this.bsModalRef = this.modalService.show(RoleNewComponent, {initialState});
  }
}
