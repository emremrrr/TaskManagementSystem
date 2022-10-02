import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EnumHelper } from 'src/app/helpers/enum.helper';
import { TaskModel, TaskStatus } from 'src/app/models/task.model';
import { TaskService } from 'src/app/services/task.service';

@Component({
  selector: 'task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {

  public tasks:TaskModel[] | undefined
  constructor(
    private taskService:TaskService,
    private router:Router,
    public enumHelper:EnumHelper) {
    
    taskService.GetTasks().subscribe((p:TaskModel[])=>{
      this.tasks=p;
    });
   }
  getTask(id:any){

    this.taskService.GetTask(id).subscribe(p=>{

      this.router.navigate(['taskdetail',id]);
    });
  }

  ngOnInit(): void {
  }

}
