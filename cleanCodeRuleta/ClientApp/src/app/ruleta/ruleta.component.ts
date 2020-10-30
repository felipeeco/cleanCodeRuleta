import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, ValidatorFn, AbstractControl } from '@angular/forms';
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
  showResult: boolean = false;
  betColor: boolean = true;
  formNumberMax: boolean = false;
  formMoneyMax: boolean = false;
  finalResult: any;
  constructor(private userService: UserService, private router: Router) {
    this.formLogin = new FormGroup
      ({
        'number': new FormControl(0, [Validators.required, Validators.max(36)]),
        'money': new FormControl(0, [Validators.required, Validators.max(10000)]),
        'color': new FormControl(false)
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
  submit(){
    this.formLogin.controls["color"].setValue(this.betColor);
    if (this.formLogin.valid == true) {
      this.userService.saveData(this.formLogin.value).subscribe((data: any) => {
        this.showForm = false;
        this.showResult = true;
        this.finalResult = data;
      });
    }
  }
  refresh() {
    this.showBottons = true;
    this.showForm = false;
    this.showResult = false;
    this.formLogin.controls["number"].setValue(0);
    this.formLogin.controls["money"].setValue(0);
    this.betColor = true;
  }
}
