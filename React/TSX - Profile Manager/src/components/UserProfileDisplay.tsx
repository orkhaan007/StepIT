import { useUserProfile } from '../contexts/UserProfileContext';
import '../styles/userProfile.css';

export const UserProfileDisplay = () => {
  const { profile } = useUserProfile();
  return (
    <div className="user-profile-display">
      <h2>Profile</h2>
      <p>Name: {profile.name}</p>
      <p>Email: {profile.email}</p>
    </div>
  );
};