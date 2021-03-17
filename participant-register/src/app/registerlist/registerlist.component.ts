import { Component, OnInit } from '@angular/core';
import { RegistarServiceService } from '../Services/registar-service.service';
import { Participants} from '../Services/participants'
import { Observable } from 'rxjs';

@Component({
  selector: 'app-registerlist',
  templateUrl: './registerlist.component.html',
  styleUrls: ['./registerlist.component.css']
})
export class RegisterlistComponent implements OnInit {

  // TODO: use a different type to fecth from Db, change in service also

  participants:  Participants;

  constructor(public registarService: RegistarServiceService) { }

  ngOnInit(): void {
    this.registarService.getListOfParticipants();
    console.log(this.registarService.getListOfParticipants())
    // this.listAllParticipants();

  }





}
