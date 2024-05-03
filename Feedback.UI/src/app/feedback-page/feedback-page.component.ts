import { Component, OnInit } from '@angular/core';
import { FeedbackService } from '../shared/feedback.service';
import { Injectable } from '@angular/core';

@Component({
  selector: 'app-feedback-page',
  templateUrl: './feedback-page.component.html',
  styles: []
})

export class FeedbackPageComponent  {
  constructor (public service: FeedbackService) { }
}