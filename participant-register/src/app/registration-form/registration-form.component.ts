import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Registar } from '../Services/registar';
import { RegistarServiceService } from '../Services/registar-service.service';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css'],
})
export class RegistrationFormComponent implements OnInit {
  constructor(
    private fb: FormBuilder,
    private registarService: RegistarServiceService
  ) {}

  userRegistrationForm = this.fb.group({
    FirstName: ['', Validators.required],
    LastName: ['', Validators.required],
    ParticipantComment: ['', Validators.required],

  });

  onSubmit() {
    this.registarService.addUserToRegistar(this.userRegistrationForm.value).subscribe(
      (res) => {
        this.userRegistrationForm.reset();
      },

      (err) => {
        console.log(err);
      }
    );

    // console.log(this.userRegistrationForm.value)
    //  // this.addUserToRegistar(userRegistrationInfo)
    //   window.alert('form submitted');
  }

  //  add(registryEntry: string): void{
  //    this.
  //  }

  ngOnInit(): void {}
}
