import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { IStudyBuddy } from './interfaces/IStudyBuddy';
import { RepositoryService } from './repository.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'studybuddy_proj_2023';
  headerText: string = "Welcome to the Bootcamp Study Buddy!"
  addText: string = "If you would like to submit a new study question, type it in below and press the submit button"

  constructor(private repositoryService: RepositoryService) { }
  studyCollection: IStudyBuddy[] = [];
  userID = Math.floor(Math.random() * (1000 - -1 + 1) + -1);

  ngOnInit(): void {
    this.getQuestionsAndAnswers();
  }

  getQuestionsAndAnswers(){
    this.repositoryService.getStudyQAndA().subscribe(response => this.studyCollection = response);
  }

  }
