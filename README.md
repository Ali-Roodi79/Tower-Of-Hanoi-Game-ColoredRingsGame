# Tower-Of-Hanoi-Game-ColoredRingsGame

This project is an implementation of the **Tower of Hanoi** problem or **colored rings game** designed using **C#** language and in the console environment.
This project was designed as part of my student project for a data structure course at university.
In this game, we have at least 3 and at most 15 rods or columns. We also have at least 2 and at most 35 rings (however, I used numbers instead of rods in the console environment).
The numbers are placed on the columns in an unbalanced way. You have to arrange the numbers in **ascending** order, for example from 1 to 10, to complete the game.


## How to use:

- When you run the project, this wpf screens will be displayed:


![image](https://github.com/Ali-Roodi79/Voice-Server-VoIP/blob/main/assets/img/MainPage.png)

---

- We enter the server **IP** in the first field and the server **port** in the second field and activate the server by pressing the **"set"** button.
- Then we specify the number of clients that the server can respond to in the next field, and by pressing the **"Start Accepting"** button, the server starts accepting clients:


![image](https://github.com/Ali-Roodi79/Voice-Server-VoIP/blob/main/assets/img/Set-Server-IP-Port-and-binding.png)

---

Also, in the third section, you can go to the management page of a specific client by searching for the IP and port of that client and pressing the "Find" button.


![image](https://github.com/Ali-Roodi79/Voice-Server-VoIP/blob/main/assets/img/ClientsPage.png)

---

- On this page, the username, password, IP address, port and traffic received by our target client are displayed.
- You can also close this client's socket and disconnect it from the server.

> Also, on the main page, as a server, you can send a single message to all clients and also turn off the server
>  by pressing the power button (upper right of the page).
