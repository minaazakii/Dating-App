import { AccountService } from '../_services/account.service';
import { Component, Input, OnInit, Output ,EventEmitter } from '@angular/core';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  @Output() cancelRegiseter = new EventEmitter();

  model:any ={};

  constructor(private accountService: AccountService,
    private toaster: ToastrService) { }

  ngOnInit(): void {
  }

  register()
  {
    this.accountService.register(this.model)
    .subscribe(response =>
      {
        console.log(response)
        this.cancel()

      } ,error =>
      {
        this.toaster.error(error.error)
        console.log(error)
      })
  }

  cancel()
  {
   this.cancelRegiseter.emit(false);
  }
}
