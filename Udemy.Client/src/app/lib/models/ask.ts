export interface Ask {
  id: number;
  userId: number;
  userName: string;
  title: string;
  content?: string;
  createdDate?: string;

}

export interface CreateAsk {
  title: string;
  content: string;
}
