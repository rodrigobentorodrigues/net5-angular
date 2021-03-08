import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  private readonly urlBase: string = "http://localhost:5473/api";
  public readonly urlPhotos: string = "http://localhost:5473/photos/";

  constructor(private httpClient: HttpClient) { }

  public getDepartments(): Observable<any[]> {
    return this.httpClient.get<any>(this.urlBase + "/department");
  }

  public addDepartment(department: any) {
    return this.httpClient.post(this.urlBase + "/department", department);
  }

  public updateDepartment(department: any){
    return this.httpClient.put(this.urlBase + "/department", department);
  }

  public deleteDepartment(id: any){
    return this.httpClient.delete(this.urlBase + "/department/" + id);
  }

  public getEmployees(): Observable<any[]> {
    return this.httpClient.get<any>(this.urlBase + "/employee");
  }

  public addEmployee(employee: any) {
    return this.httpClient.post(this.urlBase + "/employee", employee);
  }

  public updateEmployee(employee: any){
    return this.httpClient.put(this.urlBase + "/employee", employee);
  }

  public deleteEmployee(id: any){
    return this.httpClient.delete(this.urlBase + "/employee/" + id);
  }

  public uploadPhoto(photo: any){
    return this.httpClient.post(this.urlBase + "/employee/saveFile", photo);
  }

  public getAllDepartmentNames(): Observable<any[]>{
    return this.httpClient.get<any>(this.urlBase 
      + "/employee/getAllDepartmentNames");
  }

}
