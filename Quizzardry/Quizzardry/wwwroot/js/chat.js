"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/triviaHub").build();

connection.on("ReceiveMessage", function (user, option) {
  var msg = option.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
  var encodedMsg = user + " says " + msg;
  var li = document.createElement("li");
  li.textContent = encodedMsg;
  document.getElementById("messagesList").appendChild(li);
});

connection.start().catch(function (err) {
  return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
  var user = document.getElementById("userInput").value;
  var option = document.getElementsByName("option").values;
  connection.invoke("SendMessage", user, option).catch(function (err) {
    return console.error(err.toString());
  });
  event.preventDefault();
});