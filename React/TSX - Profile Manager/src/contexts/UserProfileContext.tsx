import  { createContext, useContext, useState, ReactNode } from 'react';

type UserProfile = {
  name: string;
  email: string;
};

type UserProfileContextType = {
  profile: UserProfile;
  updateUserProfile: (profile: UserProfile) => void;
};

const UserProfileContext = createContext<UserProfileContextType | undefined>(undefined);

export const useUserProfile = () => {
  const context = useContext(UserProfileContext);
  if (!context) {
    throw new Error('useUserProfile must be used within a UserProfileProvider');
  }
  return context;
};

export const UserProfileProvider = ({ children }: { children: ReactNode }) => {
  const [profile, setProfile] = useState<UserProfile>({ name: '', email: '' });

  const updateUserProfile = (newProfile: UserProfile) => {
    setProfile(newProfile);
  };

  return (
    <UserProfileContext.Provider value={{ profile, updateUserProfile }}>
      {children}
    </UserProfileContext.Provider>
  );
};