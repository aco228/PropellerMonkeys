"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/consoleHub").build();

connection.on("Command", function (command) {
  var li = document.createElement("li");
  li.textContent = command;
  document.getElementById("console").appendChild(li);
});

connection.start().then(function () {

}).catch(function (err) {
    return console.error(err.toString());
});
