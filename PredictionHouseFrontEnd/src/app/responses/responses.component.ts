import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

import { Responses } from '../contracts/responses';
import { ResponsesService } from '../services/responses-service.service';
import { Respondents } from '../contracts/respondents'
import { RespondentsService } from '../services/respondents-service.service';
import { QuestionsService } from '../services/questions-service.service';

@Component({
  selector: 'app-responses',
  templateUrl: './responses.component.html',
  styleUrls: ['./responses.component.css']
})
export class ResponsesComponent implements OnInit {

  respondentsList: Respondents[] = [];
  responsesList: Responses[] = [];
  questionsList: string[] = [];
  selectedResponse: string = "";
  selectedRespondent: Respondents = {
    respondentID: -1,
    respondentName: "test",
    respondentGroup: "none"
  };
  selectedYear: string = "";

  displayedColumns: string[] = ['response', 'correct'];
  dataSourceResponse!: MatTableDataSource<Responses>;
  dataSourceRespondents!: MatTableDataSource<Respondents>;

  constructor(private respondentsService: RespondentsService, 
    private responsesService: ResponsesService, 
    private questionsService: QuestionsService) { }

  ngOnInit(): void {
    this.selectedYear = this.questionsService.getSelectedYear();
    this.getRespondents();
    this.getQuestions(this.selectedYear);
  }

  respondentChanged(event: any) {
    console.log("respondent changed to " + this.selectedRespondent.respondentName);
  }

  getResponses(respondent: Respondents) {
    this.responsesService.getResponsesByRespondent(respondent.respondentID)
      .subscribe(responses => {
        this.responsesList = responses.data;
        this.dataSourceResponse = new MatTableDataSource<Responses>(this.responsesList);
      })
  }

  getRespondents(): void {
    this.respondentsService.getAllRespondents()
      .subscribe(respondents => {
        this.respondentsList = respondents.data;
        this.dataSourceRespondents = new MatTableDataSource<Respondents>(this.respondentsList);
        if (typeof this.selectedRespondent == 'undefined' || this.selectedRespondent.respondentID == -1) {
          this.selectedRespondent = this.respondentsList[0];
          this.getResponses(this.selectedRespondent);
        }
      });
  }

  getQuestions(year: string): void {
    this.questionsService.getQuestionsByYear(year)
      .subscribe(response => {
        this.questionsList = response.data;
      });
  }

}
