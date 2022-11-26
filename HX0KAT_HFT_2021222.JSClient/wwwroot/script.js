﻿let customers = [];
let connection = null;
getdata();
setupSignalR();

let customerIdToUpdate = -1;

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5236/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CustomerCreated", (user, message) => {
        getdata();
    });

    connection.on("CustomerDeleted", (user, message) => {
        getdata();
    });

    connection.on("CustomerUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:5236/customer')
        .then(x => x.json())
        .then(y => {
            customers = y;
            //console.log(customers);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    customers.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td>" +
            "<td>" + t.firstName + "</td>" +
            "<td>" + t.lastName + "</td>" +
            "<td>" + t.email + "</td>" +
            `<td><button type="button" onclick="remove(${t.id})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.id})">Update</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:5236/customer/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let firstname = document.getElementById('firstname').value;
    let lastname = document.getElementById('lastname').value;
    let email = document.getElementById('email').value;
    fetch('http://localhost:5236/customer', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                firstName: firstname,
                lastName: lastname,
                email: email
            }
        )
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function showupdate(id) {
    document.getElementById('firstnametoupdate').value = customers.find(t => t['id'] == id)['firstName'];
    document.getElementById('lastnametoupdate').value = customers.find(t => t['id'] == id)['lastName'];
    document.getElementById('emailtoupdate').value = customers.find(t => t['id'] == id)['email'];
    customerIdToUpdate = id;

    document.getElementById('updateformdiv').style.display = 'flex';
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let firstname = document.getElementById('firstnametoupdate').value;
    let lastname = document.getElementById('lastnametoupdate').value;
    let email = document.getElementById('emailtoupdate').value;
    fetch('http://localhost:5236/customer', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                id: customerIdToUpdate,
                firstName: firstname,
                lastName: lastname,
                email: email
            }
        )
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}
