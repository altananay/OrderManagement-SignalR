let connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:5151/SignalRHub").build();
document.getElementById("sendbutton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    let currentTime = new Date();
    let currentHour = currentTime.getHours();
    let currentMinute = currentTime.getMinutes();

    let li = document.createElement("li");
    let span = document.createElement("span");
    span.style.fontWeight = "bold";
    span.textContent = user;
    li.appendChild(span);
    li.innerHTML += ` :${message} - ${currentHour}:${currentMinute}`;
    document.getElementById("messagelist").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendbutton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendbutton").addEventListener("click", function (event) {
    let user = document.getElementById("userinput").value;
    let message = document.getElementById("messageinput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});