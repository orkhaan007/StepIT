import { NotificationProvider } from './contexts/NotificationContext';
import { NotificationList } from './components/NotificationList';
import { AddNotificationForm } from './components/AddNotificationForm';

const App = () => {
  return (
    <NotificationProvider>
      <AddNotificationForm />
      <NotificationList />
    </NotificationProvider>
  );
};

export default App;