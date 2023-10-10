import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { HomeDisplay } from '../contracts/home-display';
import { QuestionsService } from '../services/questions-service.service';
import { ResponsesService } from '../services/responses-service.service';
import { RespondentsService } from '../services/respondents-service.service';
import { Respondents } from '../contracts/respondents';
import { Responses } from '../contracts/responses';
import { MatSort, MatSortable } from '@angular/material/sort';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  yearsList: string[] = [];
  selectedYear: string = "";
  responsesList: Responses[] = [];
  respondentsList: Respondents[] = [];
  rQuestions: any[] = [];
  rCorrect: number = 0;
  dataSourceResponse!: MatTableDataSource<HomeDisplay>;
  displayedColumns: string[] = ['rank', 'name', 'questions', 'percentCorrect'];

  @ViewChild(MatSort) sort!: MatSort;

  constructor(private questionsService: QuestionsService, 
    private responsesService: ResponsesService, 
    private respondentsService: RespondentsService) { }

  ngOnInit(): void {
    this.selectedYear = this.questionsService.getSelectedYear();
    this.questionsService.getYearList()
      .subscribe(response => {
        this.yearsList = response.data;
      });
    this.responsesService.getResponsesByYear(parseInt(this.selectedYear))
      .subscribe(resp => {
        this.responsesList = resp.data;
        this.respondentsService.getAllRespondents()
          .subscribe(r => {
            this.respondentsList = r.data;
            this.fillResponseTable();
            this.sortResponseTableByCorrect();
          })
      })
  }

  fillResponseTable() {
    this.dataSourceResponse = new MatTableDataSource<HomeDisplay>();
    this.respondentsList.forEach( p => {
      let respQuestions = this.responsesList.filter(x => x.respondentID == p.respondentID);
      let correctPercent = (respQuestions.length > 0) ? ((respQuestions.filter(y => y.correct == true).length)/respQuestions.length) * 100 : 0;
      let hd = {
        rank: 0,
        name: p.respondentName,
        questions: respQuestions.length,
        percentCorrect: correctPercent
      }
      if (hd.questions > 0) {
        this.dataSourceResponse.data.push(hd);
      }
    })
  }

  sortResponseTableByCorrect() {
    this.dataSourceResponse.data.sort((a: any, b: any) => {
      if (a.percentCorrect > b.percentCorrect) {
        return -1;
      } else if (a.percentCorrect < b.percentCorrect) {
        return 1;
      } else {
        return 0;
      }                
    })
    let rank = 1;
    let currentCorrect = this.dataSourceResponse.data[0].percentCorrect;
    this.dataSourceResponse.data.forEach(x => {
      if (x.percentCorrect < currentCorrect) {
        rank++;
        currentCorrect = x.percentCorrect;
      }
      x.rank = rank;
    })
  }

  yearChanged(event: any) {
    this.questionsService.setSelectedYear(event.source.selected.value);
    this.selectedYear = event.source.selected.value;
    this.responsesService.getResponsesByYear(parseInt(this.selectedYear))
      .subscribe(resp => {
        this.responsesList = resp.data;
        this.respondentsService.getAllRespondents()
          .subscribe(r => {
            this.respondentsList = r.data;
            this.fillResponseTable();
            if (this.dataSourceResponse != null && this.dataSourceResponse.data.length > 0) {
              this.sortResponseTableByCorrect();
            }
          })
      })
  }
}
