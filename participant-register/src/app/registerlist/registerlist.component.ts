import { Component, OnInit } from '@angular/core';
import { RegistarServiceService } from '../Services/registar-service.service';
import { Participants} from '../Services/participants'

@Component({
  selector: 'app-registerlist',
  templateUrl: './registerlist.component.html',
  styleUrls: ['./registerlist.component.css']
})
export class RegisterlistComponent implements OnInit {

  // TODO: use a different type to fecth from Db, change in service also

  participants: Participants[];

  constructor(private registarService: RegistarServiceService) { }

  ngOnInit(): void {
    
  }

  listAllParticipants(): void{
    this.registarService.getListOfParticipants().subscribe(participants => (this.participants=participants));
  }

}
