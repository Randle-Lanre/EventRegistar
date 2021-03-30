import { Component, OnInit } from '@angular/core';
import { RegistarServiceService } from '../Services/registar-service.service';
import { Participants } from '../Services/participants';
import { Observable } from 'rxjs';
import { faUserMinus } from '@fortawesome/free-solid-svg-icons';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-registerlist',
  templateUrl: './registerlist.component.html',
  styleUrls: ['./registerlist.component.css'],
})
export class RegisterlistComponent implements OnInit {
  // TODO: use a different type to fecth from Db, change in service also

  participants: Participants;
  faUsers = faUserMinus;
  numbering: number;

  constructor(
    public registarService: RegistarServiceService,
    private toaster: ToastrService
  ) {}

  ngOnInit(): void {
    this.registarService.getListOfParticipants();
    console.log(this.registarService.getListOfParticipants());
    // this.listAllParticipants();
   // this.numbering;
  }

  onDelete(id: number) {
    if (confirm('DO you really want to delete this record')) {
      this.registarService.deleteAParticipant(id).subscribe(
        (res) => {
          this.toaster.error('Deletion successful', 'Notification');
          this.registarService.getListOfParticipants(); //refresh list

          //refresh list and show toast notification
        },
        (err) => {
          console.log(err);
        }
      );
    }
  }
}
