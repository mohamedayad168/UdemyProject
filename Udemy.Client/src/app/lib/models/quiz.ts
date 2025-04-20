export interface Quiz {
  id: number;
  courseId: number;
  questions: Question[];
}

export interface Question {
  id: number;
  quizId: number;
  type: QuestionType;
  questionTxt: string;
  choiceA?: string | null;
  choiceB?: string | null;
  choiceC?: string | null;
}

export interface QuizAnswersForSubmit {
  quizId: number;
  courseId: number;
  studentId: number;
  answers: QuestionAnswer[];
}

export interface QuestionAnswer {
  quizId: number;
  questionId: number;
  answer: string;
}

export type QuestionType = 'Multiple Choice' | 'True or False';

export interface QuizCDTO {
  CourseId: number;
  QuizQuestions: QuizQuestionCDTO[];
}

export interface QuizQuestionCDTO {
  Type: string;
  QuestionTxt: string;
  ChoiceA?: string | null;
  ChoiceB?: string | null;
  ChoiceC?: string | null;
  AnswerTxt: string;
}

export interface QuizQuestion {
  id: number;
  type: string;
  questionTxt: string;
  choiceA?: string | null;
  choiceB?: string | null;
  choiceC?: string | null;
  answerTxt: string;
}
