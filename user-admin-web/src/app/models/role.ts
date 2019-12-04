import { Entity } from './Entity';
import { User } from './user';

export interface Role extends Entity {
    name : string,
    users? : User[]
}