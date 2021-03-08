import { Component, OnInit } from '@angular/core';
import { SharedService } from '../../shared.service';

@Component({
  selector: 'app-show-emp',
  templateUrl: './show-emp.component.html',
  styleUrls: ['./show-emp.component.css']
})
export class ShowEmpComponent implements OnInit {

  public EmployeeList: any[] = [];
  public ModalTitle: string;
  public ActivateAddEditEmpComp: boolean;
  public Employee: any;

  constructor(private sharedService: SharedService) { }

  ngOnInit(): void {
    this.refreshEmployeeList();
  }

  private refreshEmployeeList(){
    this.sharedService.getEmployees().subscribe((data) => {
      this.EmployeeList = data;
    });
  }

  public addClick(){
    this.Employee = {
      EmployeeId: 0,
      EmployeeName: "",
      Department: "",
      DateOfJoining: "",
      PhotoFileName: "anonymous.png"
    };
    this.ModalTitle = "Add Employee";
    this.ActivateAddEditEmpComp = true;
  }

  public editClick(data){
    console.log(data);
    this.Employee = data;
    this.ModalTitle = "Edit Employee";
    this.ActivateAddEditEmpComp = true;
  }

  public deleteClick(data){
    if (confirm("Are you sure?")){
      this.sharedService.deleteEmployee(data.EmployeeId).subscribe(
        (response) => {
          alert(response.toString());
          this.refreshEmployeeList();
        }
      );
    }
  }

  public closeClick(){
    this.ActivateAddEditEmpComp = false;
    this.refreshEmployeeList();
  }

}