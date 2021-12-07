import { AfterViewInit, ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatPaginatorIntl } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Respondents } from '../contracts/respondents';
import { RespondentsService } from '../services/respondents-service.service';

@Component({
  selector: 'app-respondents',
  templateUrl: './respondents.component.html',
  styleUrls: ['./respondents.component.css']
})
export class RespondentsComponent implements OnInit {
  respondentsList: Respondents[] = [];

  displayedColumns: string[] = ['name'];
  dataSource!: MatTableDataSource<Respondents>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private respondentsService: RespondentsService) { }


  ngOnInit(): void {
    this.getRespondents();
    this.dataSource = new MatTableDataSource<Respondents>(this.respondentsList);
  }

  getRespondents(): void {
    this.respondentsService.getAllRespondents()
      .subscribe(response => {
        this.respondentsList = response.data;
        this.dataSource = new MatTableDataSource<Respondents>(this.respondentsList);
        this.dataSource.paginator = this.paginator;
      });
  }

}
