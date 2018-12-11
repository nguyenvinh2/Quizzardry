"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/triviaHub").build();

connection.start().then(function(){
  var user = document.getElementById("userInput").value;
  connection.invoke("SendUser", user).catch(function (err) {
    return console.error(err.toString());
  });
}).catch(function (err) {
  return console.error(err.toString());
});

connection.on("ReceiveUser", function (userList) {
  var users = document.getElementById("userList");
  while (users.firstChild) {
    users.removeChild(users.firstChild);
  }
  for (let i = 0; i < userList.length; i++) {
    var encodedMsg = userList[i].name + " has joined the game." + "Score is " + userList[i].score;
    console.log(userList[i]);
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("userList").appendChild(li);
  }
});

connection.on("ReceiveMessage", function (user, message) {
  var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
  var encodedMsg = user + " says " + msg;
  var li = document.createElement("li");
  li.textContent = encodedMsg;
  document.getElementById("messagesList").appendChild(li);
});

document.getElementById("sendButton").addEventListener("click", function (event) {
  var user = document.getElementById("userInput").value;
  var message = document.getElementById("messageInput").value;
  connection.invoke("SendMessage", user, message).catch(function (err) {
    return console.error(err.toString());
  });
  event.preventDefault();
});

$("#voteButton").click(function () {
  var $answer = $('input[name=answer-options]:checked').val();
  var user = document.getElementById("userInput").value;
  connection.invoke("AddPoints", user, $answer).catch(function (err) {
    return console.error(err.toString());
  });
  event.preventDefault();
});


$("#resultButton").click(function () {
  var user = document.getElementById("userInput").value;
  connection.invoke("SendUser", user).catch(function (err) {
    return console.error(err.toString());
  });
  event.preventDefault();
});