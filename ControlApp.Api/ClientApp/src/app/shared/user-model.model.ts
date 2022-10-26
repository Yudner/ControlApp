export class UserModel{
    public Id!: number;
    public Name!: string;
    public Code!: string;
    public Role!: string;

    public static createFromObject(obj: any): UserModel {
        const newObj = new UserModel();
        newObj.Id = obj.Id;
        newObj.Name = obj.Name;
        newObj.Code = obj.Code;
        newObj.Role = obj.Role;
        return newObj;
    }
}
