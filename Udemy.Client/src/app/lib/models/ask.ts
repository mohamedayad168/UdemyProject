export interface Ask {
  id: number;
  userId: number;
  userName: string;
  title: string;
  content?: string;
  createdDate?: string;
  answers: Answer[]
}

export interface Answer{
  id: number;
  askId: number;
  userId: number;
  userName: string;
  content: string;
  createdDate?: string;
}

export interface CreateAsk {
  title: string;
  content: string;
}

export interface UpdateAsk {
  id: number;
  title: string;
  content: string;
}

export interface CreateAnswerModel {
  content: string;
}
