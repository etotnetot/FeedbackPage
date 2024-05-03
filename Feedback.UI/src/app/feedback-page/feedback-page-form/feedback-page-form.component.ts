import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, NgForm } from '@angular/forms';
import { FeedbackMessage } from 'src/app/shared/feedback-message.model';
import { FeedbackService } from 'src/app/shared/feedback.service';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';
import { Topic } from 'src/app/shared/topic.model';
import { Observable } from 'rxjs/internal/Observable';
import { FormsModule } from '@angular/forms';
import { every } from 'rxjs';
import { Validators } from '@angular/forms';

@Component({
  selector: 'app-feedback-page-form',
  templateUrl: './feedback-page-form.component.html',
  styles: []
})

export class FeedbackPageFormComponent implements OnInit {
  captchaText!: string;
  userInput!: string;
  topicList!: Observable<Topic[]>;
  feedbackForm!: FormGroup;
  isCaptchaInvalid!: boolean;
  
  constructor (public service: FeedbackService) { }

  ngOnInit(): void {        
    this.topicList = this.service.getTopics();
    this.generateCaptcha();
  }

  generateCaptcha(): void {
    this.captchaText = Math.floor(1000 + Math.random() * 9000).toString();
  }

  onSubmit(form: NgForm) {
    this.service.formData.TopicID = this.service.topicData.topicID;
    
    if (form.valid && this.userInput == this.captchaText) {
      this.service.postFeedbackMessage()
      .subscribe({
        next: res => { },
        error: err => { console.log(err) }
      });

      this.service.formSubmitted = true
    }
    else {
      this.isCaptchaInvalid = true;
    }
  }
}