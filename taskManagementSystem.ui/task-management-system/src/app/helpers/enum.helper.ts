import { Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { CommentType } from '../models/comment.model';
import { TaskStatus } from '../models/task.model';
import { TaskType } from '../models/taskdetail.model';


@Injectable({
  providedIn: 'root'
})


export class EnumHelper
{
    constructor(){

    }

    
  getTaskStatus(index:number):string{
    return TaskStatus[index]
  }
  getTaskType(index:number):string{
    return TaskType[index]
  }
  getCommentType(index:number):string{
    return CommentType[index]
  }
  getCommentTypes(){
    var enumNames=[];
    for(var i=0;i<Object.keys(CommentType).length/2;i++){
      enumNames.push({key:CommentType[i],value:i});
    }
    return enumNames
  }
}