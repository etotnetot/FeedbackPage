import { Injectable } from '@angular/core';
import {HttpClient } from '@angular/common/http'
import { FeedbackMessage } from './feedback-message.model';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { Topic } from './topic.model';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class FeedbackService {
  url: string = environment.apiBaseUrl + '/SendFeedback'
  formData: FeedbackMessage = new FeedbackMessage()
  formSubmitted: boolean = false;
  topicData: Topic = new Topic()

  constructor(private http:HttpClient) { }

  postFeedbackMessage() {
    return this.http.post(this.url, this.formData)
  }

  getTopics() {
    return this.http.get<Topic[]>(environment.apiBaseUrl + '/GetTopics')
  }
}