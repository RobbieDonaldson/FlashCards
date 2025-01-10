import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Survey } from './models/survey.model';
import { Question } from './models/question.model';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent implements OnInit {

  optionSelected: boolean = false;
  selectedSurvey: string = "";
  surveys: Survey[] = [];
  survey?: Survey;
  questions: Question[] = [];
  currentCardIndex = 0;

  constructor(private http: HttpClient) {}

  ngOnInit() { 
    this.getSurveys();
  }

  onOptionsSelected($event:any){
    this.optionSelected = true;
    this.getQuestions($event.target.value);  
  }

  previousCard() {
    let questionNumber = this.currentCardIndex - 1;
    this.currentCardIndex = (questionNumber) % this.questions.length;
    if(this.currentCardIndex < 0) this.currentCardIndex = 0;

  }

  nextCard() {
    this.currentCardIndex = (this.currentCardIndex + 1) % this.questions.length;
  }

  getSurveys() {
    this.http.get<any[]>('https://localhost:7158/api/survey').subscribe(
      (result) => {
        this.surveys = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  getQuestions(id:number) {
    this.http.get<Survey>(`https://localhost:7158/api/survey/${id}`).subscribe(
      (result) => {
        this.survey = result;
        this.selectedSurvey = this.survey.name;
        this.questions = this.survey?.questions;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'Flash Cards';
}
