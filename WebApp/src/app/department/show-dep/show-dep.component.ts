import { Component, OnInit } from '@angular/core';

import { SharedService } from '../../shared.service';

@Component({
  selector: 'app-show-dep',
  templateUrl: './show-dep.component.html',
  styleUrls: ['./show-dep.component.css']
})
export class ShowDepComponent implements OnInit {

  public DepartmentList: any = [];
  public ModalTitle: string;
  public ActivateAddEditDepComp: boolean;
  public Department: any;

  public DepartmentIdFilter: string = "";
  public DepartmentNameFilter: string = "";
  public DepartmentListWithoutFilter: any[] = [];

  constructor(private sharedService: SharedService) { }

  ngOnInit(): void {
    this.refreshDepartmentList();
  }

  private refreshDepartmentList(){
    this.sharedService.getDepartments().subscribe((data) => {
      this.DepartmentList = data;
      this.DepartmentListWithoutFilter = data;
    });
  }

  public addClick(){
    this.Department = {
      DepartmentId: 0,
      DepartmentName: ""
    };
    this.ModalTitle = "Add Department";
    this.ActivateAddEditDepComp = true;
  }

  public editClick(data){
    this.Department = data;
    this.ModalTitle = "Edit Department";
    this.ActivateAddEditDepComp = true;
  }

  public deleteClick(data){
    if (confirm("Are you sure?")){
      this.sharedService.deleteDepartment(data.DepartmentId).subscribe(
        (response) => {
          alert(response.toString());
          this.refreshDepartmentList();
        }
      );
    }
  }

  public filter(){
    var departmentIdFilter = this.DepartmentIdFilter;
    var departmentNameFilter = this.DepartmentNameFilter;

    this.DepartmentList = this.DepartmentListWithoutFilter.filter(
      function(el){
        return el.DepartmentId.toString().toLowerCase().includes(
          departmentIdFilter.toString().trim().toLowerCase()
        ) && el.DepartmentName.toString().toLowerCase().includes(
          departmentNameFilter.toString().trim().toLowerCase()
        )
    });
  }

  public sortResult(property, asc){
    this.DepartmentList = this.DepartmentListWithoutFilter.sort(
      function (a, b){
        if (asc){
          return (a[property] > b[property]) ? 1 : 
            ((a[property] < b[property]) ? -1 : 0)
        } else {
          return (b[property] > a[property]) ? 1 : 
            ((b[property] < a[property]) ? -1 : 0)
        }
        return null;
      }
    );
  }

  public closeClick(){
    this.ActivateAddEditDepComp = false;
    this.refreshDepartmentList();
  }

}
