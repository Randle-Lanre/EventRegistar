import { Component, OnInit } from '@angular/core';
import {OAuthService} from 'angular-oauth2-oidc';
import {authCodeFlowConfig } from '../config/authCodeFlowConfig';
import { Router} from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  claims;
  constructor( private oauthservice: OAuthService, private router: Router) { }

  ngOnInit(): void {
    this.configSso();
  }

  configSso(){
    this.oauthservice.configure(authCodeFlowConfig);
    this.oauthservice.loadDiscoveryDocumentAndTryLogin();
  }

  login(){
    console.log('login');
    this.oauthservice.setupAutomaticSilentRefresh();
    this.oauthservice.initCodeFlow();

  }

  logout(){
    console.log('logout');
    this.oauthservice.logOut();

  }

  get token(){
    this.claims = this.oauthservice.getIdentityClaims();
    if(this.claims){
      console.log('---login claims---', this.claims);
      this.router.navigateByUrl('form');
    }
    return this.claims ? this.claims : null
  }

}
