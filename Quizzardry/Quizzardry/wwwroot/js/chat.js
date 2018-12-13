"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/triviaHub").build();
var userCount = 0;

$(document).ready(function () {
  $(".questions").hide();
  $("#question1").show();


  connection.start().then(function () {
    var user = document.getElementById("userInput").value;
    //var userGuid = document.getElementById("userInputGuid").value;
    if (userCount === 0) {
      connection.invoke("CreateQuestions", user);
    }
    else {
      connection.invoke("SendUser", user).catch(function (err) {
        return console.error(err.toString());
      });
    }
    userCount++;
  }).catch(function (err) {
    return console.error(err.toString());
  });

  connection.on("MakeAdmin", function (questions, round, userList) {
    for (let i = 0; i < questions.length; i++) {
      $(`#question${i + 1}`).append(`<input type="button" class="submitButton" value="Submit" />`);
    }
    hideAll(round, userList);
  });


  connection.on("ReceiveUser", function (userList, questions, round) {
    console.log(round);
    $(`#user-number`).text(`Users Join: ${userList.length}. Admin ${userList[0].name}`);
    var users = document.getElementById("userList");
    while (users.firstChild) {
      users.removeChild(users.firstChild);
    }
    for (let i = 0; i < userList.length; i++) {
      var encodedMsg = userList[i].name + " has joined the game." + " Score is " + userList[i].score;
      console.log(userList[i]);
      var li = document.createElement("li");
      li.textContent = encodedMsg;
      document.getElementById("userList").appendChild(li);
    }
    $("#questions").empty();
    for (let i = 0; i < questions.length; i++) {
      $("#questions").append(`<div id="question${i + 1}" class="questions">
                                        <h4>${questions[i].question}</h4>
                                        <label>${questions[i].answer1}</label>
                                        <input name="answer-options" type="radio" value="a" />
                                        <label>${questions[i].answer2}</label>
                                        <input name="answer-options" type="radio" value="b" />
                                        <label>${questions[i].answer3}</label>
                                        <input name="answer-options" type="radio" value="c" />
                                        <label>${questions[i].correctAnswer}</label>
                                        <input name="answer-options" type="radio" value="d" />
                                        <input type="hidden" class="voteCount" value="0" />
                                        <input type="button" class="voteButton" value="SendVote" />
                                    </div>`);
    }
    hideAll(round, userList);
    //setEventListeners();

    //var currentQuestionId = "question" + round;
    //$(".questions").hide();
    //$(`#${currentQuestionId}`).show();

    //if (round > 5) {
    //    var highScore = 0;
    //    var userName = "";
    //    for (let i = 0; i < userList.length; i++) {
    //        if (userList[i].score > highScore) {
    //            highScore = userList[i].score;
    //            userName = userList[i].name;
    //        }
    //    };
    //    $("#winner").prepend(`<h2>Congrats ${userName}! The winning score is ${highScore}!</h2>`);
    //    $("#winner").removeClass("hidden");
    //    $("#resetButton").on("click", () => {
    //        connection.invoke("Reset");
    //    });
    //}
  });

  function hideAll(round, userList) {
    setEventListeners();

    var currentQuestionId = "question" + round;
    $(".questions").hide();
    $(`#${currentQuestionId}`).show();

    if (round > 5) {
      var highScore = 0;
      var userName = "";
      for (let i = 0; i < userList.length; i++) {
        if (userList[i].score > highScore) {
          highScore = userList[i].score;
          userName = userList[i].name;
        }
      }
      $("#winner").prepend(`<h2>Congrats ${userName}! The winning score is ${highScore}!</h2>`);
      $("#winner").removeClass("hidden");
      $("#resetButton").on("click", () => {
        connection.invoke("Reset");
      });
    }
  }

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

  function setEventListeners() {
    $(".voteButton").click(function () {
      var $answer = $('input[name=answer-options]:checked').val();
      //var userGuid = document.getElementById("userInputGuid").value;
      connection.invoke("AddPoints", $answer).catch(function (err) {
        return console.error(err.toString());
      });
      event.preventDefault();
    });


    $(".submitButton").click(function () {
      connection.invoke("SubmitAnswers").catch(function (err) {
        return console.error(err.toString());
      });
      event.preventDefault();
    });
  }

  connection.on("BackHome", () => {
    window.location = "/";
  });
});