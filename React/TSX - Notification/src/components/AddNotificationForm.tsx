import React, { useState } from 'react';
import { useNotification } from '../contexts/NotificationContext';
import '../styles/notifications.css';

export const AddNotificationForm = () => {
  const [message, setMessage] = useState('');
  const [type, setType] = useState<'success' | 'error' | 'info'>('info');
  const { addNotification } = useNotification();

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    addNotification(message, type);
    setMessage('');
  };

  return (
    <form onSubmit={handleSubmit} className="add-notification-form">
      <input
        type="text"
        value={message}
        onChange={(e) => setMessage(e.target.value)}
        placeholder="Enter message"
        required
      />
      <select value={type} onChange={(e) => setType(e.target.value as 'success' | 'error' | 'info')}>
        <option value="success">Success</option>
        <option value="error">Error</option>
        <option value="info">Info</option>
      </select>
      <button type="submit">Add</button>
    </form>
  );
};