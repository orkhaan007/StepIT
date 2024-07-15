import React, { useState } from 'react';
import { useSearchParams, Link } from 'react-router-dom';
import { articles } from '../articles';
import '../styles/Home.css';

const Home: React.FC = () => {
  const [searchParams, setSearchParams] = useSearchParams();
  const query = searchParams.get('query') || '';
  const [searchQuery, setSearchQuery] = useState(query);

  const handleSearch = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSearchQuery(event.target.value);
    setSearchParams({ query: event.target.value });
  };

  const filteredArticles = articles.filter(article =>
    article.title.toLowerCase().includes(searchQuery.toLowerCase())
  );

  return (
    <div className="container">
      <input
        type="text"
        value={searchQuery}
        onChange={handleSearch}
        placeholder="Search"
      />
      <ul>
        {filteredArticles.map(article => (
          <li key={article.id}>
            <Link to={`/article/${article.id}`}>{article.title}</Link>
            <p>{article.description}</p>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default Home;