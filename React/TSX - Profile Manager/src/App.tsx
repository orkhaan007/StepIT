import { UserProfileProvider } from './contexts/UserProfileContext';
import { UserProfileDisplay } from './components/UserProfileDisplay';
import { EditUserProfileForm } from './components/EditUserProfileForm';

const App = () => {
  return (
    <UserProfileProvider>
      <UserProfileDisplay />
      <EditUserProfileForm />
    </UserProfileProvider>
  );
};

export default App;