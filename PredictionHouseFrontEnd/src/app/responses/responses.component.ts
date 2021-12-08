import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

import { Responses } from '../contracts/responses';
import { ResponsesService } from '../services/responses-service.service';
import { Respondents } from '../contracts/respondents'
import { RespondentsService } from '../services/respondents-service.service';
import { QuestionsService } from '../services/questions-service.service';
import { Questions } from '../contracts/questions';
import { ResponseDisplay } from '../contracts/response-display';

@Component({
  selector: 'app-responses',
  templateUrl: './responses.component.html',
  styleUrls: ['./responses.component.css']
})
export class ResponsesComponent implements OnInit {

  respondentsList: Respondents[] = [];
  responsesList: Responses[] = [];
  questionsList: Questions[] = [];
  selectedResponse: string = "";
  selectedRespondent: Respondents = {
    respondentID: -1,
    respondentName: "test",
    respondentGroup: "none"
  };
  selectedYear: string = "";
  yearsList: string[] = [];

  displayedColumns: string[] = ['question', 'response', 'correct'];
  dataSourceResponse!: MatTableDataSource<ResponseDisplay>;
  dataSourceRespondents!: MatTableDataSource<Respondents>;

  constructor(private respondentsService: RespondentsService, 
    private responsesService: ResponsesService, 
    private questionsService: QuestionsService) { }

  ngOnInit(): void {
    this.selectedYear = this.questionsService.getSelectedYear();
    this.selectedRespondent = this.respondentsService.getSelectedRespondent();
    this.getRespondents();
    this.getYearsList();
  }

  respondentChanged(event: any) {
    console.log("respondent changed to " + this.selectedRespondent.respondentName);
    this.selectedRespondent = event.source.selected.value;
    this.getResponses(this.selectedRespondent);
  }

  getResponses(respondent: Respondents) {
    this.responsesService.getResponsesByRespondent(respondent.respondentID)
      .subscribe(responses => {
        this.responsesList = responses.data;
        this.selectedYear = this.questionsService.getSelectedYear();
        this.getQuestions(this.selectedYear);
      })
  }

  getRespondents(): void {
    this.respondentsService.getAllRespondents()
      .subscribe(respondents => {
        this.respondentsList = respondents.data;
        this.dataSourceRespondents = new MatTableDataSource<Respondents>(this.respondentsList);
        if (typeof this.selectedRespondent == 'undefined' || this.selectedRespondent.respondentID == -1) {
          this.selectedRespondent = this.respondentsList[0];
          this.respondentsService.setSelectedRespondent(this.selectedRespondent);
          this.getResponses(this.selectedRespondent);
        }
      });
  }

  getQuestions(year: string): void {
    this.questionsService.getQuestionsByYear(year)
      .subscribe(response => {
        this.questionsList = response.data;
        this.dataSourceResponse = new MatTableDataSource<ResponseDisplay>();
        if (this.responsesList.length > 0) {
          this.questionsList.forEach(item => {
            let r1 = this.responsesList.find(x => x.questionID == item.questionID);
            let respDisp1 = {
              question: item.question,
              response: r1?.response,
              correct: r1?.correct
            }
            this.dataSourceResponse.data.push(respDisp1);
          });
        }
      });
  }

  getYearsList(): void {
    this.questionsService.getYearList()
      .subscribe(response => {
        this.yearsList = response.data;
      })
  }

  yearChanged(event: any){
    console.log(event.source.selected.value);
    this.questionsService.setSelectedYear(event.source.selected.value);
    this.getQuestions(event.source.selected.value);
  }
}
