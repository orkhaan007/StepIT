import { useNotification } from '../contexts/NotificationContext';
import { NotificationItem } from './NotificationItem';
import '../styles/notifications.css';

export const NotificationList = () => {
  const { notifications } = useNotification();
  return (
    <div className="notification-list">
      {notifications.map((notification) => (
        <NotificationItem key={notification.id} notification={notification} />
      ))}
    </div>
  );
};