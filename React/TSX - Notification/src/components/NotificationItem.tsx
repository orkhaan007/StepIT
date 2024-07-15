import { Notification, useNotification } from '../contexts/NotificationContext';
import '../styles/notifications.css';

type Props = {
  notification: Notification;
};

export const NotificationItem: React.FC<Props> = ({ notification }) => {
  const { removeNotification } = useNotification();
  const notificationClass = `notification-item ${notification.type}`;

  return (
    <div className={notificationClass}>
      <p>{notification.message}</p>
      <button onClick={() => removeNotification(notification.id)}>Dismiss</button>
    </div>
  );
};