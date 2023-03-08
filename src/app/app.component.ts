import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { IStudyQuestion } from './interfaces/study-question';
import { IFavoriteQuestion } from './interfaces/favorite-question';
import { RepositoryService } from './repository.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'studybuddy_proj_2023';

  constructor(private repositoryService: RepositoryService) { }
  studyQuestions: any;
  id: number = -1;
  question: string = "";
  answer: string = "";
  questionId: number = -1;
  userId: number = -1;

  // boardGames: any;
  // gameTitle: string = "";
  // description: string = "";
  // yearPublished: number = -1;
  // playerCount: number = -1

  ngOnInit(): void {
    this.gettStudyQuestions();
  }

  validateData(form: NgForm) {
    alert("bad data");
    //if all is good

    this.addStudyQuestion(form)
  }

  addStudyQuestion(form: NgForm) {
    let newStudyQuestion: IStudyQuestion = {
      id: -1,
      question: form.form.value.question,
      answer: form.form.value.answer,
    };

    addFavoriteQuestion(form: NgForm) {
      let newFavoriteQuestion: IFavoriteQuestion = {
        id: -1,
        questionId: -1,
        userId: -1,
      };

    this.repositoryService.addStudyQuestion(newStudyQuestion).subscribe(
      () => {
        this.gettStudyQuestions();
      }
    );
  };

  gettStudyQuestions() {
    this.repositoryService.getStudyQuestions().subscribe(
      (response) => {
        this.studyQuestions = response;
        // add alert
        // do calculation
      });
  }
}
