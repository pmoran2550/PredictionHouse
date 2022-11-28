import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Questions } from '../contracts/questions';
import { QuestionsService } from '../services/questions-service.service';

@Component({
  selector: 'app-disp-questions',
  templateUrl: './disp-questions.component.html',
  styleUrls: ['./disp-questions.component.css']
})
export class DispQuestionsComponent implements OnInit {

  questionsList: Questions[] = [];
  yearsList: string[] = [];
  selectedYear: string = "";

  displayedColumns: string[] = ['question', 'answer'];
  dataSource!: MatTableDataSource<Questions>;

  constructor(private questionsService: QuestionsService) { }

  ngOnInit(): void {
    this.selectedYear = this.questionsService.getSelectedYear();
    this.getQuestionsByYear(this.selectedYear);
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

  getQuestionsByYear(year: string): void {
    this.questionsService.getQuestionsByYear(year)
      .subscribe(resp => {
        this.questionsList = resp.data;
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

  yearChanged(event: any){
    console.log(event.source.selected.value);
    this.questionsService.setSelectedYear(event.source.selected.value);
    this.getQuestionsByYear(event.source.selected.value);
  }
}
