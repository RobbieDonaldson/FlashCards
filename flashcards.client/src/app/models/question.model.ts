

export interface Question {
  id: number,
  questionText: string,
  answerText: string,
  questions: Question[]
}