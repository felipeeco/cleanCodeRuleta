import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

@Component({
  selector: 'app-ruleta',
  templateUrl: './ruleta.component.html',
  styleUrls: ['./ruleta.component.css']
})
export class RuletaComponent implements OnInit {
  formLogin: FormGroup;
  showBottons: boolean = true;
  showForm: boolean = false;
  betColor: boolean = true;
  constructor(private userService: UserService, private router: Router) {
    this.formLogin = new FormGroup
      ({
        'number': new FormControl(0),
        'money': new FormControl(0)
      });
  }
  ngOnInit() {
  }
  functionBetColor() {
    this.showBottons = false;
    this.showForm = true;
  }
  functionBetNumber() {
    this.showBottons = false;
    this.showForm = true;
    this.betColor = false;
  }
}
