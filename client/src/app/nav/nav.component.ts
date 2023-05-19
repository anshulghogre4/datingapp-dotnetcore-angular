import { Component, OnInit } from '@angular/core';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model : any = {

  }

  loggedIn = false;


    constructor( private accountService : AccountService) {

    }

  ngOnInit(): void {
    this.getCurrentUser();
  }
      getCurrentUser(){
        this.accountService.currentUser$.subscribe(
          {
            next: user => this.loggedIn = !! user,
            //double exclamationmarks are used to convert value of "user" to boolean type
            //In simpler terms, the expression this.loggedIn = !!user can be read as "assign the boolean value true to this.loggedIn if user is truthy, otherwise assign the boolean value false". It provides a concise way to convert a truthy/falsy value into a boolean value.
            error:error => console.log(error)
          }
        )
      }

      login =()=>{
        this.accountService.login(this.model).subscribe({
          next: response => {
            console.log(response),
            this.loggedIn = true;
          },
          error : error => console.log(error)
        })
      }

      logout = () =>{
      
        this.accountService.logout();
        this.loggedIn =false;
      }

}
