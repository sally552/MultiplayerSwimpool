# MultiplayerSwimpool
Тестовый проект мультиплеера. Бассейн для одного утопающего.

## Что сделано: 
1) управление. WASD для ходьбы. E - для телепортации в бассейн, если свободно.
2) бассейн. шейдер воды(блики, искажение, волны). бортик бассейна, при нахождении в бассейне человека, становится желтым.
![grab-landing-page](https://github.com/sally552/MultiplayerSwimpool/blob/main/GitResource/Bliki.gif)
![](http://www.reactiongifs.us/wp-content/uploads/2013/10/nuh_uh_conan_obrien.gif)
![](https://github.com/sally552/MultiplayerSwimpool/blob/main/GitResource/app.jpg)
![](https://github.com/sally552/MultiplayerSwimpool/blob/main/GitResource/app1.jpg)
3) бассейн имеет состояния, теоретически можно добавлять больше состояний.
4) как мне кажется, разделение на серверную и клиентскую часть.
5) в редакторе в меню есть разделение(переключение) на СЕРВЕР и КЛИЕНТ. Введены соответствующие условные символы сценариев: #SERVER и #CLIENT
6) сервер создает комнату по вшитыму в конфиг адресу. клиент по идее должен сразу подключаться к серверу.
7) добавил простенький скайбокс, модели пола, бортика, бассейна.
8) есть заготовка под кроссплатформу(пк, вр).
9) немного урезал текстуры, тень, различные карты(привычка собирать под телефон, качество не стало хуже(ну может ток тень размытее).
10) в редакторе есть и Хост(сервер+игрок) и Сервер(без игрока) и клиент. В сборках нет хоста.

## Что не сделано:
1) не делал лобби
2) никак не прорабатывал UI. начальный экран сделан через простое OnGui
3) нет никаких проверок на "дурачка"(проверки на null, плохие входящие параметры и тд).
4) нет проверок сетевых ошибок: нет интернета, не смог подключиться, сервер упал и тд


## Что можно улучшить:
1) в воде бассейна добавить эффект искажения(пост эффект для человека "аля" под водой.
2) возможно, не все разбито идеально на абстракции(но тут надо знать, куда будет развиваться проект).
3) есть разные настройки сборки(через те же условные символы) для сервера и клиента. но настройки подключения надо руками подставлять в редакторе. по идее можно это решить через DI. но ради только конфигов не стал вводить.
4) сделать нормальное меню.
5) прописать обработчики ошибок

## Что не работает:
Не смог поднять сервер у себя. локально (127.0.0.1 или 192.168.Х.Х) все работает. через ассет(не стал комитеть) ParrelSync

https://github.com/VeriorPies/ParrelSync/releases

сделал копии проектов для тестирования. тестирование глобальной сети: на удаленном пк запускается сервер с локальным айпи. я,как клиент, запускаю с глобальным айпи удаленного пк. соединение есть. в обартную сторону(я сервер, удаленный пк - клиент) не работает. Разбираюсь в настройках своей сети.
