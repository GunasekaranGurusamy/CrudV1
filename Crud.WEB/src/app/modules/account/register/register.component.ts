import { Component, OnInit } from '@angular/core';
import { NgFor, NgIf } from '@angular/common';
import { HttpStatusCode } from '@angular/common/http';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { user } from '../../../models/user';
import { UserService } from '../../../services/user.service';

@Component({
  selector: 'register',
  standalone: true,
  imports: [NgFor, NgIf, ReactiveFormsModule],
  templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {
  userList: user[] = [];
  userFormGroup: FormGroup;

  constructor(private userService: UserService, private fb: FormBuilder) {
    this.userFormGroup = this.fb.group({
      usr_Id: 0,
      usr_Name: [""],
      usr_Password: [""],
      usr_Email: [""],
      usr_Role: [""],
      usr_isActive: true
    });
  }
  ngOnInit(): void {
    this.get();
  }

  get() {
    this.userService.Get().subscribe(response => {
      this.userList = response;
    });
  }

  edit(Id: number) {
    this.userService.Edit(Id).subscribe(resp => {
      this.userFormGroup.setValue({
        usr_Id: resp.usr_Id,
        usr_Name: resp.usr_Name,
        usr_Email: resp.usr_Email,
        usr_Password: resp.usr_Password,
        usr_Role: resp.usr_Role,
        usr_isActive: resp.usr_isActive
      });
    });
  }

  delete(item: user) {
    this.userService.Delete(item.usr_Id).subscribe(resp => {
      if (resp.status == HttpStatusCode.Ok) {
        var index = this.userList.indexOf(item);
        this.userList.splice(index, 1);
      }
    });
  }

  onSubmit() {
    if (this.userFormGroup.get("usr_Id")?.value > 0) {
      this.userService.Update(this.userFormGroup.value).subscribe(response => {
        this.get();
      });
    }
    else {
      this.userService.Create(this.userFormGroup.value).subscribe(response => {
        this.userList.push(response);
      });
    }
    this.formReset()
  }

  formReset() {
    this.userFormGroup.setValue({
      usr_Id: 0,
      usr_Name: [""],
      usr_Password: [""],
      usr_Email: [""],
      usr_Role: [""],
      usr_isActive: true
    })
  }
}
