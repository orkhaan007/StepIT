document.addEventListener('DOMContentLoaded', () => {
    const contactList = document.getElementById('contactList');
    const addContactForm = document.getElementById('addContactForm');
    const filterButton = document.getElementById('filterButton');
    const filterCriteria = document.getElementById('filterCriteria');
    const filterValue = document.getElementById('filterValue');
    const prevPageButton = document.getElementById('prevPage');
    const nextPageButton = document.getElementById('nextPage');
    const pageInfo = document.getElementById('pageInfo');
    const itemsPerPage = 5;
    let currentPage = 1;

    function loadContacts() {
        let contacts = JSON.parse(localStorage.getItem('contacts')) || [];
        return contacts;
    }

    function saveContacts(contacts) {
        localStorage.setItem('contacts', JSON.stringify(contacts));
    }

    function renderContacts(contacts, page = 1) {
        contactList.innerHTML = '';
        const start = (page - 1) * itemsPerPage;
        const end = start + itemsPerPage;
        const paginatedContacts = contacts.slice(start, end);

        paginatedContacts.forEach((contact, index) => {
            const li = document.createElement('li');
            li.innerHTML = `
                <strong>${contact.firstName} ${contact.lastName}</strong><br>
                Phone: ${contact.phoneNumber}<br>
                Email: ${contact.email}<br>
                <button onclick="editContact(${index + start})">Edit</button>
                <button onclick="deleteContact(${index + start})">Remove</button>
            `;
            contactList.appendChild(li);
        });

        const totalPages = Math.ceil(contacts.length / itemsPerPage);
        pageInfo.textContent = `Page ${page} / ${totalPages}`;
        prevPageButton.disabled = page === 1;
        nextPageButton.disabled = page === totalPages;
    }

    function addContact(contact) {
        let contacts = loadContacts();
        contacts.push(contact);
        saveContacts(contacts);
        renderContacts(contacts, currentPage);
    }

    function deleteContact(index) {
        let contacts = loadContacts();
        contacts.splice(index, 1);
        saveContacts(contacts);
        renderContacts(contacts, currentPage);
    }

    function editContact(index) {
        let contacts = loadContacts();
        const contact = contacts[index];
        document.getElementById('firstName').value = contact.firstName;
        document.getElementById('lastName').value = contact.lastName;
        document.getElementById('phoneNumber').value = contact.phoneNumber;
        document.getElementById('email').value = contact.email;
        addContactForm.onsubmit = (e) => {
            e.preventDefault();
            contact.firstName = document.getElementById('firstName').value;
            contact.lastName = document.getElementById('lastName').value;
            contact.phoneNumber = document.getElementById('phoneNumber').value;
            contact.email = document.getElementById('email').value;
            contacts[index] = contact;
            saveContacts(contacts);
            renderContacts(contacts, currentPage);
            addContactForm.reset();
            addContactForm.onsubmit = handleFormSubmit;
        }
    }

    function filterContacts(criteria, value) {
        let contacts = loadContacts();
        contacts = contacts.filter(contact => contact[criteria].toLowerCase().includes(value.toLowerCase()));
        renderContacts(contacts, 1);
    }

    function handleFormSubmit(e) {
        e.preventDefault();
        const newContact = {
            firstName: document.getElementById('firstName').value,
            lastName: document.getElementById('lastName').value,
            phoneNumber: document.getElementById('phoneNumber').value,
            email: document.getElementById('email').value
        };
        addContact(newContact);
        addContactForm.reset();
    }

    addContactForm.onsubmit = handleFormSubmit;

    filterButton.onclick = () => {
        filterContacts(filterCriteria.value, filterValue.value);
    };

    prevPageButton.onclick = () => {
        if (currentPage > 1) {
            currentPage--;
            renderContacts(loadContacts(), currentPage);
        }
    };

    nextPageButton.onclick = () => {
        const totalPages = Math.ceil(loadContacts().length / itemsPerPage);
        if (currentPage < totalPages) {
            currentPage++;
            renderContacts(loadContacts(), currentPage);
        }
    };

    renderContacts(loadContacts(), currentPage);
});

function deleteContact(index) {
    const contacts = JSON.parse(localStorage.getItem('contacts')) || [];
    contacts.splice(index, 1);
    localStorage.setItem('contacts', JSON.stringify(contacts));
    document.location.reload();
}

function editContact(index) {
    const contacts = JSON.parse(localStorage.getItem('contacts')) || [];
    const contact = contacts[index];
    document.getElementById('firstName').value = contact.firstName;
    document.getElementById('lastName').value = contact.lastName;
    document.getElementById('phoneNumber').value = contact.phoneNumber;
    document.getElementById('email').value = contact.email;
    contacts.splice(index, 1);
    localStorage.setItem('contacts', JSON.stringify(contacts));
}