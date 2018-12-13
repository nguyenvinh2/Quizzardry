"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/triviaHub").build();
var userCount = 0;

$(document).ready(function () {
  $(".questions").hide();
  $("#question1").show();


  connection.start().then(function () {
    var user = document.getElementById("userInput").value;
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

    connection.on("UserJoin", (userList) => {
        $(`#user-number`).text(`Users Join: ${userList.length}. Admin ${userList[0].name}`);
        var encodedMsg = userList[userList.length - 1].name + " has joined the game.";
        var li = document.createElement("li");
        li.textContent = encodedMsg;
        $("#messagesList").prepend(li);

    })

  connection.on("ReceiveUser", function (userList, questions, round) {
    
    $("#questions").empty();
    for (let i = 0; i < questions.length; i++) {
      $("#questions").append(`<div id="question${i + 1}" class="questions text-center">
                                        <h4>${questions[i].question}</h4>
                                        <div class="d-block mt-3">
                                            <label>
                                                ${questions[i].answer1}
                                                <input name="answer-options" type="radio" value="a" />
                                            </label>
                                        </div>
                                        <div class="d-block mt-2">
                                            <label>
                                                ${questions[i].answer2}
                                                <input name="answer-options" type="radio" value="b" />
                                            </label>
                                        </div>
                                        <div class="d-block mt-2">
                                            <label>
                                                ${questions[i].answer3}
                                                <input name="answer-options" type="radio" value="c" />
                                            </label>
                                        </div>
                                        <div class="d-block mt-2">
                                            <label>
                                                ${questions[i].answer4}
                                                <input name="answer-options" type="radio" value="d" />
                                            </label>
                                        </div>
                                    </div>`);
    }
    hideAll(round, userList);
  });

  function hideAll(round, userList) {
    setEventListeners();

    var currentQuestionId = "question" + round;
    $(".questions").hide();
    $(`#${currentQuestionId}`).show();

    if (round > 5) {

      userList.sort((a, b) => b.score - a.score);
      $(`#winnerList`).empty();
        for (let i = 0; i < userList.length; i++) {
            $("#winnerList").append(`<li>${userList[i].name}: ${userList[i].score} points</li>`)
        }
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
    $("#messagesList").prepend(li);
  });

  document.getElementById("sendButton").addEventListener("click", function (event) {
    var $user = $("#userInput").val();
    var $message = $("#messageInput").val();
    $("#messageInput").val("");
    connection.invoke("SendMessage", $user, $message).catch(function (err) {
      return console.error(err.toString());
    });
    event.preventDefault();
  });

    connection.on("Vote", (round) => {
        var $answer = $('input[name=answer-options]:checked').val();
        connection.invoke("AddPoints", $answer, round).catch(function (err) {
            return console.error(err.toString());
        });
    })

  function setEventListeners() {
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