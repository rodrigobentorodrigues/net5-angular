import { Component, OnInit, Input } from '@angular/core';

import { SharedService } from '../../shared.service';

@Component({
  selector: 'app-add-edit-emp',
  templateUrl: './add-edit-emp.component.html',
  styleUrls: ['./add-edit-emp.component.css']
})
export class AddEditEmpComponent implements OnInit {

  @Input() emp: any;
  public EmployeeId: string;
  public EmployeeName: string;
  public Department: string;
  public DateOfJoining: string;
  public PhotoFileName: string;
  public PhotoFilePath: string;

  public DepartmentList: any[] = [];

  constructor(private sharedService: SharedService) { }

  ngOnInit(): void {
    this.loadDepartmentList();
  }

  private loadDepartmentList(){
    this.sharedService.getAllDepartmentNames().subscribe(
      (data) => {
        this.DepartmentList = data;

        this.EmployeeId = this.emp.EmployeeId;
        this.EmployeeName = this.emp.EmployeeName;
        this.Department = this.emp.Department;
        this.DateOfJoining = this.emp.DateOfJoining;
        this.PhotoFileName = this.emp.PhotoFileName;
        this.PhotoFilePath = this.sharedService.urlPhotos + this.PhotoFileName;
      }
    );
  }

  public addEmployee() {
    var value = {
      EmployeeId: this.EmployeeId,
      EmployeeName: this.EmployeeName,
      Department: this.Department,
      DateOfJoining: this.DateOfJoining,
      PhotoFileName: this.PhotoFileName
    };
    this.sharedService.addEmployee(value).subscribe(
      (response) => alert(response.toString())
    );
  }

  public updateEmployee(){
    var value = {
      EmployeeId: this.EmployeeId,
      EmployeeName: this.EmployeeName,
      Department: this.Department,
      DateOfJoining: this.DateOfJoining,
      PhotoFileName: this.PhotoFileName
    };
    this.sharedService.updateEmployee(value).subscribe(
      (response) => alert(response.toString())
    );
  }

  public uploadPhoto(event){
    var file = event.target.files[0];
    const formData: FormData = new FormData();
    formData.append("uploadFile", file, file.name);

    this.sharedService.uploadPhoto(formData).subscribe(
      (result) => {
        this.PhotoFileName = result.toString();
        this.PhotoFilePath = this.sharedService.urlPhotos + this.PhotoFileName;
      }
    );
  }

}
