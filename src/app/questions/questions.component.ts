import { Component, Input } from '@angular/core';
import { NgForm } from '@angular/forms';
import { IStudyBuddy } from '../interfaces/IStudyBuddy';
import { RepositoryService } from '../repository.service';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})
export class QuestionsComponent {

  @Input() qaPair!: IStudyBuddy;
  display = true;

  toggleAnswer(element: any){
    element.textContent = element.textContent === 'Hide' ? 'Expand' : 'Hide';
  }

  // toggleFavorite(){
  //   this.qaPair.favorite = !this.qaPair.favorite;
  // }
}
