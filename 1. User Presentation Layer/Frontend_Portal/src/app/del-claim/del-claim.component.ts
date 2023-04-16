import { Component, OnInit } from '@angular/core';
import {AppServiceService} from '../app-service.service';
import {Router} from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-del-claim',
  templateUrl: './del-claim.component.html',
  styleUrls: ['./del-claim.component.css']
})
export class DelClaimComponent implements OnInit {
  id:any

  constructor(private service:AppServiceService, private router:Router,private _activatedRoute:ActivatedRoute) { }

  ngOnInit(): void {
    this._activatedRoute.paramMap.subscribe(params => { 
      this.id = params.get('id'); 
    });
  }

}
