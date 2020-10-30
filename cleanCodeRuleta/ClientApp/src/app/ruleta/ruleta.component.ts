import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-ruleta',
  templateUrl: './ruleta.component.html',
  styleUrls: ['./ruleta.component.css']
})
export class RuletaComponent implements OnInit {

  formLogin: FormGroup;

  constructor(private userService: UserService, private router: Router) {
    this.formLogin = new FormGroup
      ({
        'number': new FormControl(0, [Validators.max(36)]),
        'money': new FormControl("", [Validators.max(10000)])
      });
  }

  ngOnInit() {
  }

}
