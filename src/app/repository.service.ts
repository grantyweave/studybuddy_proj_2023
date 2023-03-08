import { Injectable } from '@angular/core';
import { IStudyBuddy } from './interfaces/IStudyBuddy';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RepositoryService {

  constructor(private http: HttpClient) { }

  apiUri: string = 'https://localhost:7257/api/StudyQuestions'

  getStudyQAndA() {
    return this.http.get<IStudyBuddy[]>(this.apiUri);
  }
  
  addQuestionAnswer(study:IStudyBuddy) {
    return this.http.post(`${this.apiUri}/add`,study);
  }

}
