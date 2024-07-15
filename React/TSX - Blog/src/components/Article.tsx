import React from 'react';
import { useParams } from 'react-router-dom';
import { articles } from '../articles';
import '../styles/Article.css';

const Article: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const article = articles.find(article => article.id === parseInt(id!));

  if (!article) {
    return <div>Article not found</div>;
  }

  return (
    <div className="article-container">
      <h1>{article.title}</h1>
      <p>{article.content}</p>
    </div>
  );
};

export default Article;