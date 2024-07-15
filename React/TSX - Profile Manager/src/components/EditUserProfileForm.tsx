import React, { useState } from 'react';
import { useUserProfile } from '../contexts/UserProfileContext';
import '../styles/userProfile.css';

export const EditUserProfileForm = () => {
  const { profile, updateUserProfile } = useUserProfile();
  const [name, setName] = useState(profile.name);
  const [email, setEmail] = useState(profile.email);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    updateUserProfile({ name, email });
  };

  return (
    <form onSubmit={handleSubmit} className="edit-user-profile-form">
      <label>
        Name:
        <input
          type="text"
          value={name}
          onChange={(e) => setName(e.target.value)}
          required
        />
      </label>
      <label>
        Email:
        <input
          type="email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          required
        />
      </label>
      <button type="submit">Update</button>
    </form>
  );
};