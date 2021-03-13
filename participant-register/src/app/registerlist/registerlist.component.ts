import { Component, OnInit } from '@angular/core';
import { RegistarServiceService } from '../Services/registar-service.service';
import { Registar} from '../Services/registar'

@Component({
  selector: 'app-registerlist',
  templateUrl: './registerlist.component.html',
  styleUrls: ['./registerlist.component.css']
})
export class RegisterlistComponent implements OnInit {

  // TODO: use a different type to fecth from Db, change in service also

  participants: Registar[];

  constructor(private registarService: RegistarServiceService) { }

  ngOnInit(): void {
  }

  listAllParticipants(): void{
    this.registarService.getListOfParticipants().subscribe(participants => (this.participants=participants));
  }

}
