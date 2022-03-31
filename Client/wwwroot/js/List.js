﻿"use strict"

var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:5001/signalr").build();

connection.on("NewMessage", function (obj) {
    console.log(obj)
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});
