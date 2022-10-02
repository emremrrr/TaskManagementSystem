import { User } from "./user.model"

export class TaskModel{
    public id:number | undefined
    public requiredDate:Date | undefined
    public taskDescription:string | undefined
    public taskStatus!: TaskStatus
    public nextActionDate:Date | undefined
    public user:any | undefined

}

export enum TaskStatus{
    Created,
    InProgress,
    Reviewed,
    Done
}