import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Questions } from '../contracts/questions';
import { QuestionsService } from '../services/questions-service.service';
import { MaterialModule } from '../shared/material.module';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit {

  questionsList: Questions[] = [];
  yearsList: string[] = [];
  selectedYear: string = "2018";

  displayedColumns: string[] = ['question', 'answer'];
  dataSource!: MatTableDataSource<Questions>;

  constructor(private questionsService: QuestionsService) { }

  ngOnInit(): void {
    this.getQuestions();
    this.dataSource = new MatTableDataSource<Questions>(this.questionsList);
    this.getYearsList();
  }

  getQuestions(): void {
    this.questionsService.getAllQuestions()
      .subscribe(response => {
        this.questionsList = response.data;
        this.questionsList.forEach(question => {
          if (question != null && question.answer != null) {
            question.answer = question.answer.replace(/;/g, "\n")
            //question.answer.trimLeft();
          }
        })
        this.dataSource = new MatTableDataSource<Questions>(this.questionsList);
      });
  }

  getYearsList(): void {
    this.questionsService.getYearList()
      .subscribe(response => {
        this.yearsList = response.data;
      })
  }
}
