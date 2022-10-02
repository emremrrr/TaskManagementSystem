import { Comment } from '@angular/compiler';
import { Component, OnInit,Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { parse } from 'path';
import { EnumHelper } from 'src/app/helpers/enum.helper';
import { NavHelper } from 'src/app/helpers/nav.helper';
import { CommentModel, CommentType } from 'src/app/models/comment.model';
import { TaskDetailModel } from 'src/app/models/taskdetail.model';
import { TaskService } from 'src/app/services/task.service';

@Component({
  selector: 'taskdetail',
  templateUrl: './task-detail.component.html',
  styleUrls: ['./task-detail.component.css']
})

@Injectable({ providedIn: "root" })
export class TaskDetailComponent implements OnInit {

  private id:any;
  public taskDetail!: TaskDetailModel;
  public comments!:CommentModel[] ;
  public commentModal: CommentModel=new CommentModel;
  public commentText:string="" 
  public reminderDate:any =""
  public commentType:CommentType=99 
  public searchText:string="";
  constructor(
    private router:Router,
    private route:ActivatedRoute,
    private taskService:TaskService,
    public enumHelper:EnumHelper,
    public navHelper:NavHelper) {
      this.id=route.snapshot.paramMap.get('id');
      this.getTask();
   }
   getTask(){
    this.taskService.GetTask(this.id).subscribe(t=>{
      this.taskDetail=t;
      this.comments=t.comments;
    });
   }
   editComment(comment?:any){
    this.commentModal=comment;
    this.commentText=comment.commentText;
    var dt=new Date(comment.reminderDate)
    dt.setMinutes(dt.getMinutes() - dt.getTimezoneOffset());
    this.reminderDate=dt.toISOString().slice(0,16);
    this.commentType=comment.commentType;
   }
   cancelEdit(){
    this.commentModal=new CommentModel;
    this.commentText="";
    var dt=new Date()
    dt.setMinutes(dt.getMinutes() - dt.getTimezoneOffset());
    this.reminderDate=dt.toISOString().slice(0,16);
    this.commentType=99;
   }
   upsertComment(){
    this.commentModal.commentText= this.commentText
    this.commentModal.reminderDate= this.reminderDate
    this.commentModal.commentType= this.commentType
    this.commentModal.createdBy= this.commentModal?.user?.id
    if(this.commentModal.createdBy==undefined)
      this.commentModal.createdBy=JSON.parse(localStorage['auth']).Id;
    if(this.commentModal.created==undefined)
      this.commentModal.created=new Date();
    this.taskService.UpsertComment(this.id,this.commentModal).subscribe(p=>{
      this.taskService.GetTask(this.id).subscribe(t=>{
        this.taskDetail=t;
        this.comments=t.comments;
      });
    })
   }

   search(){
    this.taskService.SearchComments(this.id,this.searchText).subscribe(p=>{
      this.comments=p
    });
   }
   deleteComment(commentId:any){
    if(confirm("Are you sure you want to delete the comment?"))
      this.taskService.DeleteComment(this.id,commentId).subscribe(p=>
        {
          alert("comment deleted!");
          this.getTask();
        })
   }
  ngOnInit(): void {
  }

}
