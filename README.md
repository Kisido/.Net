# Требования к задаче

Создать приложение для оценки фильмов и сериалов
+ Необходимо реализовать регистрацию/вход пользователя (администратор или обычный пользователь)
+ Информация о пользователе содержит:
    + Имя пользователя (Никнейм)
    + Телефон
    + Электронная почта
    + (Возможно что-то ещё)
+ Пользователь может найти фильм/сериал по какому-то набору параметров (определённого названия, жанра, года выпуска, режиссёра и т.д.)
+ Пользователь может отсортировать фильм по рейтингу, алфавиту, дате выхода (Возможно по чему-то ещё)
+ Пользователь может оставить оценку фильму по 100-бальной шкале, к оценке может быть прикреплён развёрнутый отзыв, но также можно оставить окно с описанием пустым
+ Пользователь может отредактировать свой отзыв, дописав туда комментарий или изменив оценку
+ Пользователь может просматривать отзывы других пользователей
+ Администратор может удалить отзыв/оценку любого пользователя
+ Администратор может разместить информацию о новом фильме/сериале, удалить существующий проект, изменить информацию о проекте
+ Информация о фильме/сериале содержит:
    + Название проекта
    + Год выпуска (период выпуска, если это сериал)
    + Краткое описание проекта
    + Жанр(ы)
    + Страна-производитель
    + Режиссёр
    + Актёры в главных ролях
    + (Возможно что-то ещё)

# База данных

![image](https://user-images.githubusercontent.com/106271833/198120992-d7d9eeb5-7fc4-408e-bfdb-47106440508b.png)


1. Раскрыл связь многие ко многим, добавил промежуточные сущности
2. Сменил название Creation на Movie
3. Поставил отображение доменов атрибутов
