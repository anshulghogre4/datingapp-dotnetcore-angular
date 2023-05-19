import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { timeout } from 'rxjs';
import { AccountService } from './services/account.service';
import { User } from './models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'Dating App';
  users: any;

  constructor(private http: HttpClient, private accountServices: AccountService ) {}

  ngOnInit(): void {
    this.getUsers();
    this.setCurrentUser();
  }

  getUsers(){
    this.http.get('https://localhost:5001/api/users').subscribe({
      next: (response) => (this.users = response),
      error: (error) => console.log(error),
      complete: () => console.log('Request Completed'),
    });
  }

  setCurrentUser(){
      //  const user:User = JSON.parse(localStorage.getItem('user')!); this will do the work as well here typescript will involve
      // so "!" mark turns off typescript saftey
      const  userString  = localStorage.getItem('user');
      if(!userString) return;
      const user:User = JSON.parse(userString);
      //getting setCurrentUser(user) from account service
      this.accountServices.setCurrentUser(user);
  }


}
