import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';


@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent implements OnInit {

  constructor(private fb: FormBuilder) { }

   userRegistrationForm = this.fb.group({
     firstName: [''],
     lastname: [''],
     userComment: ['']
   })

  ngOnInit(): void {
    
  }

}
