import { ChangeDetectionStrategy, Component, input, model, signal, viewChild } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatAccordion, MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { CourseContent } from '../../models/CourseDetail.model';
import { CommonModule } from '@angular/common';
import { CdkAccordionModule } from '@angular/cdk/accordion';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-content-accordion',
  imports: [ CommonModule,
    CdkAccordionModule,
    RouterLink],
  templateUrl: './content-accordion.component.html',
  styleUrl: './content-accordion.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ContentAccordionComponent {


  courseContent=input<CourseContent>();
  currentLessonId!:number;
  activeLesson=model<number>(this.currentLessonId);


  ngOnInit(){
    console.log('course content',this.courseContent());

  }
get numberOfLessons(){
  return this.courseContent()?.sections?.reduce((acc, section) => acc + section.lessons.length, 0) ?? 0;
};
get numberOfSections(){
  return this.courseContent()?.sections?.length ?? 0
};
updateCurrentLessonId(event: any,arg0: number) {

  this.currentLessonId=arg0;
  window.scrollTo(0, 0);

}

 itemStyle(lessonId: number) {
  const activeId =  Number(this.activeLesson()) ;

  console.log(`type of activeId: ${typeof activeId}
    value of activeId: ${activeId}
    typeof lessonId: ${typeof lessonId}
    value of lessonId: ${lessonId}
    isActive: ${activeId === lessonId}
    `);


  if(lessonId==activeId)
  {
    console.log('active style of lesson', this.activeLesson());
    return 'lesson-item-active lesson-item';
  }
  else
  {
    return 'lesson-item';
  }

}


}
