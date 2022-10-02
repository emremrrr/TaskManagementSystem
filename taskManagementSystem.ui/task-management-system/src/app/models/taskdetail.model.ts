import { TaskModel } from "./task.model"

export class TaskDetailModel extends TaskModel{
    public taskType!:TaskType
    public comments:any | undefined 
}

export enum TaskType{
    Analysis,
    Development,
    Bugfix,
    Test,
    Documentation
}