# MultiplayerSwimpool
Тестовый проект мультиплеера. Бассейн для одного утопающего.

## Что сделано: 
1) Управление. WASD для ходьбы. E - для телепортации в бассейн, если свободно.
2) Бассейн. Шейдер воды (блики, искажение, волны). Бортик бассейна при нахождении в воде человека становится желтым.
![grab-landing-page](https://github.com/sally552/MultiplayerSwimpool/blob/main/GitResource/Bliki.gif)
![](http://www.reactiongifs.us/wp-content/uploads/2013/10/nuh_uh_conan_obrien.gif)
![](https://github.com/sally552/MultiplayerSwimpool/blob/main/GitResource/app.jpg)
![](https://github.com/sally552/MultiplayerSwimpool/blob/main/GitResource/app1.jpg)
3) Бассейн имеет состояния, теоретически можно добавлять больше состояний.
4) Как мне кажется, правильное разделение на серверную и клиентскую часть.
5) В редакторе в меню есть разделение (переключение) на СЕРВЕР и КЛИЕНТ. Введены соответствующие условные символы сценариев: #SERVER и #CLIENT
6) Сервер создает комнату по вшитому в конфиг адресу. Клиент, по задумке, должен сразу подключаться к серверу.
7) Добавил простенький скайбокс, модели пола, бортика, бассейна.
8) Eсть заготовка под кроссплатформу (пк, вр).
9) Немного урезал текстуры, тень, различные карты (привычка собирать под телефон, качество не стало хуже (ну может ток тень размытее)).
10) В редакторе есть и Хост (сервер+игрок) и Сервер (без игрока) и клиент. В сборках нет хоста.

## Что не сделано:
1) Не делал лобби. совсем. Коннектимся к хардкоженому адресу. Такая задумка
2) Никак не прорабатывал UI. начальный экран сделан через простое OnGui.
3) Нет никаких проверок  "на дурачка" (проверки на null, плохие входящие параметры и тд).
4) Нет проверок сетевых ошибок: нет интернета, не смог подключиться, сервер упал и тд.


## Что можно улучшить:
1) В воде бассейна добавить эффект искажения (при попадании игрока под воду будет искажение и размытие).
2) Возможно, не все разбито идеально на абстракции (но тут надо знать, куда будет развиваться проект).
3) Есть разные настройки сборки (через те же условные символы) для сервера и клиента, но настройки подключения надо руками подставлять в редакторе. По идее можно это решить через DI. Но ради только конфигов не стал вводить.
4) Сделать нормальное меню.
5) Прописать обработчики ошибок.

## Что не работает:
Не смог поднять сервер у себя. Локально (127.0.0.1 или 192.168.Х.Х) все работает. Через ассет(не стал комитеть) ParrelSync

https://github.com/VeriorPies/ParrelSync/releases

сделал копии проектов для тестирования. Тестирование глобальной сети: на удаленном пк запускается сервер с локальным айпи. Я, как клиент, запускаю с глобальным айпи удаленного пк. Соединение есть. В обратную сторону (я сервер, удаленный пк - клиент) не работает. Разбираюсь в настройках своей сети.
