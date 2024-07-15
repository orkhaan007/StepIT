export interface Article {
    id: number;
    title: string;
    description: string;
    content: string;
  }
  
  export const articles: Article[] = [
    {
      id: 1,
      title: "First Article",
      description: "This is the first article",
      content: "Full content of the first article...",
    },
    {
      id: 2,
      title: "Second Article",
      description: "This is the second article",
      content: "Full content of the second article...",
    },
  ];