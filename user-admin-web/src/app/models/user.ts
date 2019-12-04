import { Role } from './role';
import { Entity } from './Entity';

export interface User extends Entity
{
    login : string,
    name : string,
    email? : string,
    password? : string,
    roles? : Role[]
}