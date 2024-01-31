Application 1: Web application (single page UI) with one input field, one
output field and one Icon named ‘status’ that changes according to the system
status.

Application 2: Web Server that receives messages/requests from Application 1


Workflow:
1/ When both applications start, the status icon on App1 should be ‘idle’.

2/ Then (e.g. after 5 seconds), App1 sends a greeting message to App2 informing that
is in ready state. On OK response of App2 to the greeting, the status icon on App1 is
'online'.

3/ When the status is online, the user can introduce text on App1 input field. This text
is then received in App2 and printed on the console.

4/ The App2 during its online time sends a timestamp message with the format
YYYY-MM DDTHH:MM:SS every 3 seconds which is printed in the output field on App 1.

5/ The App2 should exit after sending 10 timestamp messages to App1 or after
receiving 40 characters as a sum of all characters received from App1. On exit,
App1 icon is ‘finished’.

6/ On workflow point 4, the timestamp message to be sent from App2 to App1 should also contain the input received from App1 until, then but in reverse order: YYYY-MM DDTHH:MM:SS + [reverse input messages]

Techstack:
Angular, C#, .NET Core Web API, SignalR
