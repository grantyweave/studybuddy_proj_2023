import { Component, EventEmitter, Input, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { IStudyBuddy } from '../interfaces/IStudyBuddy';
import { RepositoryService } from '../repository.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-user-input',
  templateUrl: './user-input.component.html',
  styleUrls: ['./user-input.component.css']
})
export class UserInputComponent {

  constructor(private repositoryService: RepositoryService) { }

  @Input() qaPair!: IStudyBuddy;
  @Output() reloadCollection = new EventEmitter<boolean>();
  question: string = "";
  answer: string = "";
  id: number = -1;

  addQuestionAnswer(form:NgForm) {
    let newQAPair : IStudyBuddy = {
      id: -1,
      question: form.form.value.question,
      answer: form.form.value.answer
    };

    this.repositoryService.addQuestionAnswer(newQAPair).subscribe( () =>
      this.reloadCollection.emit(true)
    );
  };



}
