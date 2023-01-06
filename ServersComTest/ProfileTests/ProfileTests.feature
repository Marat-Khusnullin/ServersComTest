﻿Функция: Проверка функций сайта

Контекст: 
	Дано произведена авторизация пользователя с email 55klevanso55+ask_ev@gmail.com и паролем serverstest

@positive
Сценарий: Добавление контакта
	Допустим нажимаем кнопку модуля Profile
	И нажимаем кнопку модуля Contacts
	И нажимаем кнопку добавления контакта
	И заполняем поле First name значением TestName
	И заполняем поле Last name значением TestLastName
	И заполняем поле Middle name значением TestMiddleName
	И заполняем поле Email значением test@mail.ru
	И заполняем поле Secondary email значением testsecondary@mail.ru
	И заполняем поле Phone number значением +79274951423
	И в поле Jobe role выбираем значение Technical
	И заполняем поле Company значением TestCompany
	И заполняем поле Job title значением TestTitle
	И заполняем поле Job role значением TestRole
	И заполняем поле Nickname значением TestNickname
	И в поле Comments записываем значение TestComment
	И нажимаем кнопку добавления деталей контакта
	И в поле Contact details записываем значение 434-34-23
	Когда нажимаем кнопку создания контакта
	Тогда отображается сообщение об успешном действии с текстом Created successfully
	И отображается страница Contact info
	И на странице Contact info отображаются введенные раннее данные контакта

@positive
Сценарий: Удаление контакта
	Допустим добавили контакт со случайными данными
	И нажимаем кнопку модуля Profile
	И нажимаем кнопку модуля Contacts
	Когда удаляем в таблице добавленный контакт
	Тогда отображается сообщение об успешном действии с текстом Deleted successfully
	И в списке контактов нет добавленного контакта
	
@positive
Сценарий: Изменение контакта
	Допустим добавили контакт со случайными данными
	И нажимаем кнопку редактирования контакта
	И изменяем все поля контакта
	Когда нажимаем кнопку сохранения изменений контакта
	Тогда отображается сообщение об успешном действии с текстом Updated successfully
	И отображается страница Contact info
	И на странице Contact info отображаются введенные раннее данные контакта

@positive
Сценарий: Заказ облачного сервера
	Допустим нажимаем кнопку модуля Cloud Servers
	И нажимаем кнопку модуля Create & Manage
	И нажимаем кнопку добавления сервера
	И выбираем локацию San Jose
	И выбираем образ Windows Server 2016 Standard Edition (64 bit)
	И выбираем конфигурацию SSD.50
	И выбираем необходимость бекапа в количестве 6 единиц
	И выбираем сетевую опцию Add IPv6 address
	И в поле Name ввожу значение TestName
	Когда нажимаем кнопку создания сервера
	Тогда отображается страница Payment methods
