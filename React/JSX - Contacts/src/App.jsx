import { useState, useEffect } from 'react';

const Contact = ({ contact, onDelete }) => (
  <div className="contact-item">
    <span>{contact.name}: {contact.phone}</span>
    <button onClick={() => onDelete(contact.id)}>Delete</button>
  </div>
);

const ContactBook = () => {
  const [contacts, setContacts] = useState([]);
  const [name, setName] = useState('');
  const [phone, setPhone] = useState('');
  const [error, setError] = useState('');

  useEffect(() => {
    const storedContacts = JSON.parse(localStorage.getItem('contacts')) || [];
    setContacts(storedContacts);
  }, []);

  useEffect(() => {
    localStorage.setItem('contacts', JSON.stringify(contacts));
  }, [contacts]);

  const addContact = () => {
    if (!name || !phone) {
      setError('All fields must be filled');
      return;
    }

    const newContact = { id: Date.now(), name, phone };
    setContacts([...contacts, newContact]);
    setName('');
    setPhone('');
    setError('');
  };

  const deleteContact = (id) => {
    setContacts(contacts.filter(contact => contact.id !== id));
  };

  return (
    <div className="container">
      <div className="input-group">
        {error && <div className="error">{error}</div>}
        <input
          type="text"
          placeholder="Name"
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
        <input
          type="number"
          placeholder="Phone"
          value={phone}
          onChange={(e) => setPhone(e.target.value)}
        />
        <button onClick={addContact}>Add</button>
      </div>
      <div className="contact-list">
        {contacts.map(contact => (
          <Contact key={contact.id} contact={contact} onDelete={deleteContact} />
        ))}
      </div>
    </div>
  );
};

export default ContactBook;