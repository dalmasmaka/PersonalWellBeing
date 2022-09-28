export interface Exercise {
    exercisesId: number
    exercisesType: string
    menuListId: number
    exerciseItemId: number
    exerciseItemTitle: string
    exerciseItemDescription: string
    exerciseItemImg: string
  }
  export interface ExercisesParams{
    types:string[];
    items:string[];
    pageNumber: number;
    pageSize:number;
  }