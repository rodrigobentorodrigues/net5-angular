import { Component, OnInit, Input } from '@angular/core';

import { SharedService } from '../../shared.service';

@Component({
  selector: 'app-add-edit-dep',
  templateUrl: './add-edit-dep.component.html',
  styleUrls: ['./add-edit-dep.component.css']
})
export class AddEditDepComponent implements OnInit {

  @Input() dep: any;
  public DepartmentId: string;
  public DepartmentName: string;

  constructor(private sharedService: SharedService) { }

  ngOnInit(): void {
    this.DepartmentId = this.dep.DepartmentId;
    this.DepartmentName = this.dep.DepartmentName;
  }

  public addDepartment(){
    var val = {
      DepartmentId: this.DepartmentId,
      DepartmentName: this.DepartmentName
    };
    this.sharedService.addDepartment(val).subscribe(
      (response) => alert(response.toString())
    );
  }

  public updateDepartment(){
    var val = {
      DepartmentId: this.DepartmentId,
      DepartmentName: this.DepartmentName
    };
    this.sharedService.updateDepartment(val).subscribe(
      (response) => alert(response.toString())
    );
  }

}
