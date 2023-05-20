import { Component, OnInit } from '@angular/core';
import { AccountService } from '../services/account.service';
import { Observable, of } from 'rxjs';
import { User } from '../models/user';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model : any = {
  }
  currentUser$ : Observable<User | null> = of(null);


  // loggedIn = false;


  /*
  constructor( private accountService : AccountService) {
    }
  */
    constructor( public accountService : AccountService) {

    }


    ngOnInit(): void {
    //here we're optimising the methods of subscribing in the lifecycle hooks
    // this.getCurrentUser();
    // this.currentUser$ = this.accountService.currentUser$;
    }
    
      // not needed this function now
      // getCurrentUser(){
      //   this.accountService.currentUser$.subscribe(
      //     {
      //       next: user => this.loggedIn = !! user,
      //       //double exclamationmarks are used to convert value of "user" to boolean type
      //       //In simpler terms, the expression this.loggedIn = !!user can be read as "assign the boolean value true to this.loggedIn if user is truthy, otherwise assign the boolean value false". It provides a concise way to convert a truthy/falsy value into a boolean value.
      //       error:error => console.log(error)
      //     }
      //   )
      // }

      login =()=>{
        this.accountService.login(this.model).subscribe({
          next: response => {
            console.log(response)
          },
          error : error => console.log(error)
        })
      }
        //incase of http request it's not neccessariy to unsubscribe  but in case of own observables we have to unsubscribe it , we can do that with async pipe
      logout = () =>{
      
        this.accountService.logout();
         
      }

}
