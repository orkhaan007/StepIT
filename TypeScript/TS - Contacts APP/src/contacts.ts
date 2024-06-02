export interface Contact {
  name: string;
  phone: string;
  email: string;
}

let contacts: Contact[] = JSON.parse(localStorage.getItem('contacts') || '[]');

export function saveContacts() {
  localStorage.setItem('contacts', JSON.stringify(contacts));
}

export function addContact(contact: Contact) {
  contacts.push(contact);
  saveContacts();
  renderContacts();
}

export function deleteContact(index: number) {
  contacts.splice(index, 1);
  saveContacts();
  renderContacts();
}

export function renderContacts() {
  const app = document.getElementById('app')!;
  app.innerHTML = `
    <h1>Contacts</h1>
    <form id="contact-form">
      <input type="text" id="name" placeholder="Name" required />
      <input type="tel" id="phone" placeholder="Phone" required />
      <input type="email" id="email" placeholder="Email" required />
      <button type="submit">Add Contact</button>
    </form>
    <ul class="contact-list">
      ${contacts.map((contact, index) => `
        <li class="contact-item">
          <span>${contact.name}</span>
          <span>${contact.phone}</span>
          <span>${contact.email}</span>
          <button type="button" data-index="${index}">Delete</button>
        </li>
      `).join('')}
    </ul>
  `;

  document.getElementById('contact-form')!.addEventListener('submit', event => {
    event.preventDefault();
    const name = (document.getElementById('name') as HTMLInputElement).value;
    const phone = (document.getElementById('phone') as HTMLInputElement).value;
    const email = (document.getElementById('email') as HTMLInputElement).value;
    
    if (validateEmail(email) && validatePhone(phone)) {
      addContact({ name, phone, email });
    } else {
      alert('Invalid email or phone number');
    }
  });

  document.querySelectorAll('.contact-item button').forEach(button => {
    button.addEventListener('click', () => {
      const index = (button as HTMLButtonElement).dataset.index;
      deleteContact(Number(index));
    });
  });
}

function validateEmail(email: string): boolean {
  const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  return re.test(email);
}

function validatePhone(phone: string): boolean {
  const re = /^\d{10}$/;
  return re.test(phone);
}