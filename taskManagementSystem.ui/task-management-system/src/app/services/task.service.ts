import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthModel } from '../models/auth.model';
import { CommentModel } from '../models/comment.model';


@Injectable({
  providedIn: 'root'
})


export class TaskService
{
    baseurl: string = environment.baseUrl;
    constructor(private http: HttpClient)
    {

    }

    GetTasks(): Observable<any>
    {
      return this.http.get(this.baseurl + "Tasks");
    }
    GetTask(id:any): Observable<any>
    {
      return this.http.get(this.baseurl + "Tasks/"+id);
    }

    UpsertComment(id:any,comment:any){
      return this.http.post(this.baseurl + "Tasks/"+id+"/comments",comment);
    }

    DeleteComment(id:any,commentId:any): Observable<any>
    {
      return this.http.delete(this.baseurl + "Tasks/"+id+"/comments/"+commentId);
    }
        
    SearchComments(id:any,text:any){
      return this.http.get<CommentModel[]>(this.baseurl + "Tasks/"+id+"/comments/search/"+text);
    }
}