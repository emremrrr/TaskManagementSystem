import { User } from "./user.model"

export class CommentModel{
    public id:number | undefined
    public commentText:string | undefined
    public commentType!:CommentType 
    public reminderDate:Date | undefined
    public created:Date | undefined
    public createdBy:number | undefined
    public user:any | undefined
}

export enum CommentType{
    Update,
    Escalation,
    Description
}