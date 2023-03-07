import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { IStudyQuestion } from './interfaces/study-question';
import { IFavoriteQuestion } from './interfaces/favorite-question';

@Injectable({
  providedIn: 'root'
})
export class RepositoryService {


  constructor(private http: HttpClient) { }


  studyApiUri: string = 'https://localhost:7257/api/Study'
  favoriteApiUri: string = 'https://localhost:7257/api/FavoriteQuestions'


  getStudyQuestions() {
    return this.http.get(this.studyApiUri)
  }
  
  addStudyQuestions(study:IStudyQuestion) {
    return this.http.post(`${this.studyApiUri}/add`,study);
  }

  getFavoriteQuestions() {
    return this.http.get(this.studyApiUri)
  }
  
  addFavoriteQuestions(study:IFavoriteQuestion) {
    return this.http.post(`${this.favoriteApiUri}/add`,study);
  }
}