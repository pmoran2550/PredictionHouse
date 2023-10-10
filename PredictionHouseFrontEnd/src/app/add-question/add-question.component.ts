import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { QuestionsService } from '../services/questions-service.service';

@Component({
  selector: 'app-add-question',
  templateUrl: './add-question.component.html',
  styleUrls: ['./add-question.component.css']
})
export class AddQuestionComponent implements OnInit {

  addQuestionForm = this.fb.group({
    question: ['', Validators.required],
    answer: [''],
    year: ['']
  })

  constructor(private fb: UntypedFormBuilder, 
              private route: ActivatedRoute,
              private router: Router, 
              private questionService: QuestionsService) { }

  ngOnInit(): void {
  }

  onCancelForm() {
    this.router.navigate(['/questions/disp-questions']);
  }

  onSubmit() {
    var val = this.addQuestionForm.value;
    this.questionService.setNewQuestion();
  }
}
